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
        public string RootPath { get; set; }

        public ICommand SelectOptionCommand { get; set; }
        public ICommand CheckBoxCheckedCommand { get; set; }

        private ObservableCollection<TreeNode> rootItem;
        public ObservableCollection<TreeNode> RootItem
        {
            get => this.rootItem;
            set
            {
                this.rootItem = value;
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

        public MainViewModel()
        {
            SelectOptionCommand = new SelectOptionCommand(this);
            CheckBoxCheckedCommand = new CheckBoxCheckedCommand(this);
        }

        public void UpdateTreeView()
        {
            var tree = new TreeNode();
            Methods.GetTreeView(this.RootPath, ref tree);

            RootItem = new ObservableCollection<TreeNode> { tree };
        }

        public void GetCheckedItems(TreeNode sourceItem, List<TreeNode> checkedItems)
        {
            if (sourceItem.IsVisible)
            {
                checkedItems.Add(sourceItem);
            }

            foreach (TreeNode item in sourceItem.Items)
            {
                GetCheckedItems(item, checkedItems);
            }
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
