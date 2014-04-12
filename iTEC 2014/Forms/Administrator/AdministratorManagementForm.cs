using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iTEC2014
{
    public partial class AdministratorManagementForm : Form, IView
    {
        public List<MenuItem> MenuItems { get; set; }
        public AdministratorManagementForm()
        {
            InitializeComponent();
            MenuItems = new List<MenuItem>()
            {
                new MenuItem(Strings.MenuUser, 0, View.UserBrowse),
                new MenuItem(Strings.MenuManage, 1, View.AdministratorManagement),
                new MenuItem(Strings.MenuReport, 2, View.AdministratorReport),
                new MenuItem(Strings.MenuHelp, 3, () => {}),
                new MenuItem(Strings.MenuLogout, 4, () => { DataManager.Logout(); ViewManager.View = View.Login; })
            };

            Initialize();
        }

        public void Initialize()
        {
            BackColor = Theme.Color1;

            // String assigning.
            managementLabel.Text = Strings.ManagementHeader;
            descriptionLabel.Text = Strings.ManagementDescription;
            itemLabel.Text = Strings.Item;
            categoryLabel.Text = Strings.Category;
            viewUsersButton.Text = Strings.ViewUsers;
            viewItemsButton.Text = Strings.ViewItems;
            addCategoryButton.Text = Strings.AddCategory;
            addItemButton.Text = Strings.AddItem;

            // Panel formatting.
            statusPanel.BackColor = Theme.Color7;
            browsePanel.BackColor = Theme.Color7;

            // Text formatting.
            managementLabel.ForeColor = Theme.Color4;
            descriptionLabel.ForeColor = Theme.Color1;
            categoryLabel.ForeColor = Theme.Color4;
            itemLabel.ForeColor = Theme.Color4;

            // Button formatting.
            addCategoryButton.BackColor = Theme.Color4;
            addCategoryButton.ForeColor = Theme.Color1;
            addItemButton.BackColor = Theme.Color4;
            addItemButton.ForeColor = Theme.Color1;
            viewUsersButton.BackColor = Theme.Color4;
            viewUsersButton.ForeColor = Theme.Color1;
            viewItemsButton.BackColor = Theme.Color4;
            viewItemsButton.ForeColor = Theme.Color1;
        }

        public new void Dispose()
        {
            base.Dispose();
            MenuItems.ForEach(menuItem => menuItem.Dispose());
        }
    }
}
