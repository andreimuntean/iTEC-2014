using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iTEC2014
{
    public partial class ManagementForm : Form, IView
    {
        public List<MenuItem> MenuItems { get; set; }
        public ManagementForm()
        {
            InitializeComponent();
            MenuItems = new List<MenuItem>()
            {
                new MenuItem(Strings.MenuLogout, 3),
                new MenuItem(Strings.MenuHelp, 2),
                new MenuItem(Strings.MenuReport, 1),
                new MenuItem(Strings.MenuManage, 0)
            };

            Initialize();
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
    }
}
