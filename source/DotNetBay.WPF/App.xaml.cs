using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using DotNetBay.Core;
using DotNetBay.Interfaces;
using DotNetBay.Data;
using DotNetBay.Data.FileStorage;
using DotNetBay.Core.Execution;
using DotNetBay.Model;

namespace DotNetBay.WPF
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        
        public App()
        {
            this.MainRepository = new FileSystemRepositoryFactory("store.json").CreateMainRepository();
            this.AuctionRunner = new AuctionRunner(this.MainRepository);
            this.AuctionRunner.Start();
            this.InitDemoAuctions();
        }

        public IMainRepository MainRepository
        {
            get; private set;
        }

        public IAuctionRunner AuctionRunner
        {
            get; private set;
        }

        private void InitDemoAuctions()
        {
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
