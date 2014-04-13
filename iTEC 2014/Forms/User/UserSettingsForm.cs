using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iTEC2014
{
    public partial class UserSettingsForm : Form, IView
    {
        public List<MenuItem> MenuItems { get; set; }
        public UserSettingsForm()
        {
            InitializeComponent();
            MenuItems = new List<MenuItem>()
            {
                new MenuItem(Strings.MenuBrowse, 1, View.UserBrowse),
                new MenuItem(Strings.MenuSettings, 2, View.UserSettings),
                new MenuItem(Strings.MenuHelp, 3, () => FileManager.OpenHelp()),
                new MenuItem(Strings.MenuLogout, 4, () => { DataManager.Logout(); ViewManager.View = View.Login; })
            };

            if (DataManager.CurrentUser.IsAdministrator)
            {
                MenuItems.Add(new MenuItem(Strings.MenuAdministrator, 0, View.Management));
            }

            Initialize();
        }

        public void Initialize()
        {
            BackColor = Theme.Color1;

            // String assigning.
            settingsLabel.Text = Strings.SettingsHeader;
            descriptionLabel.Text = Strings.SettingsDescription;
            welcomeMessageLabel.Text = Strings.SettingsWelcomeMessage;
            saveButton.Text = Strings.ConfirmChangesButton;
            welcomeMessageTextBox.Text = DataManager.CurrentUser.WelcomeMessage;
            passwordLabel.Text = Strings.SettingsChangePassword;
            passwordLabel.Text = Strings.SettingsConfirmPassword;

            // Panel formatting.
            statusPanel.BackColor = Theme.Color7;
            bodyPanel.BackColor = Theme.Color7;

            // Text formatting.
            settingsLabel.ForeColor = Theme.Color4;
            descriptionLabel.ForeColor = Theme.Color1;
            welcomeMessageLabel.ForeColor = Theme.Color1;
            passwordLabel.ForeColor = Theme.Color1;
            passwordConfirmLabel.ForeColor = Theme.Color1;

            // Button formatting.
            saveButton.BackColor = Theme.Color4;
            saveButton.ForeColor = Theme.Color1;
        }

        public new void Dispose()
        {
            base.Dispose();
            MenuItems.ForEach(menuItem => menuItem.Dispose());
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (passwordConfirmTextBox.Text == passwordTextBox.Text)
            {
                if (passwordConfirmTextBox.Text.Length > 0)
                    DataManager.CurrentUser.Password = EncryptionManager.Encrypt(passwordConfirmTextBox.Text);
                DataManager.CurrentUser.WelcomeMessage = welcomeMessageTextBox.Text;
                DataManager.SelectedObject = DataManager.CurrentUser;
                var connectionStatus = DataManager.Update<User>(DataManager.CurrentUser);

                if (connectionStatus == ConnectionStatus.Success)
                {
                    NotificationManager.Alert(Strings.SettingsUpdated);
                }
                else NotificationManager.LogException(Strings.ConnectionTimedOut);
            }
            else
            {
                NotificationManager.LogException(Strings.SettingsPasswordMismatch);
            }
        }
    }
}
