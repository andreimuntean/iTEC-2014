using System.Windows.Forms;

namespace iTEC2014
{
    public partial class MainForm : Form
    {
        public Form CurrentForm { get; protected set; }
        public bool IsViewingForm { get { return CurrentForm != null; } }

        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }

        public void Initialize()
        {
            Text = Strings.Title;
            Header.BackColor = Theme.Color7;
            SetView(new LoginForm());
        }

        public void SetView(Form form)
        {
            if (IsViewingForm)
            {
                Body.Controls.Clear();

                for (int i = 0; i < Header.Controls.Count; ++i)
                {
                    if (Header.Controls[i] is Button)
                    {
                        Header.Controls.RemoveAt(i);
                    }
                }
                CurrentForm.Dispose();
            }

            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            Body.Controls.Add(form);
            form.Show();

            if (form is IView)
            {
                (form as IView).MenuItems.ForEach(menuItem =>
                {
                    menuItem.Show(Header);
                });
            }

            CurrentForm = form;
        }
    }
}
