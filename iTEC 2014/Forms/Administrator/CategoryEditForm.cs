using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iTEC2014
{
    public partial class CategoryEditForm : Form, IView
    {
        public List<MenuItem> MenuItems { get; set; }

        public CategoryEditForm()
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
            idLabel.Text = Strings.CategoryId;
            nameLabel.Text = Strings.CategoryEditorName;
            categoryDescriptionLabel.Text = Strings.CategoryEditorDescription;

            // Panel formatting.
            statusPanel.BackColor = Theme.Color7;
            bodyPanel.BackColor = Theme.Color7;

            // Text formatting.
            managementLabel.ForeColor = Theme.Color4;
            descriptionLabel.ForeColor = Theme.Color1;
            idLabel.ForeColor = Theme.Color1;
            nameLabel.ForeColor = Theme.Color1;
            categoryDescriptionLabel.ForeColor = Theme.Color1;

            if (DataManager.SelectedObject == null)
            {
                // Add new category.
                saveButton.Text = Strings.CreateButton;
            }
            else
            {
                // Edit existent category.
                var category = DataManager.SelectedObject as ItemCategory;

                idTextBox.Text = category.ItemCategoryId.ToString();
                nameTextBox.Text = category.Name;
                categoryDescriptionTextBox.Text = category.Description;

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

            if (int.TryParse(idTextBox.Text, out number))
            {
                return true;
            }

            return false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (ValidInput())
            {
                var id = int.Parse(idTextBox.Text);
                var name = nameTextBox.Text;
                var description = categoryDescriptionTextBox.Text;

                var category = new ItemCategory(id, name, description);

                if (DataManager.SelectedObject == null)
                {
                    category.Add();
                    NotificationManager.Alert(Strings.CategoryCreated);
                }
                else
                {
                    category.Update();
                    NotificationManager.Alert(Strings.CategoryUpdated);
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
