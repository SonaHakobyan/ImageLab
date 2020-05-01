using NAT;
using NAT.Extensions;
using System;
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

            try
            {
                var path = Path.Combine(Path.GetDirectoryName(imagePath), Path.GetFileNameWithoutExtension(imagePath) + ".nat");
                var nat = new Nat(new Bitmap(imagePath));

                nat.Save(path);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return true;
        }
    }
}
