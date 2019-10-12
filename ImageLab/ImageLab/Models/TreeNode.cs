using ImageLab.Enumerations;
using System;
using System.Collections.ObjectModel;

namespace ImageLab.Models
{
    public class TreeNode
    {
        public TreeNode()
        {
            Items = new ObservableCollection<TreeNode>();
        }

        public Boolean IsVisible { get; set; }
        public String Name { get; set; }
        public EntryType EntryType { get; set; }

        public String FullPath { get; set; }

        public ObservableCollection<TreeNode> Items { get; set; }
    }
}
