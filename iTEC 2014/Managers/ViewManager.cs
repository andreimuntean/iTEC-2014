using System.Windows.Forms;

namespace iTEC2014
{
    public enum View
    {
        Login,
        UserBrowse,
        UserSettings,
        Management,
        CategoryEdit,
        GroupEdit,
        ItemEdit,
        UserEdit,
        Report
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
                        Program.Screen.SetView(new UserBrowseForm());
                        break;

                    case View.UserSettings:
                        Program.Screen.SetView(new UserSettingsForm());
                        break;

                    case View.Management:
                        Program.Screen.SetView(new ManagementForm());
                        break;

                    case View.CategoryEdit:
                        Program.Screen.SetView(new CategoryEditForm());
                        break;

                    case View.GroupEdit:
                        Program.Screen.SetView(new GroupEditForm());
                        break;

                    case View.ItemEdit:
                        Program.Screen.SetView(new ItemEditForm());
                        break;

                    case View.UserEdit:
                        Program.Screen.SetView(new UserEditForm());
                        break;

                    case View.Report:
                        Program.Screen.SetView(new ReportForm());
                        break;
                }
            }
        }
    }
}
