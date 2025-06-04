using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PDFConvertor.Factories;
using PDFConvertor.Services;
using PDFConvertor.Services.Interface;
using PDFConvertor.ViewModels;
using Syncfusion.Licensing;
using System.Configuration;
using System.Data;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using PDFConvertor.Converters.Interfaces;
using PDFConvertor.Converters;

namespace PDFConvertor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    ConfigureServices(services);
                })
                .Build();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ConvertorFactory>();
            services.AddSingleton<IFileDialogService, FileDialogService>();
            services.AddSingleton<IConversionService, ConversionService>();
            services.AddSingleton<IPdfSharpCoreConverter, PdfSharpCoreConverter>();
            services.AddSingleton<ISynfusionConverter, SyncfusionConverter>();

            services.AddSingleton<FileInputViewModel>();
            services.AddSingleton<MainWindow>();

            string licenseKey = LoadLicenseKey();
            SyncfusionLicenseProvider.RegisterLicense(licenseKey);
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            await AppHost.StartAsync();
            var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
            mainWindow.Show();

            base.OnStartup(e);
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await AppHost.StopAsync();
            base.OnExit(e);
        }

        private string LoadLicenseKey()
        {
#if DEBUG
            string devPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "license.Development.txt");
            if (File.Exists(devPath))
                return File.ReadAllText(devPath).Trim();
#endif

            string prodPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "license.txt");
            if (File.Exists(prodPath))
                return File.ReadAllText(prodPath).Trim();

            throw new FileNotFoundException("No valid Syncfusion license key file found.");
        }
    }

}
