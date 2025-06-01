using PDFConvertor.DTOs;
using PDFConvertor.DTOs.ConvertationErrors;
using PDFConvertor.Factories;
using PDFConvertor.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFConvertor.Services
{
    public class ConvertionService : IConvertionService
    {
        private readonly ConvertorFactory _convertorFactory;

        public ConvertionService(ConvertorFactory convertorFactory)
        {
            _convertorFactory = convertorFactory;
        }

        public ConvertationResult Convert(FileInputDTO dto)
        {
            var result = _convertorFactory.ConvertFileToPdf(dto);
            return result;
        }
    }
}
