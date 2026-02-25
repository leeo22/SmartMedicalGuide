namespace SmartMedicalGuide.Data.AppMetaData
{
    public static class Router
    {
        public const string SingleRoute = "{id}";
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";

        public static class RoleRouting
        {
            public const string Prefix = Rule + "Role/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";

        }
        public static class PatientRouting
        {
            public const string Prefix = Rule + "Patient/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";
        }
        public static class DoctorRouting
        {
            public const string Prefix = Rule + "Doctor/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class LabRouting
        {
            public const string Prefix = Rule + "Lab/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class ClinicRouting
        {
            public const string Prefix = Rule + "Clinic/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class DoctorAppointmentRouting
        {
            public const string Prefix = Rule + "DoctorAppointment/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class LabAppointmentRouting
        {
            public const string Prefix = Rule + "LabAppointment/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }

        public static class UserRouting
        {
            public const string Prefix = Rule + "User/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class PaymentRouting
        {
            public const string Prefix = Rule + "Payment/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";
        }

    }
}
