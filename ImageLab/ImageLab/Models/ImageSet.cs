using System.Collections.Generic;
using ImageLab.TreeGrid;

namespace ImageLab.Models
{
    public class ImageSet : TreeGridElement
    {
        public string Name { get; private set; }

        public Dictionary<Format, Details> Details { get; set; }
        public Details BMPDetails { get => this.Details[Format.BMP]; }
        public Details PNGDetails { get => this.Details[Format.PNG]; }

        public ImageSet(string name)
        {
            Name = name;
            this.Details = new Dictionary<Format, Details>();
        }
    }
}
