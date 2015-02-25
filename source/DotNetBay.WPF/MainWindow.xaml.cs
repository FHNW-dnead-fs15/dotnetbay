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
using DotNetBay.Core;
using DotNetBay.Model;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Auction> auctions;

        private String test = "TestString";

        public String Test
        {
            get { return this.test; }
        }

        public ObservableCollection<Auction> Auctions
        {
            get { return this.auctions; }
        }

        public MainWindow()
        {
            this.InitializeComponent();

            var mainRepository = ((App) Application.Current).MainRepository;

            var memberService = new SimpleMemberService(mainRepository);
            var service = new AuctionService(mainRepository, memberService);

            this.auctions = new ObservableCollection<Auction>(service.GetAll());

            this.DataContext = this;
        }

        private void BuyAction(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}