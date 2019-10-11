using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLab.Commands
{
    public class SelectOptionsCommand : CommandBase
    {
        private string rootPath;

        public SelectOptionsCommand()
        {

        }

        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter)
        {
        }
    }
}
