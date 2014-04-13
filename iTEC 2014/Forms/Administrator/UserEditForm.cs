using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iTEC2014
{
    public partial class UserEditForm : Form, IView
    {
        private List<UserGroup> groups;
        public List<MenuItem> MenuItems { get; set; }

        public UserEditForm()
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

            // Loading groups.
            int currentUserGroupIndex = 0;
            groupComboBox.Items.Clear();
            groups = DataManager.GetGroups();
            groups.ForEach(group =>
            {
                groupComboBox.Items.Add(group.Name);
                if (DataManager.SelectedObject != null && (DataManager.SelectedObject as User).GroupId == group.UserGroupId)
                {
                    currentUserGroupIndex = groupComboBox.Items.Count - 1;
                }
            });

            if (groupComboBox.Items.Count > 0)
            {
                groupComboBox.SelectedIndex = currentUserGroupIndex;
            }

            // String assigning.
            managementLabel.Text = Strings.ManagementHeader;
            descriptionLabel.Text = Strings.ManagementDescription;
            groupLabel.Text = Strings.UserEditorGroup;
            idLabel.Text = Strings.UserId;
            usernameLabel.Text = Strings.UserEditorUsername;
            passwordLabel.Text = Strings.UserEditorPassword;
            firstNameLabel.Text = Strings.UserEditorFirstName;
            lastNameLabel.Text = Strings.UserEditorLastName;
            administratorCheckBox.Text = Strings.UserEditorAdministrator;
            pointsLabel.Text = Strings.UserEditorCurrentPoints;
            welcomeMessageLabel.Text = Strings.UserEditorWelcomeMessage;

            // Panel formatting.
            statusPanel.BackColor = Theme.Color7;
            bodyPanel.BackColor = Theme.Color7;

            // Text formatting.
            managementLabel.ForeColor = Theme.Color4;
            descriptionLabel.ForeColor = Theme.Color1;
            groupLabel.ForeColor = Theme.Color1;
            idLabel.ForeColor = Theme.Color1;
            usernameLabel.ForeColor = Theme.Color1;
            passwordLabel.ForeColor = Theme.Color1;
            firstNameLabel.ForeColor = Theme.Color1;
            lastNameLabel.ForeColor = Theme.Color1;
            administratorCheckBox.ForeColor = Theme.Color1;
            pointsLabel.ForeColor = Theme.Color1;
            welcomeMessageLabel.ForeColor = Theme.Color1;

            if (DataManager.SelectedObject == null)
            {
                // Add new user.
                saveButton.Text = Strings.CreateButton;
            }
            else
            {
                // Edit existent user.
                var user = DataManager.SelectedObject as User;

                idTextBox.Text = user.UserId.ToString();
                usernameTextBox.Text = user.Username;
                firstNameTextBox.Text = user.FirstName;
                lastNameTextBox.Text = user.LastName;
                administratorCheckBox.Checked = user.IsAdministrator;
                pointsTextBox.Text = user.Points.ToString();
                welcomeMessageTextBox.Text = user.WelcomeMessage;

                saveButton.Text = Strings.ConfirmChangesButton;
            }
        }

        protected bool ValidInput()
        {
            int number = 0;

            if (DataManager.SelectedObject == null)
            {
                if (passwordTextBox.Text.Length < 1)
                    return false;
            }

            foreach (var control in panel1.Controls)
            {
                if (control is TextBox)
                {
                    var s = (control as TextBox).Text;
                    if ((s.Length < 1 && (control as TextBox) != passwordTextBox) || s.Contains(@"'") || s.Contains(@"\"))
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
                var username = usernameTextBox.Text;
                var password = (passwordTextBox.Text.Length > 0) ? EncryptionManager.Encrypt(passwordTextBox.Text) : "";
                var firstName = firstNameTextBox.Text;
                var lastName = lastNameTextBox.Text;
                var groupId = (groupComboBox.Items.Count > 0 ? groups[groupComboBox.SelectedIndex].UserGroupId : 0);
                var points = int.Parse(pointsTextBox.Text);
                var welcomeMessage = welcomeMessageTextBox.Text;
                var isAdministrator = administratorCheckBox.Checked;

                var user = new User(id, username, password, firstName, lastName, groupId, points, welcomeMessage, isAdministrator);

                if (DataManager.SelectedObject == null)
                {
                    user.Add();
                    NotificationManager.Alert(Strings.UserCreated);
                }
                else
                {
                    user.Update();
                    NotificationManager.Alert(Strings.UserUpdated);
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
