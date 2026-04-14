using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMedicalGuide.Data.Entities
{
    public class Attachment
    {
        [Key]
        public int AttachmentId { get; set; }

        public int UserId { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedAt { get; set; }

    }
}
