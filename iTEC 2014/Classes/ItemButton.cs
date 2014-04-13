using System;
using System.Drawing;
using System.Windows.Forms;

namespace iTEC2014
{
    class ItemButton
    {
        private Action action;
        private Item item;
        private Panel panel;
        private Label points;

        public ItemButton(Item item, int index, Action action)
        {
            this.action = action;
            this.item = item;

            panel = new Panel()
            {
                BackColor = Theme.Color8,
                Height = 75,
                Width = 455,
                Location = new Point(5, index * 81),
            };

            var button = new Button()
            {
                BackColor = Theme.Color9,
                ForeColor = Theme.Color1,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Calibri", 13),
                Height = 55,
                Width = 75,
                Location = new Point(0, 0),
                Text = Strings.Vote
            };

            button.FlatAppearance.BorderSize = 0;

            points = new Label()
            {
                ForeColor = Theme.Color6,
                Font = new Font("Calibri", 12),
                Height = 20,
                Width = 75,
                Location = new Point(0, 55),
                Text = item.Points.ToString(),
                TextAlign = ContentAlignment.MiddleCenter
            };

            var name = new Label()
            {
                ForeColor = Theme.Color4,
                Font = new Font("Calibri", 15),
                Height = 30,
                Width = 440,
                Location = new Point(85, 15),
                Text = item.Name.ToUpper() + " - " + item.Price + " " + CurrencyManager.Name
            };

            var description = new Label()
            {
                ForeColor = Theme.Color6,
                Font = new Font("Calibri", 12),
                Height = 20,
                Width = 440,
                Location = new Point(85, 40),
                Text = item.Description
            };

            button.Click += button_Click;

            panel.Controls.Add(button);
            panel.Controls.Add(points);
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

        protected void button_Click(object sender, EventArgs e)
        {
            action();
            points.Text = item.Points.ToString();
        }
    }
}
