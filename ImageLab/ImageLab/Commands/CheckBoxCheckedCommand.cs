using ImageLab.Enumerations;
using ImageLab.Models;
using ImageLab.Services;
using ImageLab.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace ImageLab.Commands
{
    public class CheckBoxCheckedCommand : CommandBase
    {
        private MainViewModel vm;

        public CheckBoxCheckedCommand(MainViewModel vm)
        {
            this.vm = vm;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            List<TreeNode> checkedItems = new List<TreeNode>();
            var tree = vm.RootItem.FirstOrDefault();

            Methods.GetCheckedItems(tree, checkedItems);

            ObservableCollection<GridRowModel> rows = new ObservableCollection<GridRowModel>();

            foreach (TreeNode item in checkedItems)
            {
                GridRowModel row = new GridRowModel();

                if (item.EntryType == EntryType.Image)
                {
                    String fileDirectory = Path.GetDirectoryName(item.FullPath);

                    String fileName = Path.GetFileNameWithoutExtension(item.FullPath);

                    String bmpFilePath = Path.Combine(fileDirectory, fileName + ".bmp");

                    if (File.Exists(bmpFilePath))
                    {
                        row.BmpDetails = vm.GetDetails(bmpFilePath);
                    }

                    String pngFilePath = Path.Combine(fileDirectory, fileName + ".png");

                    if (File.Exists(pngFilePath))
                    {
                        row.PngDetails = vm.GetDetails(pngFilePath);
                    }
                }
                else
                {
                    row.BmpDetails = vm.GetDetails(item.FullPath, "*.bmp");

                    row.PngDetails = vm.GetDetails(item.FullPath, "*.png");
                }

                rows.Add(row);
            }

            vm.ListViewItems = rows;
        }
    }
}
