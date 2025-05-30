using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using PdfSharpCore.Utils;
using PDFConvertor.DTOs.ConvertationErrors;


namespace PDFConvertor.Services
{
    internal class PdfSharpCoreService
    {
        public PdfSharpCoreService() { }

        public ConvertationResult ConvertImagesToPdf()
        {
            return ConvertationResult.Success();
        }
    }
}
