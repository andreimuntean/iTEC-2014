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
                new MenuItem(Strings.MenuHelp, 3)
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
                    MessageBox.Show(Strings.AuthenticationFailed, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                else if (password.Length == 0)
                {
                    MessageBox.Show(Strings.AuthenticationFailed, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                return true;
            }
            catch
            {
                MessageBox.Show(Strings.AuthenticationFailed, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
            userButton.Text = Strings.LoginUserButton;
            administratorButton.Text = Strings.LoginAdministratorButton;

            loginLabel.ForeColor = Theme.Color4;
            descriptionLabel.ForeColor = Theme.Color7;
            usernameLabel.ForeColor = Theme.Color3;
            passwordLabel.ForeColor = Theme.Color3;
            userButton.BackColor = Theme.Color4;
            userButton.ForeColor = Theme.Color1;
            administratorButton.BackColor = Theme.Color4;
            administratorButton.ForeColor = Theme.Color1;
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
                var password = passwordTextBox.Text;

                var connectionStatus = DataManager.Login(username, password);
                Program.Screen.SetView(new ManagementForm());

                switch (connectionStatus)
                {
                    case ConnectionStatus.Success:
                        if (sender == administratorButton)
                        {
                            if (DataManager.CurrentUser.IsAdministrator)
                            {
                                Program.Screen.SetView(new ManagementForm());
                            }
                            else
                            {
                                MessageBox.Show(Strings.NotAdministratorError, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        break;
                    
                    case ConnectionStatus.TimedOut:
                        MessageBox.Show(Strings.ConnectionTimedOut, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                    
                    case ConnectionStatus.InvalidInput:
                        MessageBox.Show(Strings.AuthenticationFailed, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        break;
                }
            }
        }
    }
}
