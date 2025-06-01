using PDFConvertor.DTOs;
using PDFConvertor.DTOs.ConvertationErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFConvertor.Services.Interface
{
    public interface IConvertionService
    {
        ConvertationResult Convert(FileInputDTO dto);
    }
}
