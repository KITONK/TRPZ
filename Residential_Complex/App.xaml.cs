using System;
using System.Windows;
using ResidentialComplex.DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using AutoMapper;
using AutoMapper.Configuration;
using MessageBox = System.Windows.MessageBox;
using Microsoft.Extensions.DependencyInjection;
using ResidentialComplex.BusinessLayer.Services;
using ResidentialComplex.PresentationLayer;
using ResidentialComplex.BusinessLayer;
using ResidentialComplex.DataAccessLayer.Repositories;

namespace ResidentialComplex
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;

        public App()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider(validateScopes: true);

            ShutdownMode = ShutdownMode.OnMainWindowClose;
        }
        private void ConfigureServices(IServiceCollection services)
        {
            //services.AddSingleton<IOwnerRepository, OwnerRepository>();
            services.AddSingleton<IFlatRepository, FlatRepository>();
            services.AddSingleton<IHousingDepartamentRepository, HousingDepartamentRepository>();
            services.AddSingleton<IHouseRepository, HouseRepository>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton(GetTariffsMapper());
            //services.AddSingleton<IOwnerService, OwnerService>();
            services.AddSingleton<IHousingDepartamentService, HousingDepartamentService>();
            services.AddSingleton<IFlatService, FlatService>();
            services.AddSingleton<IHouseService, HouseService>();

            services.AddDbContext<HeadOfOSBBContext>(ServiceLifetime.Singleton);
        }

        private IMapper GetTariffsMapper()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperConfig());
            });
            return configuration.CreateMapper();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var viewModel = new ApplicationViewModel(serviceProvider.GetService<IHousingDepartamentService>(), 
                serviceProvider.GetService<IFlatService>(), serviceProvider.GetService<IHouseService>());
            MainWindow = new BusyFlat() { DataContext = viewModel };
            MainWindow.Show();
        }

        public static MessageBoxResult ShowMessage(string message, bool isQuestion = false)
        {
            if (string.IsNullOrEmpty(message) == true)
                throw new ArgumentException("Message cannot be empty");
            else if (isQuestion == true)
                return MessageBox.Show(message, "Підтвердіть дію", MessageBoxButton.YesNo, MessageBoxImage.Question);
            else
                return MessageBox.Show(message, "Повідомлення", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
