using ImageLab.Enumerations;
using ImageLab.Services;
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
        private IConverter converter;

        public ConvertImageCommand(MainViewModel vm)
        {
            this.vm = vm;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            if (parameter is Format format)
            {
                if (format == Format.Png)
                {
                    converter = new PngConverter();
                    Boolean succeed = converter.Convert(vm.SelectedImage);
                }
                else
                {
                    throw new Exception();
                }
            }           
        }
    }
}
