using ImageLab.Enumerations;
using ImageLab.Models;
using ImageLab.Services;
using ImageLab.ViewModels;
using System;
using System.IO;

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

                if (string.IsNullOrEmpty(vm.SelectedPath))
                {
                    return;
                }

                var paths = new string[] { vm.SelectedPath };

                if ((File.GetAttributes(vm.SelectedPath) & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    paths = Directory.GetFiles(vm.SelectedPath, "*.bmp", SearchOption.AllDirectories);
                }

                foreach (var path in paths)
                {
                    var succeed = converter.Convert(path);
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
}
