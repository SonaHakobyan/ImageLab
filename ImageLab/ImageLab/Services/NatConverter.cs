using NAT;
using NAT.Extensions;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows;

namespace ImageLab.Services
{
    public class NatConverter : IFormatConverter
    {
        public bool Convert(string imagePath)
        {
            if (!File.Exists(imagePath))
            {
                return false;
            }

            Debug.Assert(Path.GetExtension(imagePath).Equals(".bmp"), "Select bmp file, please!");

            var bitmap = new Bitmap(imagePath);
            if (!bitmap.Compare(new Nat(bitmap).GenerateBitmap()))
            {
                MessageBox.Show("Conversion failed!");
                return false;
            }

            var natPath = Path.Combine(Path.GetDirectoryName(imagePath), Path.GetFileNameWithoutExtension(imagePath) + ".nat");
            //nat.Save(natPath);

            return true;
        }
    }
}
