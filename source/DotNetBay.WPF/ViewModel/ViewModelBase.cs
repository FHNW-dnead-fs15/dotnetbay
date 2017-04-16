using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DotNetBay.WPF.Command;

namespace DotNetBay.WPF.ViewModel
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public AuctionCmd<Window> CloseWindowCommand { get; private set; }

        public ViewModelBase()
        {
            this.CloseWindowCommand = new AuctionCmd<Window>();
            this.CloseWindowCommand.ExecuteDelegate = this.CloseWindow;
            this.CloseWindowCommand.CanExecuteDelegate = (o) => true; 
        }

        private void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
        protected void NotifyPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
    }
}
