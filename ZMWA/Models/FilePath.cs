using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ZMWA.Models
{
    public class FilePath
    {
        public int FilePathId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }

        [FileExtensions(Extensions = "txt,doc,docx,pdf", ErrorMessage = "Please upload valid format")]
        public FileType FileType { get; set; }
        public int PostResumeID { get; set; }
        public virtual PostResume PostResume { get; set; }
    }
}