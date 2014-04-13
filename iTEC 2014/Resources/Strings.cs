namespace iTEC2014
{
    static class Strings
    {
        public static string Title { get { return "Employee Delight Optimization"; } }
        public static string Version { get { return "1.0.0.0"; } }

        // Miscellaneous.
        public static string Okay { get { return "OK"; } }
        public static string Edit { get { return "EDIT"; } }
        public static string Delete { get { return "DELETE"; } }
        public static string CancelButton { get { return "Cancel"; } }
        public static string CreateButton { get { return "Create"; } }
        public static string ConfirmChangesButton { get { return "Confirm Changes"; } }
        public static string InvalidInput { get { return "Cannot save changes because input data is invalid."; } }
        public static string InvalidPath { get { return "Cannot proceed because the specified path is invalid."; } }
        public static string DeleteGroupConfirmation { get { return "Are you sure you wish to delete this group? It will delete every user in it."; } }
        public static string DeleteCategoryConfirmation { get { return "Are you sure you wish to delete this category? It will delete every item in it."; } }

        // Header menu.
        public static string MenuBrowse { get { return "BROWSE"; } }
        public static string MenuSettings { get { return "SETTINGS"; } }
        public static string MenuManage { get { return "MANAGE"; } }
        public static string MenuReport { get { return "REPORT"; } }
        public static string MenuUser { get { return "USER"; } }
        public static string MenuAdministrator { get { return "ADMIN"; } }
        public static string MenuHelp { get { return "HELP"; } }
        public static string CannotFindHelpFile { get { return "Cannot find the help file."; } }
        public static string MenuLogout { get { return "LOGOUT"; } }

        // Login form.
        public static string LoginHeader { get { return "LOGIN"; } }
        public static string LoginDescription { get { return "Login to access the Employee Delight Optimization Application."; } }
        public static string Username { get { return "Username"; } }
        public static string Password { get { return "Password"; } }
        public static string LoginUserButton { get { return "Login"; } }
        public static string AuthenticationFailed { get { return "Invalid username or password."; } }
        public static string ConnectionTimedOut { get { return "Could not reach server. Please try again."; } }
        public static string NotAdministratorError { get { return "Cannot login as an administrator because this account has no administrative privileges."; } }

        // Browse form.
        public static string Welcome { get { return "WELCOME"; } }
        public static string Category { get { return "CATEGORY"; } }
        public static string Item { get { return "ITEM"; } }
        public static string Group { get { return "GROUP"; } }
        public static string User { get { return "USER"; } }
        public static string CurrencyRon { get { return "RON"; } }
        public static string Points { get { return "POINTS"; } }
        public static string Vote { get { return "VOTE"; } }
        public static string InsufficientPoints { get { return "You do not have enough points to vote for this item."; } }

        // Settings form.
        public static string SettingsHeader { get { return "SETTINGS"; } }
        public static string SettingsDescription { get { return "Customize your browsing experience."; } }
        public static string SettingsUpdated { get { return "User settings have been updated."; } }
        public static string SettingsWelcomeMessage { get { return "Welcome Message"; } }
        public static string SettingsChangePassword { get { return "Change Password"; } }
        public static string SettingsConfirmPassword { get { return "Confirm New Password"; } }
        public static string SettingsPasswordMismatch { get { return "Cannot save settings because the passwords do not match."; } }

        // Management form.
        public static string ManagementHeader { get { return "MANAGEMENT"; } }
        public static string ManagementDescription { get { return "Add or edit users and items."; } }
        public static string ViewUsers { get { return "View Users"; } }
        public static string ViewItems { get { return "View Items"; } }
        public static string AddCategory { get { return "Create Category"; } }
        public static string AddItem { get { return "Create Item"; } }
        public static string AddGroup { get { return "Create Group"; } }
        public static string AddUser { get { return "Create User"; } }

        // User editor.
        public static string UserId { get { return "User ID"; } }
        public static string UserEditorFirstName { get { return "First Name"; } }
        public static string UserEditorLastName { get { return "Last Name"; } }
        public static string UserEditorUsername { get { return "Username"; } }
        public static string UserEditorPassword { get { return "Password"; } }
        public static string UserEditorAdministrator { get { return "Has Administrative Powers"; } }
        public static string UserEditorCurrentPoints { get { return "Current Points"; } }
        public static string UserEditorGroup { get { return "Group"; } }
        public static string UserEditorWelcomeMessage { get { return "Welcome Message"; } }
        public static string UserUpdated { get { return "User has been updated."; } }
        public static string UserCreated { get { return "User has been successfully created."; } }

        // Category editor.
        public static string CategoryId { get { return "Category ID"; } }
        public static string CategoryEditorName { get { return "Name"; } }
        public static string CategoryEditorDescription { get { return "Description"; } }
        public static string CategoryUpdated { get { return "Category has been updated."; } }
        public static string CategoryCreated { get { return "Category has been successfully created."; } }

        // Group editor.
        public static string GroupId { get { return "Group ID"; } }
        public static string GroupEditorName { get { return "Name"; } }
        public static string GroupEditorDescription { get { return "Description"; } }
        public static string GroupEditorPoints { get { return "Monthly Points"; } }
        public static string GroupUpdated { get { return "Group has been updated."; } }
        public static string GroupCreated { get { return "Group has been successfully created."; } }

        // Item editor.
        public static string ItemId { get { return "Item ID"; } }
        public static string ItemEditorName { get { return "Name"; } }
        public static string ItemEditorCategory { get { return "Category"; } }
        public static string ItemEditorDescription { get { return "Description"; } }
        public static string ItemEditorPoints { get { return "Points"; } }
        public static string ItemEditorPrice { get { return "Price"; } }
        public static string ItemUpdated { get { return "Item has been updated."; } }
        public static string ItemCreated { get { return "Item has been successfully created."; } }

        // Report form.
        public static string Budget { get { return "Budget (Optional)"; } }
        public static string GenerateReport { get { return "Generate Report"; } }
        public static string ReportGenerated { get { return "A report has been successfully generated."; } }
        public static string ReportGenerationFailure { get { return "An unexpected error has occurred. The report could not be generated."; } }
    }
}
