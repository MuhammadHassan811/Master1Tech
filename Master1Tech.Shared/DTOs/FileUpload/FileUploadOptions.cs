using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master1Tech.Shared.DTOs.FileUpload
{
    public class FileUploadOptions
    {
        public string UploadPath { get; set; } = "uploads";
        public long MaxFileSize { get; set; } = 10 * 1024 * 1024; // 10MB
        public string[] AllowedExtensions { get; set; } = { ".jpg", ".jpeg", ".png", ".pdf", ".doc", ".docx" };
    }
}
