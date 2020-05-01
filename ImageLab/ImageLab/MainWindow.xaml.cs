using ImageLab.Enumerations;
using ImageLab.Models;
using ImageLab.ViewModels;
using System.IO;
using System.Windows;

namespace ImageLab
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            (this.DataContext as MainViewModel).SelectedPath = string.Empty;

            if (e.NewValue is TreeNode node)
            {
                var path = node.FullPath;

                if (node.EntryType == EntryType.Image && Path.GetExtension(path).ToLower() != ".bmp")
                {
                    path = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + ".bmp");
                }

                if (File.Exists(path) || Directory.Exists(path))
                {
                    (this.DataContext as MainViewModel).SelectedPath = path;
                }
            }

        }

        private void TreeView_Chnaged(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MainViewModel).UpdateView();
        }
    }
}