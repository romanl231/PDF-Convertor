using PDFConvertor.DTOs;
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
        private const string _imageTypes = "Image files " +
            "(*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tiff)|" +
            "*.png;*.jpg;*.jpeg;*.bmp;*.gif;*.tiff";
        private const string _docxTypes = "Word Documents (*.docx)|*.docx";
        private const string _htmlTypes = "HTML files (*.html;*.htm)|*.html;*.htm";

        public IEnumerable<string>? OpenFilesDialog(ConversionType convertationType)
        {
            switch (convertationType) {
                case ConversionType.Image:
                    return OpenImageDialog();
                case ConversionType.Html:
                    return OpenHTMLDialog();
                case ConversionType.Docx:
                    return OpenDocxDialog();
                default:
                    return null;
            }
            
        }

        public IEnumerable<string>? OpenImageDialog()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Multiselect = true,
                Filter = _imageTypes,
            };
            return dialog.ShowDialog() == true ? dialog.FileNames : null;
        }

        public IEnumerable<string>? OpenDocxDialog()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Multiselect = true,
                Filter = _docxTypes,
            };
            return dialog.ShowDialog() == true ? dialog.FileNames : null;
        }

        public IEnumerable<string>? OpenHTMLDialog()
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                Multiselect = true,
                Filter = _htmlTypes,
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
