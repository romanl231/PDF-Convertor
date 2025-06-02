using PDFConvertor.DTOs;
using PDFConvertor.DTOs.ConversionErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFConvertor.Services.Interface
{
    public interface IConversionService
    {
        ConversionResult Convert(FileInputDTO dto);
    }
}
