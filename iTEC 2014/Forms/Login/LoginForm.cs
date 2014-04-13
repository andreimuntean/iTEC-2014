using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iTEC2014
{
    public partial class LoginForm : Form, IView
    {
        public List<MenuItem> MenuItems { get; set; }
        public LoginForm()
        {
            InitializeComponent();
            MenuItems = new List<MenuItem>()
            {
                new MenuItem(Strings.MenuHelp, 4, () => FileManager.OpenHelp())
            };

            Initialize();
        }

        protected bool IsInputValid()
        {
            // This can be modified to give more detailed
            // responses in the future if necessary.
            try
            {
                var username = usernameTextBox.Text;
                var password = passwordTextBox.Text;

                if (username.Length == 0)
                {
                    NotificationManager.LogException(Strings.AuthenticationFailed);
                    return false;
                }
                else if (password.Length == 0)
                {
                    NotificationManager.LogException(Strings.AuthenticationFailed);
                    return false;
                }

                return true;
            }
            catch
            {
                NotificationManager.LogException(Strings.AuthenticationFailed);
                return false;
            }
        }

        public void Initialize()
        {
            BackColor = Theme.Color1;

            loginLabel.Text = Strings.LoginHeader;
            descriptionLabel.Text = Strings.LoginDescription;
            usernameLabel.Text = Strings.Username;
            passwordLabel.Text = Strings.Password;
            loginButton.Text = Strings.LoginUserButton;

            loginLabel.ForeColor = Theme.Color4;
            descriptionLabel.ForeColor = Theme.Color7;
            usernameLabel.ForeColor = Theme.Color3;
            passwordLabel.ForeColor = Theme.Color3;
            loginButton.BackColor = Theme.Color4;
            loginButton.ForeColor = Theme.Color1;
        }

        public new void Dispose()
        {
            base.Dispose();
            MenuItems.ForEach(menuItem => menuItem.Dispose());
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (IsInputValid())
            {
                var username = usernameTextBox.Text;
                var password = EncryptionManager.Encrypt(passwordTextBox.Text);

                var connectionStatus = DataManager.Login(username, password);

                switch (connectionStatus)
                {
                    case ConnectionStatus.Success:
                        ViewManager.View = View.UserBrowse;
                        break;

                    case ConnectionStatus.TimedOut:
                        NotificationManager.LogException(Strings.ConnectionTimedOut);
                        break;
                    
                    case ConnectionStatus.InvalidInput:
                        NotificationManager.LogException(Strings.AuthenticationFailed);
                        break;
                }
            }
        }
    }
}
