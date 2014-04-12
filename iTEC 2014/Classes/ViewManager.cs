using System.Windows.Forms;

namespace iTEC2014
{
    public enum View
    {
        Login,
        UserBrowse,
        UserSettings,
        AdministratorManagement,
        AdministratorReport
    }

    static class ViewManager
    {
        private static View view;
        public static View View
        {
            get { return view; }
            set
            {
                view = value;
                switch (view)
                {
                    case View.Login:
                        Program.Screen.SetView(new LoginForm());
                        break;

                    case View.UserBrowse:
                        // Program.Screen.SetView(new UserBrowseForm());
                        break;

                    case View.UserSettings:
                        // Program.Screen.SetView(new LoginForm());
                        break;

                    case View.AdministratorManagement:
                        Program.Screen.SetView(new AdministratorManagementForm());
                        break;

                    case View.AdministratorReport:
                        // Program.Screen.SetView(new LoginForm());
                        break;
                }
            }
        }
    }
}
