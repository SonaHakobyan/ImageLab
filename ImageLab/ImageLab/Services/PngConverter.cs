using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace ImageLab.Services
{
    public class PngConverter : IConverter
    {
        public bool Convert(string imagePath)
        {
            Boolean result = false;
            if (File.Exists(imagePath))
            {
                if (Path.GetExtension(imagePath) != ".bmp")
                {
                    throw new Exception("Select bmp file,please!");
                }

                String pngPath = Path.Combine(Path.GetDirectoryName(imagePath), Path.GetFileNameWithoutExtension(imagePath) + ".png");
                Bitmap bmp = new Bitmap(imagePath);
                bmp.Save(pngPath, ImageFormat.Png);
                result = true;
            }
            return result;
        }
    }
}
