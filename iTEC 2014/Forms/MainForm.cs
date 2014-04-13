using System;
using System.Windows.Forms;

namespace iTEC2014
{
    public partial class MainForm : Form
    {
        public Form CurrentView { get; protected set; }
        public bool ViewIsActive { get { return CurrentView != null; } }

        public MainForm()
        {
            InitializeComponent();
            Initialize();
            Load += OnLoad;
        }

        public void Initialize()
        {
            Text = Strings.Title;
            Header.BackColor = Theme.Color7;
        }

        public void SetView(Form form)
        {
            if (ViewIsActive)
            {
                // Clear previous view.
                Body.Controls.Clear();
                MenuPanel.Controls.Clear();
                CurrentView.Dispose();
            }

            form.Dock = DockStyle.Fill;
            form.TopLevel = false;
            Body.Controls.Add(form);
            form.Show();

            if (form is IView)
            {
                // Display menu buttons.
                (form as IView).MenuItems.ForEach(menuItem =>
                {
                    menuItem.Show(MenuPanel);
                });
            }

            CurrentView = form;
        }

        protected void OnLoad(object sender, EventArgs e)
        {
            ViewManager.View = View.Login;
        }
    }
}
