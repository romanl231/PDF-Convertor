using PDFConvertor.Services;
using System.Configuration;
using System.Data;
using System.Windows;
using PDFConvertor.ViewModels;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using PDFConvertor.Factories;
using PDFConvertor.Services.Interface;
using System.Threading.Tasks;

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
            services.AddSingleton<IConvertionService, ConvertionService>();
            services.AddSingleton<PdfSharpCoreConverter>();

            services.AddSingleton<FileInputViewModel>();
            services.AddSingleton<MainWindow>();
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
    }

}
