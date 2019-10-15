namespace ImageLab.Services
{
    public interface IConverter
    {
        /// <summary>
        /// Convert BMP file to another image format
        /// </summary>
        /// <param name="imagePath"></param>
        /// <returns></returns>
        bool Convert(string image);
    }
}
