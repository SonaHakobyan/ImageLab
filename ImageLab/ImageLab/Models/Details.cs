namespace ImageLab.Models
{
    public class Details
    {
        public double Size { get; set; }
        public decimal Compression { get; set; }

        public override string ToString() => ( $"({Size} ) ( {Compression}% )");
    }
}
