using PDFConvertor.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFConvertor.Services.Interface
{
    public interface IFileDialogService
    {
        IEnumerable<string>? OpenFilesDialog(ConvertationType convertationType);
        string? OpenFolderDialog();
    }
}
