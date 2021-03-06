﻿namespace ImageLab.Services
{
    public interface IFormatConverter
    {
        /// <summary>
        /// Convert BMP file to another image format
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        bool Convert(string imagePath);
    }
}
