using ImageLab.Enumerations;
using ImageLab.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;

namespace ImageLab.Services
{
    public static class Helper
    {
        public static void GetTreeView(String basePath, ref TreeNode viewItem, TreeNode parentItem = null)
        {
            EntryType entryType = GetEntryType(basePath);

            String name = Path.GetFileNameWithoutExtension(basePath);

            if (entryType == EntryType.Image && parentItem != null && parentItem.Items.Any(x => x.Name == name && x.EntryType == entryType))
            {
                return;
            }

            viewItem.Items = new ObservableCollection<TreeNode>();
            viewItem.Name = Path.GetFileNameWithoutExtension(basePath);
            viewItem.EntryType = entryType;
            viewItem.FullPath = basePath;

            if (parentItem != null)
            {
                parentItem.Items.Add(viewItem);
            }

            if (entryType == EntryType.Directory)
            {
                List<String> subEntries = new List<String>();

                String[] subDirectories = Directory.GetDirectories(basePath, "*", SearchOption.TopDirectoryOnly);

                String[] subImages = Directory.GetFiles(basePath, "*", SearchOption.TopDirectoryOnly);

                subEntries.AddRange(subDirectories);
                subEntries.AddRange(subImages);

                foreach (String subEntryPath in subEntries)
                {
                    TreeNode subItem = new TreeNode();

                    GetTreeView(subEntryPath, ref subItem, viewItem);
                }
            }
        }

        public static EntryType GetEntryType(String path)
        {
            FileAttributes attr = File.GetAttributes(path);

            return (attr & FileAttributes.Directory) == FileAttributes.Directory ? EntryType.Directory : EntryType.Image;
        }

        public static void GetCheckedItems(TreeNode sourceItem, List<TreeNode> checkedItems)
        {
            if (sourceItem.Visible)
            {
                checkedItems.Add(sourceItem);
            }

            foreach (TreeNode item in sourceItem.Items)
            {
                GetCheckedItems(item, checkedItems);
            }
        }

        public static void GetExpandedItems(TreeNode sourceItem, List<TreeNode> expandedItems)
        {
            if (!sourceItem.Visible)
            {
                return;
            }

            expandedItems.Add(sourceItem);
            foreach (TreeNode item in sourceItem.Items)
            {
                GetExpandedItems(item, expandedItems);
            }
        }

        public static Details GetDetails(String path, String searchPattern = null)
        {
            EntryType entryType = Helper.GetEntryType(path);

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
