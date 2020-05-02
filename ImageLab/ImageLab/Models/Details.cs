namespace ImageLab.Models
{
    public class Details
    {
        public int Count { get; set; }

        public double Size { get; set; }

        public double Comparison { get; set; }

        public override string ToString()
        {
            var result = $"S: { string.Format("{0:0.00}", Size / 1024)}";
            if (Count > 1)
            {
                result += $"  | C: {Count}";

            }

            if (Comparison > 0)
            {
                result += $" | Cr: {string.Format("{0:0.00}", Comparison)} %";
            }
            return result;
        }
    }
}
