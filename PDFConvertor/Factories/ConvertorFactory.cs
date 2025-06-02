using PDFConvertor.DTOs;
using PDFConvertor.DTOs.ConversionErrors;
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

        public ConversionResult ConvertFileToPdf(FileInputDTO fileInputDTO)
        {
            var result = new ConversionResult();
            switch (fileInputDTO.ConversionType)
            {
                case ConversionType.Image:
                    result = _imageConvertor.ConvertImagesToPdf(fileInputDTO);
                    break;
                case ConversionType.Html:
                    result = ConversionResult.Fail(ConversionErrorCode.UnknownError);
                    break;
                case ConversionType.Docx:
                    result = ConversionResult.Fail(ConversionErrorCode.UnknownError);
                    break;
            }
            return result;
        }
    }
}
