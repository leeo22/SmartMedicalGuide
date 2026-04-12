namespace SmartMedicalGuide.Core.Features.SystemSettings.Queries.Results
{
    public class GetSingleSystemSettingResponse
    {
        public int SettingId { get; set; }
        public string KeyName { get; set; }
        public string Value { get; set; }
    }
}
