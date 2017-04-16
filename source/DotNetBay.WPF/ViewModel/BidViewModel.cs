using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetBay.WPF.ViewModel
{
    class BidViewModel : ViewModelBase
    {

        private string _title;
        private string _description;
        private string _startPrice;
        private string _currentPrice;
        private string _yourBid;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                NotifyPropertyChanged("Title");
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                NotifyPropertyChanged("Description");
            }
        }

        public string StartPrice
        {
            get { return _startPrice; }
            set
            {
                _startPrice = value;
                NotifyPropertyChanged("StartPrice");
            }
        }

        public string CurrentPrice
        {
            get { return _currentPrice; }
            set
            {
                _currentPrice = value;
                NotifyPropertyChanged("CurrentPrice");
            }
        }

        public string YourBid
        {
            get { return _yourBid; }
            set
            {
                _yourBid = value;
                NotifyPropertyChanged("YourBid");
            }
        }

    }
}
