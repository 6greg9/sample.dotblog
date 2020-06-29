using System;
using System.IO;
using Lab.Infra;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void �z�LAppSetting����Ū���]�w��()
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json");
            var config = builder.Build();

            var appSetting = AppSetting.Get(config);
            Console.WriteLine($"AppId = {appSetting.Player.AppId}");
            Console.WriteLine($"Key = {appSetting.Player.Key}");
            Console.WriteLine($"Connection String = {appSetting.ConnectionStrings.DefaultConnectionString}");
        }

        [TestMethod]
        public void �z�LAppSetting����Ū���]�w��_�Ϭq���s�b�ߥX�ҥ~()
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json");
            var config = builder.Build();

            var appSetting = AppSetting.GetIfNoSectionThrow(config);
            Console.WriteLine($"AppId = {appSetting.Player.AppId}");
            Console.WriteLine($"Key = {appSetting.Player.Key}");
            Console.WriteLine($"Connection String = {appSetting.ConnectionStrings.DefaultConnectionString}");
        }

        [TestMethod]
        public void �j�w�]�w_�X�R��k_Get()
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json");
            var config     = builder.Build();
            var player = config.GetSection("Player").Get<Player>();
            Console.WriteLine($"AppId = {player.AppId}");
            Console.WriteLine($"Key = {player.Key}");
        }

        [TestMethod]
        public void �j�w�]�w_�X�R��k_Bind()
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json");
            var config     = builder.Build();
            var appSetting = new AppSetting();
            config.Bind(appSetting);
            Console.WriteLine($"AppId = {appSetting.Player.AppId}");
            Console.WriteLine($"Key = {appSetting.Player.Key}");
            Console.WriteLine($"Connection String = {appSetting.ConnectionStrings.DefaultConnectionString}");
        }

        [TestMethod]
        public void Ū���]�w��()
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json");
            var config = builder.Build();

            Console.WriteLine($"AppId = {config["AppId"]}");
            Console.WriteLine($"AppId = {config["Player:AppId"]}");
            Console.WriteLine($"Key = {config["Player:Key"]}");
            Console.WriteLine($"Connection String = {config["ConnectionStrings:DefaultConnectionString"]}");
        }

        [TestMethod]
        public void Ū���]�w��_GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json");
            var config = builder.Build();
            var connectionString = config.GetConnectionString("DefaultConnection");

            //var dbContextOptions = new DbContextOptionsBuilder<LabEmployeeContext>()
            //                       .UseSqlServer(connectionString)
            //                       .Options;
        }

        [TestMethod]
        public void Ū���]�w��_TryGet()
        {
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json");
            var config = builder.Build();

            //TryGet
            foreach (var provider in config.Providers)
            {
                provider.TryGet("Player:AppId", out var value);
                Console.WriteLine($"AppId = {value}");
            }
        }
    }
}