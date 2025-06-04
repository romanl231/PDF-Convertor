using PDFConvertor.DTOs;
using PDFConvertor.DTOs.ConversionErrors;
using PDFConvertor.Services;
using PDFConvertor.Converters.Interfaces;
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
        public readonly IPdfSharpCoreConverter _imageConvertor;
        public readonly ISynfusionConverter _synfusionConverter;

        public ConvertorFactory(IPdfSharpCoreConverter imageConvertor, ISynfusionConverter synfusionConverter)
        {
            _imageConvertor = imageConvertor;
            _synfusionConverter = synfusionConverter;
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
                    result = ConversionResult.Fail(ConversionErrorCode.WillApearSoon);
                    break;
                case ConversionType.Docx:
                    result = _synfusionConverter.ConvertWordFilesToPdf(fileInputDTO);
                    break;
            }
            return result;
        }
    }
}
