namespace SmartMedicalGuide.Data.AppMetaData
{
    public static class Router
    {
        public const string SingleRoute = "{id}";
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";

        public static class PatientRouting
        {
            public const string Prefix = Rule + "Patient/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
        }
        public static class DoctorRouting
        {
            public const string Prefix = Rule + "Doctor/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
        }
    }
}
