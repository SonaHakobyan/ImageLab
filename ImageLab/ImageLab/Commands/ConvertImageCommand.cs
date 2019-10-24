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
        private IFormatConverter converter;

        public ConvertImageCommand(MainViewModel vm)
        {
            this.vm = vm;
        }

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
            if (parameter is Format format)
            {
                switch (format)
                {
                    case Format.PNG:
                        converter = new PngConverter();
                        break;
                    case Format.NAT:
                        converter = new NatConverter();
                        break;
                    case Format.Unknown:
                        throw new Exception("Unknown Format");
                    default:
                        break;
                }

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
        }
    }
}
