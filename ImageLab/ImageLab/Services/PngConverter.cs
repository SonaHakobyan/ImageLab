using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageLab.Services
{
    public class PngConverter : IFormatConverter
    {
        public bool Convert(string imagePath)
        {
            if (!File.Exists(imagePath))
            {
                return false;
            }

            Debug.Assert(Path.GetExtension(imagePath).Equals(".bmp"), "Select bmp file, please!");

            var pngPath = Path.Combine(Path.GetDirectoryName(imagePath), Path.GetFileNameWithoutExtension(imagePath) + ".png");
            var bmp = new Bitmap(imagePath);
            bmp.Save(pngPath, ImageFormat.Png);
            return true;
        }
    }
}
