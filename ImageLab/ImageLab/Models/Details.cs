﻿using System;

namespace ImageLab.Models
{
    public class Details
    {
        public int Count { get; set; }

        public double Size { get; set; }

        public double Comparison { get; set; }

        public override string ToString()
        {
            var result = $"C: {Count}  |  S: { string.Format("{0:0.00}", Size / 1024)}";
            if (Comparison > 0)
            {
                result += $" | Cr: {string.Format("{0:0.00}", Comparison)} %";
            }
            return result;
        }
    }
}
