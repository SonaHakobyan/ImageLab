using ImageLab.ViewModels;
using System.Windows.Forms;

namespace ImageLab.Commands
{
    public class SelectOptionCommand : CommandBase
    {
        private string path;
        private MainViewModel vm;

        public SelectOptionCommand(MainViewModel vm)
        {
            this.vm = vm;
            path = @"C:\Users\hakob\ImageLabResources";
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            var dialog = new FolderBrowserDialog();
            dialog.SelectedPath = path;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                vm.RootPath = dialog.SelectedPath;
                vm.UpdateTreeView();
            }
        }
    }
}