using ImageLab.Models;

namespace ImageLab.Services
{
    public class MockDataProvider : IDataProvider<Folder>
    {
        public Folder LoadData(string source)
        {
            var f1 = new Folder("fdf");
            var f2 = new Folder("fff");
            var f3 = new Folder("vdv");

            var i1 = new ImageSet("fdf");
            var i2 = new ImageSet("fdf");


            f1.Children.Add(f2);
            f1.Children.Add(f3);
            f2.Children.Add(i1);
            f2.Children.Add(i2);

            return f1;
            //var data = new List<Container>();

            //var path = @"C:\Users\hakob\ImageLabResources\Monochrome\";

            //var bmp1 = Image.FromFile($"{path}5PMe5hr8tjSS9Nq5d6Cebe.bmp");
            //var bmp2 = Image.FromFile($"{path}flasks-606612_960_720.bmp");
            //var bmp3 = Image.FromFile($"{path}flasks-606612_960_720.bmp");

            //var s1 = new ImageSet { Name = "5PMe5hr8tjSS9Nq5d6Cebe", BMP = bmp1 };
            //var s2 = new ImageSet { Name = "flasks-606612_960_720", BMP = bmp2 };
            //var s3 = new ImageSet { Name = "flasks-606612_960_720", BMP = bmp3 };

            //var f1 = new Folder { Name = "folder1", Items = new List<Container> { s1 } };
            //var f3 = new Folder { Name = "folder3",Items = new List<Container> { s1, s3 , f1} };
            //var f2 = new Container { Name = "folder2", Items = new List<Container> { f1, f3, s2 }};

            //data = new List<Container> { f2 };

            //return data;
        }
    }
}
