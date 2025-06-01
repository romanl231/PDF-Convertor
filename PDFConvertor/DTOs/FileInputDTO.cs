using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFConvertor.DTOs
{
    public class FileInputDTO
    {
        public List<string> FilePaths { get; set; } = new List<string>();
        public string OutputPath {  get; set; } = string.Empty;
        public ConvertationType ConvertationType { get; set; }
    }
}
