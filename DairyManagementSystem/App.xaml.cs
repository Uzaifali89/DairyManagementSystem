using DMS.DataEntities;
using DMS.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConfigurationManager = DairyManagementSystem.ConfigurationManager;
using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using static Org.BouncyCastle.Math.EC.ECCurve;
using static System.Net.WebRequestMethods;
using DMS.Services.Services;
using DairyManagementSystem.Forms;

namespace DairyManagementSystem
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IConfiguration _configuration { get; set; }
        private IServiceProvider serviceProvider;

        public App()
        {
            ConfigureServices();
        }
        //public App()
        //{

        //}

        private void ConfigureServices()
        {
            //builder.Logging.ClearProviders();
            //builder.Logging.AddConsole();
            var connectionString = @"Data Source=azhon.koreasouth.cloudapp.azure.com;Initial Catalog=DMS; User Id=azhon; Password=azhon@2020; Encrypt = false";
            var serviceCollection = new ServiceCollection();
            var config = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
          .Build();

            serviceCollection.AddDbContext<DMSDBContext>(options =>
            {
                var provider = "SQL";
                if (provider == Provider.Postgres.Name)
                {
                    options.UseNpgsql(
                        _configuration.GetConnectionString(Provider.Postgres.Name)!,
                        x => x.MigrationsAssembly(Provider.Postgres.Assembly)
                    );
                }
                if (provider == Provider.SQL.Name)
                {
                    options.UseSqlServer(
                        connectionString,
                        x => x.MigrationsAssembly(Provider.SQL.Assembly)
                    );
                }
            });
            serviceCollection.Configure<AppSettings>(myOptions =>
            {
                myOptions.Secret = "bd1a1ccf8095037f361a4d351e7c0de65f0776bfc2f478ea8d312c763bb6caca";
                myOptions.RefreshTokenTTL = 2;
                myOptions.AppUrl = "http://localhost:3000/auth/reset-password";
            });

            //_services.Configure<AppSettings>(config.GetSection("AppSettings"));
            // Register the service from the DLL and its implementation.
            serviceCollection.AddOptions();
            serviceCollection.AddDbContext<DMSDBContext>();
            serviceCollection.AddScoped<IUserService, UserService>();
            serviceCollection.AddMyExtensions(config).AddScoped<IJwtUtils, JwtUtils>();
            serviceCollection.AddScoped<IMilkCollectionService, MilkCollectionService>();
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //_configuration = new ConfigurationBuilder()
            //.SetBasePath(Directory.GetCurrentDirectory())
            //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            //.Build();
            // Create your WPF window and inject the service.
            var user = serviceProvider.GetRequiredService<IUserService>();
            var mainWindow = new MainWindow(user);
            
            mainWindow.Show();
        }
    }

}
