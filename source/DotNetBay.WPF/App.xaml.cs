using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DotNetBay.Core;
using DotNetBay.Core.Execution;
using DotNetBay.Data.FileStorage;
using DotNetBay.Interfaces;
using DotNetBay.Model;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IMainRepository mainRepository;

        public IMainRepository MainRepository
        {
            get { return this.mainRepository; }
        }

        private readonly AuctionRunner auctionRunner;

        public IAuctionRunner AuctionRunner
        {
            get { return this.auctionRunner; }
        }

        public App()
        {
            this.mainRepository = new FileSystemMainRepository("Main Repository");
            this.auctionRunner = new AuctionRunner(this.mainRepository);
            this.auctionRunner.Start();
            this.InitDemoData();    
        }

        private void InitDemoData()
        {
            var memberService = new SimpleMemberService(this.mainRepository);
            var service = new AuctionService(this.mainRepository, memberService);
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

                service.Save(new Auction
                {
                    Title = "My Second Auction",
                    StartDateTimeUtc = DateTime.UtcNow.AddSeconds(10),
                    EndDateTimeUtc = DateTime.UtcNow.AddDays(14),
                    StartPrice = 72,
                    Seller = me
                });

                service.Save(new Auction
                {
                    Title = "My Third Auction",
                    StartDateTimeUtc = DateTime.UtcNow.AddSeconds(10),
                    EndDateTimeUtc = DateTime.UtcNow.AddDays(14),
                    StartPrice = 72,
                    Seller = me
                });
            }
        }
    }
}