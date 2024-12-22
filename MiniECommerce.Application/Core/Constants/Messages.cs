namespace MiniECommerce.Application.Core.Constants
{
    public static class Messages
    {
        public static class Common
        {
            public static string Add = "The registration process was successful.";
            public static string Delete = "The deletion was successful.";
            public static string Update = "The update was successful.";
            public static string Error = "An error occurred during the process!";
            public static string Success = "The operation was completed successfully.";
            public static string NotFound = "No such record found.";
        }

        public static class Login
        {
            public static string LoginFailed = "Username or password is incorrect.";
            public static string AccessDenied = "Access denied: You do not have the required permissions to perform this action.";
            public static string ValidToken = "A valid token was not provided. Please log in.";
            public static string RegisterFailed = "This username is in use.";
        }
    }
}
