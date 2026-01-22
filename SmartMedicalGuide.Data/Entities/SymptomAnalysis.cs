namespace SmartMedicalGuide.Data.Entities
{
    public class SymptomAnalysis
    {
        public int SymptomAnalysisID { get; set; }
        public string SymptomsText { get; set; }
        public string SuggestedSpecialty { get; set; }
        public DateTime CreatedAt { get; set; }

        public int PatientID { get; set; }
        public Patient Patient { get; set; }
    }


}
