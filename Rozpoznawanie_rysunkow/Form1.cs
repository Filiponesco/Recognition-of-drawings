﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralNetworkBiblioteka;

namespace Rozpoznawanie_rysunkow
{
    public partial class Form1 : Form
    {
        private Thread th;
        const int res = 784;
        const int total_data = 1000; //Gdy zmieniasz muszisz zmienic tez nazwe pliku wejsciowego w klasie Kategoria
        const int ileKategorii = 4; //Pamietaj o Label i o hidden

        List<Kategoria> kategorie;
        List<OneDraw> trainings;
        List<OneDraw> testings;
        NeuralNetwork nn;
        int nrEpok;

        private Graphics g;
        private Point p = Point.Empty;
        private Pen pioro;

        public Form1()
        {
            InitializeComponent();
            kategorie = new List<Kategoria>();
            trainings = new List<OneDraw>();
            testings = new List<OneDraw>();
            PictureBox.Image = new Bitmap(280, 280);
            g = Graphics.FromImage(PictureBox.Image);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pioro = new Pen(Color.White, 10);
            pioro.StartCap = pioro.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            nrEpok = 0;

            Label lbl = 0;
            for (int i = 0; i < ileKategorii; i++)
            {
                kategorie.Add(new Kategoria(lbl));
                lbl++;
            }
            foreach(var k in kategorie)
            {
                PreparingData(k);
                AddToTrainings(k);
                AddToTestings(k);
            }

            //AddToTrainings();
            //AddToTestings();

            nn = new NeuralNetwork(784, 1, 64, ileKategorii);

        }
        private void AddToTrainings(Kategoria k)
        {
            trainings.AddRange(k.Training);
        }
        private void AddToTestings(Kategoria k)
        {
            testings.AddRange(k.Testing);
        }
        private Bitmap BytesToBitmap(byte[] data, int inIndex, int height, int width)
        {
            inIndex *= res;
            Bitmap img = new Bitmap(height, width);
            for (int i = 0; i < width; i++)
            {
                for (int k = 0; k < height; k++)
                {
                    byte val = data[inIndex];
                    img.SetPixel(k, i, Color.FromArgb(255 - val, 255 - val, 255 - val));
                    inIndex++;
                }
            }
            return img;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            ////rysowanie po PictureBox

        }
        private byte[] SubArray(byte[] data, int index, int length)
        {
            byte[] result = new byte[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }

        private void PreparingData(Kategoria kat)
        {
            for (int i = 0; i < total_data; i++)
            {
                if (i < total_data * 0.8)
                {
                    kat.Training.Add(new OneDraw(kat.Name, BytesToBitmap(kat.Data, i, 28, 28)));
                }
                else
                {
                    kat.Testing.Add(new OneDraw(kat.Name, BytesToBitmap(kat.Data, i, 28, 28)));
                }
            }
        }
        private void Shuffle(List<OneDraw> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                OneDraw value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
        private void TreningEpoki()
        {
            nrEpok++;
            Shuffle(trainings);
            //Trening jednej epoki
            for (int i = 0; i < trainings.Count; i++)
            {
                OneDraw data = trainings[i];
                double[] inputs = data.BrightPixels;

                //normalizacja danych tu moze byc

                Label name = trainings[i].Lbl;
                double[] targets = new double[ileKategorii];
                for (int k = 0; k < ileKategorii; k++)
                    targets[k] = 0;
                targets[(int)name] = 1;
                nn.Train(inputs, targets);
                double wartProcent = ((double)(i + 1) / (double)trainings.Count()) * 100;

                this.InvokeIfRequired((value) => progressBar.Value = (int)wartProcent, 10);
            }
            this.InvokeIfRequired((value) => listBox1.Items.Add("Zakonczono nauczanie epoki: " + nrEpok), 10);
            th.Abort();
        }
        private void TestingAll()
        {
            Shuffle(testings);
            int correct = 0;
            //Trening jednej epoki
            for (int i = 0; i < testings.Count; i++)
            {
                OneDraw data = testings[i];
                double[] inputs = data.BrightPixels;
                Label name = testings[i].Lbl;
                double[] guess = nn.Guess(inputs);
                double maxValue = guess.Max();
                int pom = guess.ToList().IndexOf(maxValue);
                Label guessLbl = 0;
                guessLbl += pom;
                if ((int)guessLbl == (int)data.Lbl)
                    correct++;
            }
            double percent = ((double)correct / (double)testings.Count()) * 100;
            listBox1.Items.Add("Dokladnosc nauki: " + percent.ToString() + "%");
        }

        private void btnNaucz_Click(object sender, EventArgs e)
        {
            //TreningEpoki();
            th = new Thread(TreningEpoki);
            th.Start();
        }

        private void btnZgadnij_Click(object sender, EventArgs e)
        {
            Bitmap bmp = (Bitmap) PictureBox.Image;
            Bitmap resized = new Bitmap(bmp, new Size(bmp.Width / 10, bmp.Height / 10));
            OneDraw rysunek = new OneDraw(resized);

            double[] rysunekInputs = rysunek.BrightPixels;

            double[] guess = nn.Guess(rysunekInputs);
            double maxValue = guess.Max();
            int pom = guess.ToList().IndexOf(maxValue);
            //Label guessLbl = Label.airplanes;
            Label guessLbl = 0;
            guessLbl += pom;
            listBox1.Items.Add("Myślę, że jest to: " + guessLbl);
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            TestingAll();
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                p = e.Location;
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                g.DrawLine(pioro, p, e.Location);
                p = e.Location;

                PictureBox.Refresh();
            }
        }

        private void btnWyczysc_Click(object sender, EventArgs e)
        {
            g.Clear(Color.Black);
            PictureBox.Refresh();
        }
    }
}
