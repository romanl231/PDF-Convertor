using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFConvertor.DTOs.ConversionErrors
{
    public class ConversionResult
    {
        public bool IsSuccess { get; init; }
        public ConversionErrorCode? Error { get; init; }
        public PdfDocument? Document { get; init; }

        public static ConversionResult Success(PdfDocument document) => new()
        {
            IsSuccess = true,
            Document = document,
        };

        public static ConversionResult Fail(ConversionErrorCode error) => new()
        {
            IsSuccess = false,
            Error = error
        };

        public static ConversionResult Success() => new() { IsSuccess = true };
    }
}
