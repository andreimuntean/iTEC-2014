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
                new MenuItem(Strings.MenuHelp, 3, () => {}),
                new MenuItem(Strings.MenuLogout, 4, () => { DataManager.Logout(); ViewManager.View = View.Login; })
            };

            Initialize();
        }

        public void Initialize()
        {
            BackColor = Theme.Color1;

            // String assigning.
            settingsLabel.Text = Strings.SettingsHeader;
            descriptionLabel.Text = Strings.SettingsDescription;
            welcomeMessageLabel.Text = Strings.SettingsWelcomeMessage;
            cancelButton.Text = Strings.DiscardChangesButton;
            saveButton.Text = Strings.ConfirmChangesButton;
            welcomeMessageTextBox.Text = DataManager.CurrentUser.WelcomeMessage;

            // Panel formatting.
            statusPanel.BackColor = Theme.Color7;
            bodyPanel.BackColor = Theme.Color7;

            // Text formatting.
            settingsLabel.ForeColor = Theme.Color4;
            descriptionLabel.ForeColor = Theme.Color1;
            welcomeMessageLabel.ForeColor = Theme.Color1;

            // Button formatting.
            cancelButton.BackColor = Theme.Color4;
            cancelButton.ForeColor = Theme.Color1;
            saveButton.BackColor = Theme.Color4;
            saveButton.ForeColor = Theme.Color1;
        }

        public new void Dispose()
        {
            base.Dispose();
            MenuItems.ForEach(menuItem => menuItem.Dispose());
        }
    }
}
