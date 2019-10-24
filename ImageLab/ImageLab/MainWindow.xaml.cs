using ImageLab.Enumerations;
using ImageLab.Models;
using ImageLab.ViewModels;
using System;
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
            (this.DataContext as MainViewModel).SelectedImage = string.Empty;

            if (e.NewValue is TreeNode node && node.EntryType == EntryType.Image)
            {
                String path = node.FullPath;
                String ext = Path.GetExtension(path);

                if (ext.ToLower() != ".bmp")
                {
                    path = Path.Combine(Path.GetDirectoryName(path), Path.GetFileNameWithoutExtension(path) + ".bmp");
                }

                if (File.Exists(path))
                {
                    (this.DataContext as MainViewModel).SelectedImage = path;
                }
            }
        }

        private void TreeView_Chnaged(object sender, RoutedEventArgs e)
        {
            (this.DataContext as MainViewModel).UpdateView();
        }
    }
}