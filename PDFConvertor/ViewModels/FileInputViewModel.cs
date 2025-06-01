using PDFConvertor.Commands;
using PDFConvertor.DTOs;
using PDFConvertor.Factories;
using PDFConvertor.Services.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PDFConvertor.ViewModels
{
    public class FileInputViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<string> SelectedFilePaths { get; set; } = new();
        public string OutPutPath { get; set; } = string.Empty;
        private ConvertationType _selectedConvertationType = ConvertationType.Image;
        public ConvertationType SelectedConvertationType
        {
            get => _selectedConvertationType;
            set
            {
                if (_selectedConvertationType != value)
                {
                    _selectedConvertationType = value;
                    OnPropertyChanged(nameof(SelectedConvertationType));
                }
            }
        }

        public ICommand ConvertCommand { get; }
        public ICommand BrowseCommand { get; }
        public ICommand BrowsePath { get; }

        private readonly IConvertionService _convertionService;
        private readonly IFileDialogService _dialogService;

        public string StatusMessage { get; set; } = string.Empty;

        public FileInputViewModel(IConvertionService convertionService, IFileDialogService dialogService)
        {
            _dialogService = dialogService;
            _convertionService = convertionService;
            ConvertCommand = new RelayCommand(Convert);
            BrowseCommand = new RelayCommand(BrowseFiles);
            BrowsePath = new RelayCommand(BrowseFile);
        }

        private void Convert()
        {
            var dto = new FileInputDTO
            {
                FilePaths = SelectedFilePaths.ToList(),
                OutputPath = OutPutPath,
                ConvertationType = SelectedConvertationType,
            };

            var result = _convertionService.Convert(dto);
            StatusMessage = result.IsSuccess ? "File successfully created!" 
                : $"An error occurred {result.Error}";

            OnPropertyChanged(nameof(StatusMessage));
        }

        private void BrowseFiles()
        {
            var files = _dialogService.OpenFilesDialog();

            if (files != null)
            {
                foreach (var path in files)
                {
                    SelectedFilePaths.Add(path);
                }

                OnPropertyChanged(nameof(SelectedFilePaths));
            }
        }

        private void BrowseFile()
        {
            var folder = _dialogService.OpenFolderDialog();

            if (folder != null)
            {
                OutPutPath = folder;
                OnPropertyChanged(nameof(OutPutPath));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public IEnumerable<ConvertationType> ConvertationTypes =>
            Enum.GetValues(typeof(ConvertationType)).Cast<ConvertationType>();
    }
}
