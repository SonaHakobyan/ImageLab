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
            Id = id;
            ++id;
        }

        public ObservableCollection<TreeNode> Items { get; set; }

        public EntryType EntryType { get; set; }
        public Boolean Visible
        {
            get { return visible; }
            set
            {
                foreach (TreeNode item in Items)
                {
                    item.visible = value; 
                }
                if (value) { visible = value; }
            }
        }
        public String FullPath { get; set; }
        public String Name { get; set; }
        public Int32 Id { get; private set; }

        public static Int32 id;
        public Boolean visible;
    }
}
