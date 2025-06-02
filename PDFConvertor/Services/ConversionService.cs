using PDFConvertor.DTOs;
using PDFConvertor.DTOs.ConversionErrors;
using PDFConvertor.Factories;
using PDFConvertor.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFConvertor.Services
{
    public class ConversionService : IConversionService
    {
        private readonly ConvertorFactory _convertorFactory;

        public ConversionService(ConvertorFactory convertorFactory)
        {
            _convertorFactory = convertorFactory;
        }

        public ConversionResult Convert(FileInputDTO dto)
        {
            var result = _convertorFactory.ConvertFileToPdf(dto);
            return result;
        }
    }
}
