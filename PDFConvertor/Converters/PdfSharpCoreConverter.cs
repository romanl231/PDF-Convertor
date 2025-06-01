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
using System.IO;


namespace PDFConvertor.Services
{
    public class PdfSharpCoreConverter
    {
        public PdfSharpCoreConverter() { }

        public ConvertationResult ConvertImagesToPdf(List<string> imagePaths, string outputPdfPath)
        {
            var document = new PdfDocument();
            if (imagePaths == null || imagePaths.Count == 0)
                return ConvertationResult.Fail(ConvertationErrorCode.EmptyImagePathList);

            try
            {
                foreach (var imagePath in imagePaths)
                {
                    using var image = Image.Load<Rgba32>(imagePath);
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
                File.WriteAllBytes($"{outputPdfPath}\\converted.pdf", outputStream.ToArray());

                return ConvertationResult.Success();
            }
            catch(Exception)
            {
                return ConvertationResult.Fail(ConvertationErrorCode.UnknownError);
            }
        }
    
    }
}
