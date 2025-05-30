using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFConvertor.DTOs
{
    internal class FileInputDTO
    {
        public string FilePath { get; set; } = string.Empty;
        public string OutputPath {  get; set; } = string.Empty;
    }
}
