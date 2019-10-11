using System.Linq;
using ImageLab.TreeGrid;

namespace ImageLab.Models
{
    public class Folder : TreeGridElement
    {
        public string Name { get; private set; }

        public int Count => this.GetCount();
        public Details BMPDetails => GetFormatDetails(Format.BMP);
        public Details PNGDetails => GetFormatDetails(Format.PNG);

        public Folder(string name)
        {
            Name = name;
            this.HasChildren = true;
        }

        private int GetCount()
        {
            var sets = this.Children.Where(x => x.HasChildren == false);
            var folders = this.Children.Where(x => x.HasChildren == true);

            var count = sets.Count();

            foreach (Folder folder in folders)
            {
                count += folder.Count;
            }
            return count;
        }

        private Details GetFormatDetails(Format format)
        {
            var details = new Details();
            details.Size = this.GetSize(format);
            details.Compression = this.GetCompression();

            return details;
        }

        private decimal GetCompression() => 0;

        private double GetSize(Format format)
        {
            var sets = this.Children.Where(x => x.HasChildren == false);
            var folders = this.Children.Where(x => x.HasChildren == true);

            var size = 0.0;

            foreach (ImageSet set in sets)
            {
                size += set.Details[format].Size;
            }

            foreach (Folder folder in folders)
            {
                size += folder.GetSize(format);
            }
            return size;
        }
    }
}
