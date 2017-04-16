using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DotNetBay.Interfaces;
using DotNetBay.Data.FileStorage;
using DotNetBay.Core;
using DotNetBay.Core.Execution;
using DotNetBay.Model;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IMainRepository mainRepository;
        private IAuctionRunner auctionRunner;

        public IMainRepository MainRepository
        {
            get { return this.mainRepository; }
            private set { mainRepository = value; }
        }

        public IAuctionRunner AuctionRunner
        {
            get { return this.auctionRunner; }
            private set { auctionRunner = value; }
        } 

        public App()
        {
            this.mainRepository = new FileSystemMainRepository("repo");
            this.auctionRunner = new AuctionRunner(mainRepository);
            this.auctionRunner.Start();

            var memberService = new SimpleMemberService(this.MainRepository);
            var service = new AuctionService(this.MainRepository, memberService);

            if (!service.GetAll().Any())
            {
                var me = memberService.GetCurrentMember();
                service.Save(new Auction
                {
                    Title = "My First Auction",
                    StartDateTimeUtc = DateTime.UtcNow.AddSeconds(10),
                    EndDateTimeUtc = DateTime.UtcNow.AddDays(14),
                    StartPrice = 72,
                    Seller = me
                });
            }
        }
    }
}
