using ImageLab.Commands;
using ImageLab.Enumerations;
using ImageLab.Models;
using ImageLab.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace ImageLab.ViewModels
{
    public class MainViewModel : BindableBase
    {
        #region Commands
        public ICommand SelectOptionCommand { get; set; }
        public ICommand CheckBoxCheckedCommand { get; set; }
        public ICommand ConvertImageCommand { get; set; }
        // public ICommand SelectedItemChangedCommand { get; set; }
        #endregion

        #region Bindable Properties
        public string RootPath { get; set; }

        private String selectedImage;
        public String SelectedImage
        {
            get => selectedImage;
            set
            {
                selectedImage = value;
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
            ConvertableFormatsList = new ObservableCollection<Format> { Format.Png, Format.Jpg};

            SelectOptionCommand = new SelectOptionCommand(this);
            CheckBoxCheckedCommand = new CheckBoxCheckedCommand(this);
            ConvertImageCommand = new ConvertImageCommand(this);
            //SelectedItemChangedCommand = new SelectedItemChangedCommand(this);
        }

        public void UpdateTreeView()
        {
            var tree = new TreeNode();
            Methods.GetTreeView(this.RootPath, ref tree);

            RootItem = new ObservableCollection<TreeNode> { tree };
        }

        public Details GetDetails(String path, String searchPattern = null)
        {
            EntryType entryType = Methods.GetEntryType(path);

            if (entryType == EntryType.Image)
            {
                FileInfo fileInfo = new FileInfo(path);

                return new Details
                {
                    Count = 1,
                    Size = fileInfo.Length
                };
            }
            else
            {
                String[] files = Directory.GetFiles(path, searchPattern, SearchOption.AllDirectories);

                Double size = 0;

                foreach (String file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);

                    size += fileInfo.Length;
                }

                return new Details
                {
                    Count = files.Length,
                    Size = size
                };
            }
        }
    }
}
