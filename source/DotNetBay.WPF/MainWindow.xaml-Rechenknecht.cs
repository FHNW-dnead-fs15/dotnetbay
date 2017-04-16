using DotNetBay.Core;
using DotNetBay.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    public partial class MainWindow : Window
    {
        readonly ObservableCollection<Auction> auctions;
        
        public ObservableCollection<Auction> Auctions
        {
            get { return this.auctions; }
        }

        public MainWindow()
        {
            DataContext = this;
            InitializeComponent();

            this.auctions = new ObservableCollection<Auction>();
            
            // WICHTIG! Name des Grids im XAML muss die Observable collection zugewiesen werden!
            AuctionGrid.ItemsSource = this.Auctions;

            var mainRepository = ((App)Application.Current).MainRepository; 
            var memberService = new SimpleMemberService(mainRepository); 
            var auctionService = new AuctionService(mainRepository, memberService);

            foreach (var auction in auctionService.GetAll())
            {
                this.auctions.Add(auction);
            }
        }
    }
}
