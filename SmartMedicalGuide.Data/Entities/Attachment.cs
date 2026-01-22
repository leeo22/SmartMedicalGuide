namespace SmartMedicalGuide.Data.Entities
{
    public class Attachment
    {
        public int AttachmentID { get; set; }
        public string FilePath { get; set; }
        public string FileType { get; set; }
        public DateTime UploadedAt { get; set; }

        public int MessageID { get; set; }
        public Message Message { get; set; }
    }


}
