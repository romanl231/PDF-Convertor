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
        public string FileName { get; set; } = "convertedToPDF";
        private ConversionType _selectedConversionType = ConversionType.Image;
        public ConversionType SelectedConversionType
        {
            get => _selectedConversionType;
            set
            {
                if (_selectedConversionType != value)
                {
                    _selectedConversionType = value;
                    OnPropertyChanged(nameof(SelectedConversionType));
                }
            }
        }

        public ICommand ConvertCommand { get; }
        public ICommand BrowseCommand { get; }
        public ICommand BrowseFolderPath { get; }
        public ICommand DeletePath {  get; }
        public ICommand ClearPaths { get; }
        public ICommand BrowseName { get; }

        private readonly IConversionService _conversionService;
        private readonly IFileDialogService _dialogService;

        public string StatusMessage { get; set; } = string.Empty;

        public FileInputViewModel(IConversionService conversionService, IFileDialogService dialogService)
        {
            _dialogService = dialogService;
            _conversionService = conversionService;
            ConvertCommand = new RelayCommand(Convert);
            BrowseCommand = new RelayCommand(BrowseFiles);
            BrowseFolderPath = new RelayCommand(BrowseFolder);
            ClearPaths = new RelayCommand(ClearChoosenPaths);
            DeletePath = new RelayCommand(param => DeleteFilePath((string)param));
        }

        private void Convert()
        {
            var dto = new FileInputDTO
            {
                FilePaths = SelectedFilePaths.ToList(),
                OutputPath = OutPutPath,
                ConversionType = SelectedConversionType,
                FileName = FileName,
            };

            var result = _conversionService.Convert(dto);
            StatusMessage = result.IsSuccess ? "File successfully created!" 
                : $"An error occurred {result.Error}";

            OnPropertyChanged(nameof(StatusMessage));
        }

        private void BrowseFiles()
        {
            var files = _dialogService.OpenFilesDialog(SelectedConversionType);

            if (files != null)
            {
                foreach (var path in files)
                {
                    SelectedFilePaths.Add(path);
                }

                OnPropertyChanged(nameof(SelectedFilePaths));
            }
        }

        private void BrowseFolder()
        {
            var folder = _dialogService.OpenFolderDialog();

            if (folder != null)
            {
                OutPutPath = folder;
                OnPropertyChanged(nameof(OutPutPath));
            }
        }

        private void DeleteFilePath(string filePath)
        {
            if (filePath != null)
                SelectedFilePaths.Remove(filePath);
        }

        private void ClearChoosenPaths() 
        {
            SelectedFilePaths.Clear();
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name) => 
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public IEnumerable<ConversionType> ConversionTypes =>
            Enum.GetValues(typeof(ConversionType)).Cast<ConversionType>();
    }
}
