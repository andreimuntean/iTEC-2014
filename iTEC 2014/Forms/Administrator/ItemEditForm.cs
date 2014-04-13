using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iTEC2014
{
    public partial class ItemEditForm : Form, IView
    {
        private List<ItemCategory> categories;
        public List<MenuItem> MenuItems { get; set; }

        public ItemEditForm()
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

            // Loading categories.
            int currentItemCategoryIndex = 0;
            categoryComboBox.Items.Clear();
            categories = DataManager.GetCategories();
            categories.ForEach(category =>
            {
                categoryComboBox.Items.Add(category.Name);
                if (DataManager.SelectedObject != null && (DataManager.SelectedObject as Item).CategoryId == category.ItemCategoryId)
                {
                    currentItemCategoryIndex = categoryComboBox.Items.Count - 1;
                }
            });

            if (categoryComboBox.Items.Count > 0)
            {
                categoryComboBox.SelectedIndex = currentItemCategoryIndex;
            }

            // String assigning.
            managementLabel.Text = Strings.ManagementHeader;
            descriptionLabel.Text = Strings.ManagementDescription;
            categoryLabel.Text = Strings.ItemEditorCategory;
            idLabel.Text = Strings.ItemId;
            nameLabel.Text = Strings.ItemEditorName;
            itemDescriptionLabel.Text = Strings.ItemEditorDescription;
            pointsLabel.Text = Strings.ItemEditorPoints;
            priceLabel.Text = Strings.ItemEditorPrice + " (" + CurrencyManager.Name + ")";

            // Panel formatting.
            statusPanel.BackColor = Theme.Color7;
            bodyPanel.BackColor = Theme.Color7;

            // Text formatting.
            managementLabel.ForeColor = Theme.Color4;
            descriptionLabel.ForeColor = Theme.Color1;
            categoryLabel.ForeColor = Theme.Color1;
            idLabel.ForeColor = Theme.Color1;
            nameLabel.ForeColor = Theme.Color1;
            itemDescriptionLabel.ForeColor = Theme.Color1;
            pointsLabel.ForeColor = Theme.Color1;
            priceLabel.ForeColor = Theme.Color1;

            if (DataManager.SelectedObject == null)
            {
                // Add new item.
                saveButton.Text = Strings.CreateButton;
            }
            else
            {
                // Edit existent item.
                var item = DataManager.SelectedObject as Item;

                idTextBox.Text = item.ItemId.ToString();
                nameTextBox.Text = item.Name;
                itemDescriptionTextBox.Text = item.Description;
                pointsTextBox.Text = item.Points.ToString();
                priceTextBox.Text = item.Price.ToString();

                saveButton.Text = Strings.ConfirmChangesButton;
            }
        }

        protected bool ValidInput()
        {
            int number = 0;

            foreach (var control in panel1.Controls)
            {
                if (control is TextBox)
                {
                    var s = (control as TextBox).Text;
                    if (s.Length < 1 || s.Contains(@"'") || s.Contains(@"\"))
                    {
                        return false;
                    }
                }
            }

            if (int.TryParse(idTextBox.Text, out number) && int.TryParse(pointsTextBox.Text, out number) && int.TryParse(priceTextBox.Text, out number))
            {
                return true;
            }

            return false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (ValidInput())
            {
                var itemId = int.Parse(idTextBox.Text);
                var name = nameTextBox.Text;
                var description = itemDescriptionTextBox.Text;
                var categoryId = (categoryComboBox.Items.Count > 0 ? categories[categoryComboBox.SelectedIndex].ItemCategoryId : 0);
                var points = int.Parse(pointsTextBox.Text);
                var price = int.Parse(priceTextBox.Text);

                var item = new Item(itemId, name, description, categoryId, points, price);

                if (DataManager.SelectedObject == null)
                {
                    item.Add();
                    NotificationManager.Alert(Strings.ItemCreated);
                }
                else
                {
                    item.Update();
                    NotificationManager.Alert(Strings.ItemUpdated);
                }

                ViewManager.View = View.Management;
            }
            else
            {
                NotificationManager.LogException(Strings.InvalidInput);
            }
        }
    }
}
