using PdfSharpCore.Pdf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFConvertor.DTOs.ConvertationErrors
{
    internal class ConvertationResult
    {
        public bool IsSuccess { get; init; }
        public ConvertationErrorCode? Error { get; init; }
        public PdfDocument? Document { get; init; }

        public static ConvertationResult Success(PdfDocument document) => new()
        {
            IsSuccess = true,
            Document = document,
        };

        public static ConvertationResult Fail(ConvertationErrorCode error) => new()
        {
            IsSuccess = false,
            Error = error
        };

        public static ConvertationResult Success() => new() { IsSuccess = true };
    }
}
