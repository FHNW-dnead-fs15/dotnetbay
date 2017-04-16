using DotNetBay.WPF.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DotNetBay.WPF.Command
{
    public sealed class AuctionCmd<T> : ICommand
    {
        public Action<T> ExecuteDelegate { get; set; }
        public Func<T, bool> CanExecuteDelegate { get; set; }
            
        #region ICommand Members

        public bool CanExecute(object parameter) {
            return CanExecuteDelegate((T)parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter) {
            ExecuteDelegate((T)parameter);
        }
            
        #endregion
    }
}
