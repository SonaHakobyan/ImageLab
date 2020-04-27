using ImageLab.ViewModels;
using System.Windows.Forms;

namespace ImageLab.Commands
{
    public class SelectOptionCommand : CommandBase
    {
        private string defaultPath;
        private MainViewModel vm;

        public SelectOptionCommand(MainViewModel vm)
        {
            this.vm = vm;
            this.defaultPath = @"C:\Users\sona.hakobyan\source\repos\NAT\ImageSamples";
            this.vm.RootPath = Properties.Settings.Default.DirectoryPath;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            var dialog = new FolderBrowserDialog();
            dialog.SelectedPath = defaultPath;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                vm.RootPath = dialog.SelectedPath;
                vm.LoadView();

                Properties.Settings.Default.DirectoryPath = dialog.SelectedPath;
                Properties.Settings.Default.Save();
            }
        }
    }
}