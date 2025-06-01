using PDFConvertor.Services;
using System.Configuration;
using System.Data;
using System.Windows;
using PDFConvertor.ViewModels;

namespace PDFConvertor
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var imageConverter = new PdfSharpCoreConverter();
            var factory = new ConvertorFactory(imageConverter);
            var viewModel = new FileInputViewModel(factory);

            var window = new MainWindow
            {
                DataContext = viewModel
            };

            window.Show();
        }
    }

}
