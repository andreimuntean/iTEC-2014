using System;
using System.Drawing;
using System.Windows.Forms;

namespace iTEC2014
{
    class AdminItemButton
    {
        private Action onUpdate;
        private Item item;
        private Panel panel;

        public AdminItemButton(Item item, int index, Action onUpdate)
        {
            this.onUpdate = onUpdate;
            this.item = item;

            panel = new Panel()
            {
                BackColor = Theme.Color8,
                Height = 75,
                Width = 455,
                Location = new Point(5, index * 81),
            };

            var deleteButton = new Button()
            {
                BackColor = Theme.Color9,
                ForeColor = Theme.Color1,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Calibri", 13),
                Height = 75,
                Width = 75,
                Location = new Point(305, 0),
                Text = Strings.Delete
            };

            deleteButton.FlatAppearance.BorderSize = 0;

            var editButton = new Button()
            {
                BackColor = Theme.Color9,
                ForeColor = Theme.Color1,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Calibri", 13),
                Height = 75,
                Width = 75,
                Location = new Point(385, 0),
                Text = Strings.Edit
            };

            editButton.FlatAppearance.BorderSize = 0;

            var name = new Label()
            {
                ForeColor = Theme.Color4,
                Font = new Font("Calibri", 15),
                Height = 30,
                Width = 375,
                Location = new Point(10, 15),
                Text = item.Name.ToUpper() + " - " + item.Price + " " + CurrencyManager.Name
            };

            var description = new Label()
            {
                ForeColor = Theme.Color6,
                Font = new Font("Calibri", 12),
                Height = 20,
                Width = 375,
                Location = new Point(10, 40),
                Text = item.Description
            };

            deleteButton.Click += deleteButton_Click;
            editButton.Click += editButton_Click;

            panel.Controls.Add(deleteButton);
            panel.Controls.Add(editButton);
            panel.Controls.Add(name);
            panel.Controls.Add(description);
            name.Show();
            description.Show();
        }

        public void Show(Control parent)
        {
            parent.Controls.Add(panel);
        }

        public void IndexIn(Control parent)
        {
            parent.Controls.IndexOf(panel);
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            item.Delete();
            onUpdate();
        }

        protected void editButton_Click(object sender, EventArgs e)
        {
            DataManager.SelectedObject = item;
            ViewManager.View = View.ItemEdit;
        }
    }
}
