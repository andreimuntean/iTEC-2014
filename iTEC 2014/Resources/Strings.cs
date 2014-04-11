namespace iTEC2014
{
    static class Strings
    {
        public static string Title { get { return "Employee Delight Optimization"; } }
        public static string Version { get { return "1.0.0.0"; } }

        // MISC
        public static string Okay { get { return "OK"; } }
        public static string Edit { get { return "EDIT"; } }
        public static string Delete { get { return "DELETE"; } }

        // MENU
        public static string MenuManage { get { return "MANAGE"; } }
        public static string MenuReport { get { return "REPORT"; } }
        public static string MenuBrowse { get { return "BROWSE"; } }
        public static string MenuHelp { get { return "HELP"; } }
        public static string MenuLogout { get { return "LOGOUT"; } }

        // LOGIN FORM
        public static string LoginHeader { get { return "LOGIN"; } }
        public static string LoginDescription { get { return "Login to access the Employee Delight Optimization Application."; } }
        public static string Username { get { return "Username"; } }
        public static string Password { get { return "Password"; } }
        public static string LoginUserButton { get { return "Login as user"; } }
        public static string LoginAdministratorButton { get { return "Login as administrator"; } }
        public static string AuthenticationFailed { get { return "Invalid username or password."; } }
        public static string ConnectionTimedOut { get { return "Could not reach server. Please try again."; } }
        public static string NotAdministratorError { get { return "Cannot login as an administrator because this account has no administrative privileges."; } }
    }
}
