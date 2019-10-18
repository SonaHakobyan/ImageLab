using System;

namespace ImageLab.Models
{
    public class Details
    {
        public Int32 Count { get; set; }

        public Double Size { get; set; }

        public Double Comparison { get; set; }

        public override String ToString()
        {
            String result = $"C:{Count} | S:{Size}";
            if (Comparison > 0)
            {
                result += $" | Cr:{Comparison} %";
            }
            return result;
        }
    }
}
