using System;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using AutoMapper;
using AutoMapper.Configuration;
using MessageBox = System.Windows.MessageBox;
using Microsoft.Extensions.DependencyInjection;
using BusinessLayer.Implementation.Services;
using BusinessLayer.Abstract;
using BusinessLayer.Implementation;
using DataAccessLayer.Abstract;
using DataAccessLayer.Implementation.Repositories;
using DataAccessLayer.Implementation;
using PresentationLayer.View;
using PresentationLayer.ViewModels;

namespace PresentationLayer
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
            services.AddSingleton<IFlatRepository, FlatRepository>();
            services.AddSingleton<IHousingDepartamentRepository, HousingDepartamentRepository>();
            services.AddSingleton<IHouseTypeRepository, HouseTypeRepository>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton(GetTariffsMapper());//при первом запросе создается и будет сущестовать напротяжении всей жизни апликейшена
            services.AddTransient<IHousingDepartamentService, HousingDepartamentService>();//возможность работы с моделью, и поэтому не нужно их хранить
            services.AddTransient<IFlatService, FlatService>();                            // в памяти долго, и для каждого обращения контейнер создает новый экземпляр
            services.AddTransient<IHouseTypeService, HouseTypeService>();

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

            //для того, чтобы передать их во вью модел 
            var viewModel = new ApplicationViewModel(serviceProvider.GetService<IHousingDepartamentService>(), 
                serviceProvider.GetService<IFlatService>(), serviceProvider.GetService<IHouseTypeService>());
            MainWindow = new BusyFlat() { DataContext = viewModel };
            MainWindow.Show();
        }

        public static MessageBoxResult ShowMessage(string message, bool isQuestion = false)
        {
            if (string.IsNullOrEmpty(message) == true)
                throw new ArgumentException("Message cannot be empty");
            else if (isQuestion == true)
                return MessageBox.Show(message, "Подтвердите действие", MessageBoxButton.YesNo, MessageBoxImage.Question);
            else
                return MessageBox.Show(message, "Сообщение", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
