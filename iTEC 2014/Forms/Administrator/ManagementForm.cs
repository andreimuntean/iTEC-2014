using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace iTEC2014
{
    public enum ListDisplay
    {
        Items,
        Users
    }

    public partial class ManagementForm : Form, IView
    {
        private List<Item> items;
        private List<ItemCategory> itemCategories;
        private List<User> users;
        private List<UserGroup> userGroups;

        public ListDisplay CurrentList { get; set; }
        public List<MenuItem> MenuItems { get; set; }
     
        public ManagementForm()
        {
            InitializeComponent();
            MenuItems = new List<MenuItem>()
            {
                new MenuItem(Strings.MenuUser, 0, View.UserBrowse),
                new MenuItem(Strings.MenuManage, 1, View.Management),
                new MenuItem(Strings.MenuReport, 2, View.Report),
                new MenuItem(Strings.MenuHelp, 3, () => FileManager.OpenHelp()),
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
            addSetButton.Text = Strings.AddCategory;
            addDataButton.Text = Strings.AddItem;

            // Panel formatting.
            statusPanel.BackColor = Theme.Color7;
            browsePanel.BackColor = Theme.Color7;

            // Text formatting.
            managementLabel.ForeColor = Theme.Color4;
            descriptionLabel.ForeColor = Theme.Color1;
            categoryLabel.ForeColor = Theme.Color4;
            itemLabel.ForeColor = Theme.Color4;

            // Button formatting.
            addSetButton.BackColor = Theme.Color4;
            addSetButton.ForeColor = Theme.Color1;
            addDataButton.BackColor = Theme.Color4;
            addDataButton.ForeColor = Theme.Color1;
            viewUsersButton.BackColor = Theme.Color4;
            viewUsersButton.ForeColor = Theme.Color1;
            viewItemsButton.BackColor = Theme.Color4;
            viewItemsButton.ForeColor = Theme.Color1;

            SeeUsers();
        }

        public void PopulateSets()
        {
            addDataButton.Visible = false;
            itemPanel.Controls.Clear();

            if (CurrentList == ListDisplay.Items)
            {
                itemCategories = DataManager.GetCategories();
                categoryPanel.Controls.Clear();

                itemCategories.ForEach(category =>
                {
                    var index = itemCategories.IndexOf(category);
                    var categoryButton = new CategoryButton(category, index, () => { PopulateData(category.ItemCategoryId); }, () => PopulateSets());
                    categoryButton.Show(categoryPanel);
                });
            }
            else if (CurrentList == ListDisplay.Users)
            {
                userGroups = DataManager.GetGroups();
                categoryPanel.Controls.Clear();

                userGroups.ForEach(group =>
                {
                    var index = userGroups.IndexOf(group);
                    var groupButton = new GroupButton(group, index, () => { PopulateData(group.UserGroupId); }, () => PopulateSets());
                    groupButton.Show(categoryPanel);
                });
            }
        }

        public void PopulateData(int setId)
        {
            if (CurrentList == ListDisplay.Items)
            {
                var category = itemCategories.First(c => c.ItemCategoryId == setId);
                items = category.GetItems();
                itemPanel.Controls.Clear();

                items.ForEach(item =>
                {
                    var index = items.IndexOf(item);
                    var itemButton = new AdminItemButton(item, index, () => PopulateData(setId));
                    itemButton.Show(itemPanel);
                });
            }
            else if (CurrentList == ListDisplay.Users)
            {
                var group = userGroups.First(g => g.UserGroupId == setId);
                users = group.GetUsers();
                itemPanel.Controls.Clear();

                users.ForEach(user =>
                {
                    var index = users.IndexOf(user);
                    var userButton = new AdminUserButton(user, index, () => PopulateData(setId));
                    userButton.Show(itemPanel);
                });
            }

            addDataButton.Visible = true;
        }

        public void SeeUsers()
        {
            CurrentList = ListDisplay.Users;
            addSetButton.Text = Strings.AddGroup;
            addDataButton.Text = Strings.AddUser;
            PopulateSets();
        }

        public void SeeItems()
        {
            CurrentList = ListDisplay.Items;
            addSetButton.Text = Strings.AddCategory;
            addDataButton.Text = Strings.AddItem;
            PopulateSets();
        }

        public new void Dispose()
        {
            base.Dispose();
            MenuItems.ForEach(menuItem => menuItem.Dispose());
        }

        protected void viewUsersButton_Click(object sender, EventArgs e)
        {
            SeeUsers();
        }

        protected void viewItemsButton_Click(object sender, EventArgs e)
        {
            SeeItems();
        }

        private void addDataButtonClick(object sender, EventArgs e)
        {
            DataManager.SelectedObject = null;
            ViewManager.View = (CurrentList == ListDisplay.Items) ? View.ItemEdit : View.UserEdit;

        }

        private void addSetButtonClick(object sender, EventArgs e)
        {
            DataManager.SelectedObject = null;
            ViewManager.View = (CurrentList == ListDisplay.Items) ? View.CategoryEdit : View.GroupEdit;
        }
    }
}
