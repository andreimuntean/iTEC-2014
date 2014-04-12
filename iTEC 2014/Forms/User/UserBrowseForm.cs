using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iTEC2014
{
    public partial class UserBrowseForm : Form, IView
    {
        public List<MenuItem> MenuItems { get; set; }
        public UserBrowseForm()
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
            welcomeHeaderLabel.Text = Strings.LoginHeader + ", " + DataManager.CurrentUser.FirstName + "!";
            welcomeMessageLabel.Text = Strings.LoginDescription;
            categoryLabel.Text = Strings.Category;
            itemLabel.Text = Strings.Item;
            UpdatePoints();

            // Panel formatting.
            statusPanel.BackColor = Theme.Color7;
            browsePanel.BackColor = Theme.Color7;

            // Text formatting.
            welcomeHeaderLabel.ForeColor = Theme.Color4;
            welcomeMessageLabel.ForeColor = Theme.Color1;
            pointsLabel.ForeColor = Theme.Color4;
            categoryLabel.ForeColor = Theme.Color4;
            itemLabel.ForeColor = Theme.Color4;
        }

        public void UpdatePoints()
        {
            pointsLabel.Text = Strings.Points + ": " + DataManager.CurrentUser.Points;
        }

        public new void Dispose()
        {
            base.Dispose();
            MenuItems.ForEach(menuItem => menuItem.Dispose());
        }
    }
}
