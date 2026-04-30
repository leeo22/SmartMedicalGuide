namespace SmartMedicalGuide.Data.AppMetaData
{
    public static class Router
    {
        public const string SingleRoute = "{id}";
        public const string NameRoute = "{name}";
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";

        public static class AppointmentHistoryRouting
        {
            public const string Prefix = Rule + "AppointmentHistory/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";


        }
        public static class Authentication
        {
            public const string Prefix = Rule + "Authentication";
            public const string SignIn = Prefix + "/SignIn";
            public const string RefreshToken = Prefix + "/Refresh-Token";
            public const string ValidateToken = Prefix + "/Validate-Token";
            public const string ConfirmEmail = "/Api/Authentication/ConfirmEmail";
            public const string SendResetPasswordCode = Prefix + "/SendResetPasswordCode";
            public const string ConfirmResetPasswordCode = Prefix + "/ConfirmResetPasswordCode";
            public const string ResetPassword = Prefix + "/ResetPassword";

        }
        public static class AuthorizationRouting
        {
            public const string Prefix = Rule + "AuthorizationRouting";
            public const string Roles = Prefix + "/Roles";
            public const string Claims = Prefix + "/Claims";
            public const string Create = Roles + "/Create";
            public const string Edit = Roles + "/Edit";
            public const string Delete = Roles + "/Delete/{id}";
            public const string RoleList = Roles + "/Role-List";
            public const string GetRoleById = Roles + "/Role-By-Id/{id}";
            public const string ManageUserRoles = Roles + "/Manage-User-Roles/{userId}";
            public const string ManageUserClaims = Claims + "/Manage-User-Claims/{userId}";
            public const string UpdateUserRoles = Roles + "/Update-User-Roles";
            public const string UpdateUserClaims = Claims + "/Update-User-Claims";
        }
        public static class AttachmentRouting
        {
            public const string Prefix = Rule + "Attachment/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class AuditLogRouting
        {
            public const string Prefix = Rule + "AuditLog/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class ChatRouting
        {
            public const string Prefix = Rule + "Chat/";
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
        public static class DoctorRouting
        {
            public const string Prefix = Rule + "Doctor/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string GetByName = Prefix + NameRoute;
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
        public static class DoctorScheduleRouting
        {
            public const string Prefix = Rule + "DoctorSchedule/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class FavoriteRouting
        {
            public const string Prefix = Rule + "Favorite/";
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
        public static class LabAppointmentRouting
        {
            public const string Prefix = Rule + "LabAppointment/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class LabServiceRouting
        {
            public const string Prefix = Rule + "LabService/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class MedicalReportRouting
        {
            public const string Prefix = Rule + "MedicalReport/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class MessageRouting
        {
            public const string Prefix = Rule + "Message/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class NotificationRouting
        {
            public const string Prefix = Rule + "Notification/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

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
        public static class PaymentRouting
        {
            public const string Prefix = Rule + "Payment/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";
        }
        public static class PrescriptionRouting
        {
            public const string Prefix = Rule + "Prescription/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class PrescriptionItemRouting
        {
            public const string Prefix = Rule + "PrescriptionItem/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class ReportRouting
        {
            public const string Prefix = Rule + "Specialization/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string GetByName = Prefix + NameRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class ReviewRouting
        {
            public const string Prefix = Rule + "Review/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }


        public static class RoleRouting
        {
            public const string Prefix = Rule + "Role/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";

        }
        public static class SearchHistoryRouting
        {
            public const string Prefix = Rule + "SearchHistory/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class SpecializationRouting
        {
            public const string Prefix = Rule + "Specialization/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string GetByName = Prefix + NameRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }


        public static class SystemSetting
        {
            public const string Prefix = Rule + "SystemSetting/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string GetByName = Prefix + NameRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class TransactionRouting
        {
            public const string Prefix = Rule + "Transaction/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class UserRefreshTokenRouting
        {
            public const string Prefix = Rule + "UserRefreshToken/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class UserSessionRouting
        {
            public const string Prefix = Rule + "UserSession/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class VerificationRequestRouting
        {
            public const string Prefix = Rule + "VerificationRequest/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }
        public static class WalletRouting
        {
            public const string Prefix = Rule + "Wallet/";
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
            public const string ChangePassword = Prefix + "Change-Password";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete";

        }


    }
}
