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
using PDFConvertor.DTOs.ConversionErrors;
using System.IO;
using PDFConvertor.DTOs;


namespace PDFConvertor.Services
{
    public class PdfSharpCoreConverter
    {
        public PdfSharpCoreConverter() { }

        public ConversionResult ConvertImagesToPdf(FileInputDTO dto)
        {
            var document = new PdfDocument();
            if (dto.FilePaths == null || dto.FilePaths.Count == 0)
                return ConversionResult.Fail(ConversionErrorCode.EmptyImagePathList);

            var fullOutputPath = Path.Combine(dto.OutputPath, dto.FileName + ".pdf");

            if (File.Exists(fullOutputPath))
                return ConversionResult.Fail(ConversionErrorCode.NameOccupied);

            try
            {
                foreach (var filePath in dto.FilePaths)
                {
                    using var image = Image.Load<Rgba32>(filePath);
                    using var imageStream = new MemoryStream();

                    image.SaveAsPng(imageStream);
                    imageStream.Position = 0;

                    var pagePdf = document.AddPage();
                    var gfx = XGraphics.FromPdfPage(pagePdf);

                    using var xImage = XImage.FromStream(() => imageStream);

                    double widthRatio = pagePdf.Width / xImage.PixelWidth;
                    double heightRatio = pagePdf.Height / xImage.PixelHeight;
                    double scale = Math.Min(widthRatio, heightRatio);

                    double imgWidth = xImage.PixelWidth * scale;
                    double imgHeight = xImage.PixelHeight * scale;

                    double x = (pagePdf.Width - imgWidth) / 2;
                    double y = (pagePdf.Height - imgHeight) / 2;

                    gfx.DrawImage(xImage, x, y, imgWidth, imgHeight);
                }

                using var outputStream = new MemoryStream();
                document.Save(outputStream);
                File.WriteAllBytes(fullOutputPath, outputStream.ToArray());

                return ConversionResult.Success();
            }
            catch(Exception)
            {
                return ConversionResult.Fail(ConversionErrorCode.UnknownError);
            }
        }
    }
}
