using ImageLab.Services;
using ImageLab.Models;
using ImageLab.TreeGrid;
using System.Windows.Input;
using ImageLab.Commands;

namespace ImageLab.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private IDataProvider<Folder> dataProvider;

        private TreeGridModel model;
        public TreeGridModel Model
        {
            get { return model; }
            set
            {
                model = value;
                NotifyPropertyChanged();
            }
        }

        private string root;
        public string Root
        {
            get { return root; }
            set
            {
                root = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand SelectOptionsCommand { get; set; }

        public MainViewModel()
        {
            this.dataProvider = new MockDataProvider();
            //this.dataProvider = new DataProvider();

            this.SelectOptionsCommand = new SelectOptionsCommand();

            this.InitModel();
        }

        private void InitModel()
        {
            Model = new TreeGridModel();
            var data = dataProvider.LoadData(Root);
            Model.Add(data);
        }
    }
}
