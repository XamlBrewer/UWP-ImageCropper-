using Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Mvvm
{
    class MenuItem : BindableBase
    {
        private string glyph;
        private string text;
        private DelegateCommand command;
        private Type navigationDestination;

        public string Glyph
        {
            get { return glyph; }
            set { SetProperty(ref glyph, value); }
        }

        public string Text
        {
            get { return text; }
            set { SetProperty(ref text, value); }
        }

        public ICommand Command
        {
            get { return command; }
            set { SetProperty(ref command, (DelegateCommand)value); }
        }

        public Type NavigationDestination
        {
            get { return navigationDestination; }
            set { SetProperty(ref navigationDestination, value); }
        }

        public bool IsNavigation
        {
            get { return navigationDestination != null; }
        }
    }
}
