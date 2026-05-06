namespace SmartMedicalGuide.Data.AppMetaData
{
    public static class Router
    {
        public const string SingleRoute = "{id}";
        public const string NameRoute = "{name}";
        public const string root = "Api";
        public const string version = "V1";
        public const string Rule = root + "/" + version + "/";

        public static class ChatSignalRRouting
        {
            public const string Prefix = Rule + "ChatSignalR/";
            public const string CreateChat = Prefix + "CreateChat";
            public const string SendMessage = Prefix + "SendMessage";
        }
        public static class DoctorCapacitySettingRouting
        {
            public const string Prefix = Rule + "DoctorCapacitySetting/";
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "GetById/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
            public const string GetByDoctorId = Prefix + "GetByDoctorId/{doctorId}";
            public const string GetRemainingCapacity = Prefix + "GetRemainingCapacity";
            public const string CheckAvailability = Prefix + "CheckAvailability";
            public const string DecrementCapacity = Prefix + "DecrementCapacity";
            public const string GetCapacityReport = Prefix + "GetCapacityReport";
            public const string BulkUpdate = Prefix + "BulkUpdate";
        }
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

            // Basic CRUD
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "GetById/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";

            // File Operations
            public const string UploadFile = Prefix + "UploadFile";
            public const string DownloadFile = Prefix + "DownloadFile/{attachmentId}";
            public const string DeleteFile = Prefix + "DeleteFile/{attachmentId}";
            public const string UpdateFile = Prefix + "UpdateFile";
            public const string GetTotalFileSize = Prefix + "GetTotalFileSize";
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
            private const string Root = "api/Chat";
            public const string Create = Root + "/Create";
            public const string Edit = Root + "/Edit";
            public const string Delete = Root + "/Delete/{id}";
            public const string List = Root + "/List";
            public const string GetById = Root + "/GetById/{id}";
            public const string GetByPatientDoctor = Root + "/GetByPatientDoctor";
        }
        public static class ClinicRouting
        {
            public const string Prefix = Rule + "Clinic/";

            // Basic CRUD
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "GetById/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";

            // Additional Important Endpoint
            public const string GetWithDoctor = Prefix + "GetWithDoctor/{id}";
        }
        public static class DoctorRouting
        {
            public const string Prefix = Rule + "Doctor/";

            // Basic CRUD
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "GetById/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";

            // Additional Queries
            public const string GetByUserId = Prefix + "GetByUserId/{userId}";
            public const string GetBySpecialization = Prefix + "GetBySpecialization/{specializationId}";
            public const string GetVerified = Prefix + "GetVerified";
            public const string Search = Prefix + "Search";
            public const string TopRated = Prefix + "TopRated";
            public const string GetByPriceRange = Prefix + "GetByPriceRange";
            public const string GetAvailableForBooking = Prefix + "GetAvailableForBooking";
            public const string GetWithDetails = Prefix + "GetWithDetails/{id}";
            public const string GetStatistics = Prefix + "GetStatistics/{doctorId}";

            // Additional Commands
            public const string UpdateVerification = Prefix + "UpdateVerificationStatus";
            public const string ToggleAvailable = Prefix + "ToggleAvailableForBooking";
        }
        public static class DoctorAppointmentRouting
        {
            // Additional Queries
            public const string GetByDoctorId = Prefix + "GetByDoctorId/{doctorId}";
            public const string GetByPatientId = Prefix + "GetByPatientId/{patientId}";
            public const string GetByDate = Prefix + "GetByDate";
            public const string GetByStatus = Prefix + "GetByStatus/{status}";
            public const string GetDoctorUpcoming = Prefix + "GetDoctorUpcoming/{doctorId}";
            public const string GetPatientUpcoming = Prefix + "GetPatientUpcoming/{patientId}";
            public const string GetDoctorToday = Prefix + "GetDoctorToday/{doctorId}";
            public const string GetByDateRange = Prefix + "GetByDateRange";
            public const string GetCount = Prefix + "GetCount";
            public const string CheckAvailability = Prefix + "CheckAvailability";
            public const string GetReport = Prefix + "GetReport";

            // Additional Commands
            public const string Cancel = Prefix + "Cancel";
            public const string Confirm = Prefix + "Confirm";
            public const string Complete = Prefix + "Complete";
            public const string Reschedule = Prefix + "Reschedule";
            public const string Prefix = Rule + "DoctorAppointment/";

            // Basic CRUD
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "GetById/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";
        }
        public static class DoctorScheduleRouting
        {
            public const string Prefix = Rule + "DoctorSchedule/";

            // Basic CRUD
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "GetById/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";

            // Additional Queries
            public const string GetAvailableSlots = Prefix + "GetAvailableSlots";
            public const string CheckAvailability = Prefix + "CheckAvailability";
        }
        public static class FavoriteRouting
        {
            public const string Prefix = Rule + "Favorite/";

            // Basic CRUD
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "GetById/{id}";
            public const string Create = Prefix + "Create";
            public const string Delete = Prefix + "Delete/{id}";

            // Additional Important Endpoints
            public const string GetMyFavorites = Prefix + "GetMyFavorites";
            public const string GetMyFavoritesWithDetails = Prefix + "GetMyFavoritesWithDetails";
            public const string IsFavorite = Prefix + "IsFavorite";
            public const string Toggle = Prefix + "Toggle";
            public const string GetCountByDoctor = Prefix + "GetCountByDoctor";
        }
        public static class LabRouting
        {
            public const string Prefix = Rule + "Lab/";

            // Basic CRUD
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "GetById/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";

            // Additional Important Endpoints
            public const string GetByUserId = Prefix + "GetByUserId/{userId}";
            public const string GetWithServices = Prefix + "GetWithServices/{id}";
            public const string Search = Prefix + "Search";
            public const string GetVerified = Prefix + "GetVerified";
            public const string UpdateVerification = Prefix + "UpdateVerificationStatus";
        }
        public static class LabAppointmentRouting
        {
            public const string Prefix = Rule + "LabAppointment/";

            // Basic CRUD
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "GetById/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";

            // Additional Important Endpoints
            public const string Cancel = Prefix + "Cancel";
            public const string Confirm = Prefix + "Confirm";
            public const string Complete = Prefix + "Complete";
            public const string CheckAvailability = Prefix + "CheckAvailability";
        }
        public static class LabServiceRouting
        {
            public const string Prefix = Rule + "LabService/";

            // Basic CRUD
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "GetById/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";

            // Additional Important Endpoints
            public const string GetWithLab = Prefix + "GetWithLab/{labId}";
            public const string Search = Prefix + "Search";
        }
        public static class MedicalReportRouting
        {
            public const string Prefix = Rule + "MedicalReport/";

            // Basic CRUD
            public const string List = Prefix + "List";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";

            // Additional Queries
            public const string GetByPatientId = Prefix + "GetByPatientId/{patientId}";
            public const string GetByDoctorId = Prefix + "GetByDoctorId/{doctorId}";
            public const string GetByReportType = Prefix + "GetByReportType/{reportType}";
            public const string GetByDateRange = Prefix + "GetByDateRange";
            public const string GetPatientMedicalHistory = Prefix + "GetPatientMedicalHistory/{patientId}";
            public const string GetStatistics = Prefix + "GetStatistics";

            // File Operations
            public const string UploadFile = Prefix + "UploadFile";
            public const string DownloadFile = Prefix + "DownloadFile/{reportId}";
            public const string DeleteFile = Prefix + "DeleteFile/{reportId}";
            public const string UpdateFile = Prefix + "UpdateFile";
        }
        public static class MessageRouting
        {
            private const string Root = "api/Message";
            public const string Create = Root + "/Create";
            public const string Edit = Root + "/Edit";
            public const string Delete = Root + "/Delete/{id}";
            public const string List = Root + "/List";
            public const string GetById = Root + "/GetById/{id}";
            public const string GetByChatId = Root + "/GetByChatId/{chatId}";
            public const string MarkAsRead = Root + "/MarkAsRead/{id}";
        }
        public static class ChatParticipantRouting
        {
            private const string Root = "api/ChatParticipant";
            public const string AddParticipant = Root + "/AddParticipant";
            public const string RemoveParticipant = Root + "/RemoveParticipant";
            public const string UpdateTypingStatus = Root + "/UpdateTypingStatus";
            public const string GetByChatId = Root + "/GetByChatId/{chatId}";
            public const string GetUserChats = Root + "/GetUserChats/{userId}";
            public const string GetMyChats = Root + "/GetMyChats";
        }

        public static class NotificationRouting
        {
            public const string Prefix = Rule + "Notification/";

            // Basic CRUD
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "GetById/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";

            // Additional Important Endpoints
            public const string GetMyNotifications = Prefix + "GetMyNotifications";
            public const string GetMyUnread = Prefix + "GetMyUnread";
            public const string GetUnreadCount = Prefix + "GetUnreadCount";
            public const string MarkAsRead = Prefix + "MarkAsRead";
            public const string MarkAllAsRead = Prefix + "MarkAllAsRead";
        }
        public static class PatientRouting
        {
            public const string Prefix = Rule + "Patient/";

            // Basic CRUD
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "GetById/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";

            // Additional Queries
            public const string GetByUserId = Prefix + "GetByUserId/{userId}";
            public const string GetAppointments = Prefix + "GetAppointments/{patientId}";
            public const string GetPrescriptions = Prefix + "GetPrescriptions/{patientId}";
            public const string GetMedicalReports = Prefix + "GetMedicalReports/{patientId}";
            public const string GetPaymentHistory = Prefix + "GetPaymentHistory/{patientId}";
            public const string GetUpcomingAppointments = Prefix + "GetUpcomingAppointments/{patientId}";
            public const string GetPastAppointments = Prefix + "GetPastAppointments/{patientId}";
            public const string GetFavoriteDoctors = Prefix + "GetFavoriteDoctors/{patientId}";
            public const string GetReviews = Prefix + "GetReviews/{patientId}";
            public const string GetStatistics = Prefix + "GetStatistics/{patientId}";

            // Additional Commands
            public const string UpdateProfile = Prefix + "UpdateProfile";
        }
        public static class PaymentRouting
        {
            public const string Prefix = Rule + "Payment/";

            // Basic CRUD
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "GetById/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";

            // Additional Queries
            public const string GetByPatientId = Prefix + "GetByPatientId/{patientId}";
            public const string GetByDoctorId = Prefix + "GetByDoctorId/{doctorId}";
            public const string GetByStatus = Prefix + "GetByStatus/{status}";
            public const string GetByDateRange = Prefix + "GetByDateRange";
            public const string GetByMethod = Prefix + "GetByMethod/{method}";
            public const string GetDoctorRevenue = Prefix + "GetDoctorRevenue";
            public const string GetPlatformRevenue = Prefix + "GetPlatformRevenue";
            public const string GetRevenueReport = Prefix + "GetRevenueReport";
            public const string GetPending = Prefix + "GetPending";
            public const string GetStatistics = Prefix + "GetStatistics";
            public const string GetWalletPayments = Prefix + "GetWalletPayments";
            public const string GetTransferPayments = Prefix + "GetTransferPayments";

            // Additional Commands
            public const string UpdateStatus = Prefix + "UpdateStatus";
            public const string Verify = Prefix + "Verify";
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

            // Basic CRUD
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "GetById/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";

            // Additional Important Endpoints
            public const string GetByTarget = Prefix + "GetByTarget";
            public const string GetMyReviews = Prefix + "GetMyReviews";
            public const string GetAverageRating = Prefix + "GetAverageRating";
            public const string GetRatingDistribution = Prefix + "GetRatingDistribution";
            public const string GetRecentReviews = Prefix + "GetRecentReviews";
            public const string CheckReviewed = Prefix + "CheckReviewed";
            public const string GetStatistics = Prefix + "GetStatistics";
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

            // Basic CRUD
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "GetById/{id}";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";

            // Additional Queries
            public const string GetByName = Prefix + "GetByName/{name}";
            public const string Search = Prefix + "Search";
            public const string GetPopular = Prefix + "GetPopular";
            public const string GetWithDetails = Prefix + "GetWithDetails/{id}";
            public const string GetStatistics = Prefix + "GetStatistics/{specializationId}";
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

            // Basic CRUD
            public const string List = Prefix + "List";
            public const string GetByID = Prefix + "GetById/{id}";
            public const string GetByUserId = Prefix + "GetByUserId";
            public const string Create = Prefix + "Create";
            public const string Edit = Prefix + "Edit";
            public const string Delete = Prefix + "Delete/{id}";

            // Additional Endpoints
            public const string UpdateBalance = Prefix + "UpdateBalance";
            public const string Transfer = Prefix + "Transfer";
            public const string GetStatistics = Prefix + "GetStatistics";
        }


        public static class EmailsRoute
        {
            public const string Prefix = Rule + "EmailsRoute";
            public const string SendEmail = Prefix + "/SendEmail";
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
