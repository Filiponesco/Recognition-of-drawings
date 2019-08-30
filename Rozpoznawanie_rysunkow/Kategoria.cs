using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozpoznawanie_rysunkow
{
    class Kategoria
    {
        String path = @"C:\Users\fifig\Documents\GitHub\Rozpoznawanie_rysunkow\Dane\";
        public Label Name { get; set; }
        public byte[] Data { get; set; }
        public List<OneDraw> Training { get; set; }
        public List<OneDraw> Testing { get; set; }

        public Kategoria(Label name)
        {
            Name = name;
            Data = File.ReadAllBytes(path + Name +"1000.bin");
            Training = new List<OneDraw>();
            Testing = new List<OneDraw>();
        }
        public string Informacja()
        {
            return Name+" Length training: " + Training.Count() + " Length testing: " + Testing.Count();
        }
    }
    public enum Label
    {
        airplanes,
        bananas,
        cars,
        fingers
    }
    class OneDraw
    {
        public Label Lbl { get; set; }
        public Bitmap Bmp { get; set; }
        public double[] BrightPixels //jasność pikseli
        {
            get
            {
                double[] p = new double[Bmp.Height * Bmp.Width];
                int index = 0;
                for (int i = 0; i < Bmp.Height; i++)
                {
                    for(int k = 0; k < Bmp.Width; k++)
                    {
                        p[index] = Bmp.GetPixel(i, k).GetBrightness();
                        index++;
                    }
                }
                return p;
            }
        }
        public OneDraw(Label lbl, Bitmap bmp)
        {
            Lbl = lbl;
            Bmp = bmp;
        }
        public OneDraw(Bitmap bmp)
        {
            Bmp = bmp;
        }
    }

}
