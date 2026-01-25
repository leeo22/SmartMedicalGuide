using System.ComponentModel.DataAnnotations;

namespace SmartMedicalGuide.Data.Entities
{
    public class SystemSetting
    {
        [Key]
        public int SettingId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }

}
