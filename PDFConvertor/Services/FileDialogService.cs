using PDFConvertor.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFConvertor.Services
{
    public class FileDialogService : IFileDialogService
    {
        private const string _fileTypes = "Image files " +
            "(*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tiff)|" +
            "*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tiff";

        public IEnumerable<string>? OpenFilesDialog()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Multiselect = true,
                Filter = _fileTypes,
            };

            return dialog.ShowDialog() == true ? dialog.FileNames : null;
        }

        public string? OpenFolderDialog()
        {
            var dialog = new Microsoft.Win32.OpenFolderDialog
            {
                Multiselect = true,
            };

            return dialog.ShowDialog() == true ? dialog.FolderName : null;
        }
    }
}
