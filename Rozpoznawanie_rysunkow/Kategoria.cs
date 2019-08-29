using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rozpoznawanie_rysunkow
{
    class Kategoria
    {
        String path = @"C:\Users\fifig\Documents\GitHub\Rozpoznawanie_rysunkow\Dane\";
        public string Name { get; set; }
        public byte[] Data { get; set; }
        public List<Bitmap> Training { get; set; }
        public List<Bitmap> Testing { get; set; }

        public Kategoria(string name)
        {
            Name = name;
            Data = File.ReadAllBytes(path + Name +"1000.bin");
            Training = new List<Bitmap>();
            Testing = new List<Bitmap>();
        }
        public string Informacja()
        {
            return Name+" Length training: " + Training.Count() + " Length testing: " + Testing.Count();
        }
    }
}
