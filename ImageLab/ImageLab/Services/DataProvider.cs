using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ImageLab.Models;

namespace ImageLab.Services
{
    public class DataProvider : IDataProvider<Folder>
    {
        public Folder LoadData(string source)
        {
            var path = Path.GetDirectoryName(source);
            var name = Path.GetFileName(path);
            var root = new Folder(name);
            var files = Directory.GetFiles(path);
            var imageSets = files.Select(x => Path.GetFileNameWithoutExtension(x)).Distinct();

            foreach (string set in imageSets)
            {
                var imageSet = new ImageSet(set);
                if (files.Contains($"{set}.bmp"))
                {
                    var info = new FileInfo($@"{path}\{set}.bmp");
                    imageSet.Details[Format.BMP] = new Details { Size = info.Length};
                }
                if (files.Contains($"{set}.png"))
                {
                    var info = new FileInfo($@"{path}\{set}.png");
                    imageSet.Details[Format.PNG] = new Details { Size = info.Length, Compression = 0 };
                }
                if (files.Contains($"{set}.jpg"))
                {
                    var info = new FileInfo($@"{path}\{set}.jpg");
                    imageSet.Details[Format.JPG] = new Details { Size = info.Length, Compression = 0 };
                }

                root.Children.Add(imageSet);
            }

            var dirs = Directory.GetDirectories(path);
            foreach (string dir in dirs)
            {
                var folder = new Folder(dir);
                root.Children.Add(folder);

            }

            return root;
        }

        private List<string> F(string dir)
        {
            List<String> files = new List<String>();
            foreach (string f in Directory.GetFiles(dir))
            {
                files.Add(f);
            }
            foreach (string d in Directory.GetDirectories(dir))
            {
                files.AddRange(F(d));
            }

            return files;
        }
    }
}
