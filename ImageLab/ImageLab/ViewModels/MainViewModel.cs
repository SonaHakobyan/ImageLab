using ImageLab.Commands;
using ImageLab.Enumerations;
using ImageLab.Models;
using ImageLab.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;

namespace ImageLab.ViewModels
{
    public class MainViewModel : BindableBase
    {
        #region Commands
        public ICommand SelectOptionCommand { get; set; }
        public ICommand ConvertImageCommand { get; set; }
        #endregion

        #region Bindable Properties
        public string RootPath { get; set; }

        private string selectedPath;
        public string SelectedPath
        {
            get => selectedPath;
            set
            {
                selectedPath = value;
                NotifyPropertyChanged();
            }
        }

        private GridRowModel selectedRow;
        public GridRowModel SelectedRow
        {
            get => selectedRow;
            set
            {
                selectedRow = value;
                NotifyPropertyChanged();

                selectedNode = RootItem.Where(x => x.Id == value.Id).FirstOrDefault();
                NotifyPropertyChanged("SelectedRow");
            }
        }

        private TreeNode selectedNode;
        public TreeNode SelectedNode
        {
            get => selectedNode;
            set
            {
                selectedNode = value;
                NotifyPropertyChanged();

                selectedRow = ListViewItems.Where(x => x.Id == value.Id).FirstOrDefault();
                NotifyPropertyChanged("SelectedNode");
            }
        }

        private ConvertionError convertionError;
        public ConvertionError ConvertionError
        {
            get => convertionError;
            set
            {
                convertionError = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<Format> convertableFormatsList;
        public ObservableCollection<Format> ConvertableFormatsList
        {
            get => convertableFormatsList;
            set
            {
                convertableFormatsList = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<TreeNode> rootItem;
        public ObservableCollection<TreeNode> RootItem
        {
            get => rootItem;
            set
            {
                rootItem = value;
                NotifyPropertyChanged();
            }
        }

        private ObservableCollection<GridRowModel> listViewItems;
        public ObservableCollection<GridRowModel> ListViewItems
        {
            get => listViewItems;
            set
            {
                listViewItems = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        public MainViewModel()
        {
            ConvertableFormatsList = new ObservableCollection<Format> { Format.NAT, Format.PNG};

            SelectOptionCommand = new SelectOptionCommand(this);
            ConvertImageCommand = new ConvertImageCommand(this);

            LoadView();
        }

        public void LoadView()
        {
            UpdateTreeView();
            UpdateView();
        }

        public void UpdateTreeView()
        {
            var tree = new TreeNode();
            Helper.GetTreeView(this.RootPath, ref tree);

            RootItem = new ObservableCollection<TreeNode> { tree };
        }

        public void UpdateView()
        {
            var expandedItems = new List<TreeNode>();
            var tree = RootItem.FirstOrDefault();

            Helper.GetExpandedItems(tree, expandedItems);

            var rows = new ObservableCollection<GridRowModel>();

            foreach (var item in expandedItems)
            {
                var row = new GridRowModel();
                row.Id = item.Id;

                if (item.EntryType == EntryType.Image)
                {
                    var fileDirectory = Path.GetDirectoryName(item.FullPath);

                    var fileName = Path.GetFileNameWithoutExtension(item.FullPath);

                    var bmpFilePath = Path.Combine(fileDirectory, fileName + ".bmp");

                    if (File.Exists(bmpFilePath))
                    {
                        row.BmpDetails = Helper.GetDetails(bmpFilePath);

                        var pngFilePath = Path.Combine(fileDirectory, fileName + ".png");

                        if (File.Exists(pngFilePath))
                        {
                            row.PngDetails = Helper.GetDetails(pngFilePath);
                            row.PngDetails.Comparison = 100 / (row.BmpDetails.Size / row.PngDetails.Size);
                        }

                        var natFilePath = Path.Combine(fileDirectory, fileName + ".nat");

                        if (File.Exists(natFilePath))
                        {
                            row.NatDetails = Helper.GetDetails(natFilePath);
                            row.NatDetails.Comparison = 100 / (row.BmpDetails.Size / row.NatDetails.Size);
                        }
                    }
                }
                else
                {
                    row.BmpDetails = Helper.GetDetails(item.FullPath, "*.bmp");

                    row.PngDetails = Helper.GetDetails(item.FullPath, "*.png");

                    row.NatDetails = Helper.GetDetails(item.FullPath, "*.nat");
                }

                rows.Add(row);
            }

            ListViewItems = rows;
        }
    }
}
