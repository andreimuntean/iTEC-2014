using System;
using System.Drawing;
using System.Windows.Forms;

namespace iTEC2014
{
    public class MenuItem : IDisposable
    {
        private Action action;
        private Button button;

        private Point location;
        public Point Location
        {
            get { return location; }
            set
            {
                location = value;
                button.Location = location;
            }
        }
        public int X { get { return Location.X; } }
        public int Y { get { return Location.Y; } }

        public MenuItem(string text, int index, View target)
        {
            Constructor(text, index, () => { ViewManager.View = target; });
        }

        public MenuItem(string text, int index, Action action)
        {
            Constructor(text, index, action);
        }

        protected void Constructor(string text, int index, Action action)
        {
            this.action = action;

            button = new Button() { Height = 76, Width = 100 };
            button.BackColor = Theme.Color7;
            button.ForeColor = Theme.Color6;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.Font = new Font(new FontFamily("Calibri"), 14);
            button.Text = text;
            button.UseVisualStyleBackColor = false;

            button.MouseEnter += button_MouseEnter;
            button.MouseLeave += button_MouseLeave;

            Location = new Point(300 + index * 100, 0);
        }

        public void Show(Control parent)
        {
            parent.Controls.Add(button);
        }

        public void Dispose()
        {
            button.Dispose();
        }

        protected void button_MouseLeave(object sender, EventArgs e)
        {
            button.BackColor = Theme.Color7;
            button.ForeColor = Theme.Color6;
        }

        protected void button_MouseEnter(object sender, EventArgs e)
        {
            button.BackColor = Theme.Color3;
            button.ForeColor = Theme.Color5;
        }
    }
}
