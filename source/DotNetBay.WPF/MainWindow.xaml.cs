using DotNetBay.Core;
using DotNetBay.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        // Bitte in Anleitung umbenennen
        public ObservableCollection<Auction> auctions = new ObservableCollection<Auction>();
        public ObservableCollection<Auction> Auctions
        {
            get 
            { 
                return this.auctions; 
            }

            set 
            { 
                this.auctions = value;
                this.OnPropertyChanged();
            }
        } 

        public MainWindow()
        {
            InitializeComponent();
            
            DataContext = this;

            var mainRepository = ((App)Application.Current).MainRepository;
            var memberService = new SimpleMemberService(mainRepository);
            var auctionService = new AuctionService(mainRepository, memberService);

            foreach (var auction in auctionService.GetAll()) {
                this.auctions.Add(auction);
            }
        }

        private void AddAuction_Click(object sender, RoutedEventArgs e)
        {
            var sellView = new SellView();
            sellView.ShowDialog();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) 
        { 
            var handler = this.PropertyChanged; 
            if (handler != null) 
            { 
                handler(this, new PropertyChangedEventArgs(propertyName)); 
            } 
        }
    }
}