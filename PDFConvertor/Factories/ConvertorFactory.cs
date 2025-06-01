using PDFConvertor.DTOs;
using PDFConvertor.DTOs.ConvertationErrors;
using PDFConvertor.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Diagnostics;

namespace PDFConvertor.Factories
{
    public class ConvertorFactory
    {
        public readonly PdfSharpCoreConverter _imageConvertor;

        public ConvertorFactory(PdfSharpCoreConverter imageConvertor)
        {
            _imageConvertor = imageConvertor;
        }

        public ConvertationResult ConvertFileToPdf(FileInputDTO fileInputDTO)
        {
            var result = new ConvertationResult();
            switch (fileInputDTO.ConvertationType)
            {
                case ConvertationType.Image:
                    result = _imageConvertor.ConvertImagesToPdf(fileInputDTO.FilePaths, fileInputDTO.OutputPath);
                    break;
                case ConvertationType.Html:
                    result = ConvertationResult.Fail(ConvertationErrorCode.UnknownError);
                    break;
                case ConvertationType.Docx:
                    result = ConvertationResult.Fail(ConvertationErrorCode.UnknownError);
                    break;
            }
            return result;
        }
    }
}
