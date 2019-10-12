using System;

namespace ImageLab.Models
{
    public class Details
    {
        public Int32 Count { get; set; }

        public Double Size { get; set; }

        public override String ToString()
        {
            return $"Count: {Count}, Size: {Size}";
        }
    }
}
