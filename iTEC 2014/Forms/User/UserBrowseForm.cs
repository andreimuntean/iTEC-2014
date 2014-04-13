using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace iTEC2014
{
    public partial class UserBrowseForm : Form, IView
    {
        private List<ItemCategory> itemCategories;
        private List<Item> items;

        public List<MenuItem> MenuItems { get; set; }
        public UserBrowseForm()
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

        public void PopulateCategory()
        {
            itemCategories = DataManager.GetCategories();
            categoryPanel.Controls.Clear();

            itemCategories.ForEach(category =>
            {
                var index = itemCategories.IndexOf(category);
                var categoryButton = new CategoryButton(category, index, () => { PopulateItems(category.ItemCategoryId); }, () => { });
                categoryButton.Show(categoryPanel);
            });
        }

        public void PopulateItems(int categoryId)
        {
            var category = itemCategories.First(c => c.ItemCategoryId == categoryId);
            items = category.GetItems();
            itemPanel.Controls.Clear();
            
            items.ForEach(item =>
            {
                var index = items.IndexOf(item);
                var itemButton = new ItemButton(item, index, () =>
                {
                    if (DataManager.CurrentUser.Points > 0)
                    {
                        DataManager.CurrentUser.Vote(item);
                        UpdatePoints();
                    }
                    else
                    {
                        NotificationManager.LogException(Strings.InsufficientPoints);
                    }
                });
                itemButton.Show(itemPanel);
            });
        }

        public void Initialize()
        {
            BackColor = Theme.Color1;

            // String assigning.
            welcomeHeaderLabel.Text = Strings.Welcome + ", " + DataManager.CurrentUser.FirstName.ToUpper() + "!";
            welcomeMessageLabel.Text = DataManager.CurrentUser.WelcomeMessage;
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

            PopulateCategory();
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
