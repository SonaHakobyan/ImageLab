using ImageLab.Enumerations;
using ImageLab.Models;
using ImageLab.Services;
using ImageLab.ViewModels;
using System;

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
                    if (succeed)
                    {
                        vm.UpdateView();
                    }
                    else
                    {
                        vm.ConvertionError = new ConvertionError { Format = format };
                    }
                }
                else
                {
                    throw new Exception();
                }
            }           
        }
    }
}
