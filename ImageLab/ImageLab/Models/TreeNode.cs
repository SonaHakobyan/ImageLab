using ImageLab.Enumerations;
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
        public bool Visible
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
        public string FullPath { get; set; }
        public string Name { get; set; }
        public int Id { get; private set; }

        public static int id;
        public bool visible;
    }
}
