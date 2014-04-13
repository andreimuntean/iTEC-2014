using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iTEC2014
{
    public partial class GroupEditForm : Form, IView
    {
        public List<MenuItem> MenuItems { get; set; }

        public GroupEditForm()
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
            idLabel.Text = Strings.GroupId;
            nameLabel.Text = Strings.GroupEditorName;
            groupDescriptionLabel.Text = Strings.GroupEditorDescription;
            pointsLabel.Text = Strings.GroupEditorPoints;

            // Panel formatting.
            statusPanel.BackColor = Theme.Color7;
            bodyPanel.BackColor = Theme.Color7;

            // Text formatting.
            managementLabel.ForeColor = Theme.Color4;
            descriptionLabel.ForeColor = Theme.Color1;
            idLabel.ForeColor = Theme.Color1;
            nameLabel.ForeColor = Theme.Color1;
            groupDescriptionLabel.ForeColor = Theme.Color1;
            pointsLabel.ForeColor = Theme.Color1;

            if (DataManager.SelectedObject == null)
            {
                // Add new group.
                saveButton.Text = Strings.CreateButton;
            }
            else
            {
                // Edit existent group.
                var group = DataManager.SelectedObject as UserGroup;

                idTextBox.Text = group.UserGroupId.ToString();
                nameTextBox.Text = group.Name;
                groupDescriptionTextBox.Text = group.Description;
                pointsTextBox.Text = group.Points.ToString();

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

            if (int.TryParse(idTextBox.Text, out number) && int.TryParse(pointsTextBox.Text, out number))
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
                var description = groupDescriptionTextBox.Text;
                var points = int.Parse(pointsTextBox.Text);

                var group = new UserGroup(id, name, description, points);

                if (DataManager.SelectedObject == null)
                {
                    group.Add();
                    NotificationManager.Alert(Strings.GroupCreated);
                }
                else
                {
                    group.Update();
                    NotificationManager.Alert(Strings.GroupUpdated);
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
