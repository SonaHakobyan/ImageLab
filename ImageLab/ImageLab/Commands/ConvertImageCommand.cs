using ImageLab.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLab.Commands
{
    public class ConvertImageCommand : CommandBase
    {
        private MainViewModel vm;

        public ConvertImageCommand(MainViewModel vm)
        {
            this.vm = vm;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {

        }
    }
}
