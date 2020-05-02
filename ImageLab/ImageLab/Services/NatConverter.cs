using NAT;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace ImageLab.Services
{
    public class NatConverter : IFormatConverter
    {
        public bool Convert(string bmpFilePath)
        {
            if (!File.Exists(bmpFilePath)) { return false; }
            Debug.Assert(Path.GetExtension(bmpFilePath).Equals(".bmp"), "Select bmp file, please!");

            try
            {
                var natFilePath = Path.Combine(Path.GetDirectoryName(bmpFilePath), Path.GetFileNameWithoutExtension(bmpFilePath) + ".nat");
                Converter.ConvertToNat(bmpFilePath, natFilePath);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return true;
        }
    }
}
