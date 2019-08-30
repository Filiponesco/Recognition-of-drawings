using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NeuralNetworkBiblioteka;

namespace Rozpoznawanie_rysunkow
{
    public partial class Form1 : Form
    {
        const int res = 784;
        const int total_data = 1000;
        Kategoria airplanes;
        Kategoria bananas;
        Kategoria cars;
        Kategoria fingers;
        List<OneDraw> trainings;
        NeuralNetwork nn;

        public Form1()
        {
            InitializeComponent();
            trainings = new List<OneDraw>();
            OpenFiles();
            PreparingData(airplanes);
            PreparingData(bananas);
            PreparingData(cars);
            PreparingData(fingers);

            listBox1.Items.Add(airplanes.Informacja());
            listBox1.Items.Add(bananas.Informacja());
            listBox1.Items.Add(cars.Informacja());
            listBox1.Items.Add(fingers.Informacja());

            trainings.AddRange(airplanes.Training);
            trainings.AddRange(bananas.Training);
            trainings.AddRange(cars.Training);
            trainings.AddRange(fingers.Training);

            listBox1.Items.Add("wszystkie treningi " + trainings.Count());

            Shuffle(trainings);

            nn = new NeuralNetwork(784, 1, 64, 4);

            //Trening jednej epoki
            for (int i = 0; i < trainings.Count; i++)
            {
                OneDraw data = trainings[i];
                listBox1.Items.Add("Size jednej bitmapy:  " + data.Bmp.Size);
                listBox1.Items.Add("bajty jednego rysunku:  " + data.BrightPixels.Count());
                double[] inputs = data.BrightPixels;
                //normalizacja danych
                for (int k = 0; k < inputs.Count(); k++)
                {
                    inputs[k] /= (byte)255.0;
                }
                Label name = trainings[i].Lbl;
                double[] targets = { 0, 0, 0, 0 };
                targets[(int)name] = 1;
                listBox1.Items.Add("Label: " + name + "Targets: [" + targets[0] + " " + targets[1] + " " + targets[2] + " " + targets[3] + " ]");

                nn.Train(inputs, targets);
            }
        }
        private void OpenFiles()
        {
            airplanes = new Kategoria(Label.airplanes);
            bananas = new Kategoria(Label.bananas);
            cars = new Kategoria(Label.cars);
            fingers = new Kategoria(Label.fingers);
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
            int total = 100;
            int x = 0; int y = 0;
            for (int n = 0; n < total; n++)
            {
                Bitmap img = BytesToBitmap(airplanes.Data, n, 28, 28);
                x = (n % 10) * 28;
                y = (n / 10) * 28;
                Graphics g = e.Graphics;
                e.Graphics.DrawImage(img, x, y);
            }
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
    }
}
