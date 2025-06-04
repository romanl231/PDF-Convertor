using PDFConvertor.DTOs.ConversionErrors;
using PDFConvertor.Converters.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PDFConvertor.DTOs;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocIORenderer;
using System.IO;

namespace PDFConvertor.Converters
{
    public class SyncfusionConverter : ISynfusionConverter
    {
        public SyncfusionConverter() { }

        public ConversionResult ConvertWordFilesToPdf(FileInputDTO dto)
        {
            foreach (var path in dto.FilePaths)
            {
                try
                {
                    var outputPath = CombinePath(dto.FileName, dto.OutputPath);
                    switch (Path.GetExtension(path).ToLowerInvariant())
                    {
                        case ".docx":
                            ConvertToPdf(path, outputPath, Syncfusion.DocIO.FormatType.Docx);
                            break;
                        case ".doc":
                            ConvertToPdf(path, outputPath, Syncfusion.DocIO.FormatType.Doc);
                            break;
                        default:
                            continue;
                    }
                }
                catch (Exception)
                {
                    return ConversionResult.Fail(ConversionErrorCode.UnknownError);
                }
            }

            return ConversionResult.Success();
        }

        public string CombinePath(string name, string outputPath)
        {
            var safeTimestamp = DateTime.UtcNow.ToString("yyyyMMdd_HHmmss");
            return Path.Combine(outputPath, $"{name}_{safeTimestamp}.pdf");
        }

        public void ConvertToPdf(string inputWordPath, string outputWordPath, Syncfusion.DocIO.FormatType format)
        {
            using var document = new WordDocument(inputWordPath, format);

            using var renderer = new DocIORenderer();
            using var pdfDoc = renderer.ConvertToPDF(document);

            pdfDoc.Save(outputWordPath);
        }
    }
}
