using System;
using System.Drawing;
using System.Windows.Forms;

namespace iTEC2014
{
    class GroupButton
    {
        private Action action;
        private Action onUpdate;
        private UserGroup group;
        private Panel panel;

        public GroupButton(UserGroup group, int index, Action action, Action onUpdate)
        {
            this.action = action;
            this.onUpdate = onUpdate;
            this.group = group;

            panel = new Panel()
            {
                BackColor = Theme.Color8,
                Height = 100,
                Width = 200,
                Location = new Point(0, index * (ViewManager.View == View.Management ? 146 : 106)),
            };

            var name = new Label()
            {
                ForeColor = Theme.Color4,
                Font = new Font("Calibri", 15),
                Height = 30,
                Width = 180,
                Location = new Point(10, 5),
                Text = group.Name.ToUpper()
            };

            var description = new Label()
            {
                ForeColor = Theme.Color6,
                Font = new Font("Calibri", 12),
                Height = 60,
                Width = 180,
                Location = new Point(10, 35),
                Text = group.Description
            };

            addEvents(panel);
            addEvents(name);
            addEvents(description);

            panel.Controls.Add(name);
            panel.Controls.Add(description);
            name.Show();
            description.Show();

            if (ViewManager.View == View.Management)
            {
                panel.Height = 140;

                var editButton = new Button()
                {
                    BackColor = Theme.Color9,
                    ForeColor = Theme.Color1,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Calibri", 13),
                    Height = 40,
                    Width = 98,
                    Location = new Point(0, 100),
                    Text = Strings.Edit
                };

                editButton.FlatAppearance.BorderSize = 0;
                editButton.Click += editButton_Click;
                editButton.MouseEnter += editButton_MouseEnter;
                editButton.MouseLeave += editButton_MouseLeave;
                panel.Controls.Add(editButton);
                editButton.Show();

                var deleteButton = new Button()
                {
                    BackColor = Theme.Color9,
                    ForeColor = Theme.Color1,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Calibri", 13),
                    Height = 40,
                    Width = 98,
                    Location = new Point(102, 100),
                    Text = Strings.Delete
                };

                deleteButton.FlatAppearance.BorderSize = 0;
                deleteButton.Click += deleteButton_Click;
                deleteButton.MouseEnter += deleteButton_MouseEnter;
                deleteButton.MouseLeave += deleteButton_MouseLeave;
                panel.Controls.Add(deleteButton);
                deleteButton.Show();
            }
        }

        private void addEvents(Control control)
        {
            control.Click += groupClick;
            control.MouseEnter += groupMouseEnter;
            control.MouseLeave += groupMouseLeave;
        }

        public void Show(Control parent)
        {
            parent.Controls.Add(panel);
        }

        public void IndexIn(Control parent)
        {
            parent.Controls.IndexOf(panel);
        }

        protected void groupMouseLeave(object sender, EventArgs e)
        {
            if (sender is Panel)
            {
                (sender as Panel).BackColor = Theme.Color8;
            }
            else if ((sender as Control).Parent is Panel)
            {
                (sender as Control).Parent.BackColor = Theme.Color8;
            }
        }

        protected void groupMouseEnter(object sender, EventArgs e)
        {
            if (sender is Panel)
            {
                (sender as Panel).BackColor = Theme.Color3;
            }
            else if ((sender as Control).Parent is Panel)
            {
                (sender as Control).Parent.BackColor = Theme.Color3;
            }
        }

        protected void groupClick(object sender, EventArgs e)
        {
            action();
        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            DataManager.SelectedObject = group;
            ViewManager.View = View.GroupEdit;
        }

        protected void editButton_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Theme.Color9;
        }

        protected void editButton_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Theme.Color3;
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(Strings.DeleteGroupConfirmation, Strings.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                group.Delete();
                onUpdate();
            }
        }

        protected void deleteButton_MouseLeave(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Theme.Color9;
        }

        protected void deleteButton_MouseEnter(object sender, EventArgs e)
        {
            (sender as Button).BackColor = Theme.Color3;
        }
    }
}
