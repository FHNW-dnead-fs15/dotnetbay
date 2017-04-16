using System; 
using System.ComponentModel; 
using System.IO; 
using System.Runtime.CompilerServices; 
using System.Windows; 
using DotNetBay.Core; 
using DotNetBay.Model; 
using Microsoft.Win32; 

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for SellView.xaml
    /// </summary>
    public partial class SellView : Window
    {
        private readonly AuctionService auctionService;
        private readonly Auction newAuction;
        public event PropertyChangedEventHandler PropertyChanged;

        public Auction NewAuction
        {
            get { return newAuction; }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        } 

        public SellView()
        {
            InitializeComponent();

            this.DataContext = this;

            var app = Application.Current as App;

            var simpleMemberService = new SimpleMemberService(app.MainRepository); 
            this.auctionService = new AuctionService(app.MainRepository, simpleMemberService); 

            this.newAuction = new Auction()
            { 
                Seller = simpleMemberService.GetCurrentMember(),
                StartDateTimeUtc = DateTime.UtcNow, 
                EndDateTimeUtc = DateTime.UtcNow.AddDays(7) 
            };
        }

        private void AddAuctionClick(object sender, RoutedEventArgs e)
        {
            this.auctionService.Save(this.newAuction);
            this.Close();
        }

        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "image files (*.jpg)|*.jpg|(*.bmp)|*.bmp|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                var path = openFileDialog.FileName;
                txt_image.Text = path;
            }
        }
    }
}