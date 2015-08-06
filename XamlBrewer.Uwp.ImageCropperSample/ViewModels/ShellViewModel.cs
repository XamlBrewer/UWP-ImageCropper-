using Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamlBrewer.Uwp.ImageCropperSample;

namespace Mvvm
{
    class ShellViewModel : ViewModelBase
    {
        public ShellViewModel()
        {
            // Build the menu
            Menu.Add(new MenuItem() { Glyph = "\uEA3A", Text = "Native", NavigationDestination = typeof(MainPage) });
            Menu.Add(new MenuItem() { Glyph = "\uE2B1", Text = "Templated", NavigationDestination = typeof(TemplatePage) });
            Menu.Add(new MenuItem() { Glyph = "\uE114", Text = "Camera", NavigationDestination = typeof(CameraPage) });
        }
    }
}
