using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace iTEC2014
{
    public partial class ReportForm : Form, IView
    {
        public List<MenuItem> MenuItems { get; set; }

        public ReportForm()
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
            budgetLabel.Text = Strings.Budget;
            generateButton.Text = Strings.GenerateReport;

            // Panel formatting.
            statusPanel.BackColor = Theme.Color7;
            bodyPanel.BackColor = Theme.Color7;

            // Text formatting.
            managementLabel.ForeColor = Theme.Color4;
            descriptionLabel.ForeColor = Theme.Color1;
            budgetLabel.ForeColor = Theme.Color1;

            // Button formatting.
            generateButton.BackColor = Theme.Color4;
            generateButton.ForeColor = Theme.Color1;
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Workbook (*.xls)|*.xls";
                    saveFileDialog.DefaultExt = ".xls";
                    var result = saveFileDialog.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        if (saveFileDialog.FileName != null)
                        {
                            double budget;
                            if (!double.TryParse(budgetTextBox.Text, out budget))
                                budget = 0;

                            FileManager.GenerateReport(saveFileDialog.FileName, budget);
                            NotificationManager.Alert(Strings.ReportGenerated);
                        }
                        else
                        {
                            NotificationManager.LogException(Strings.InvalidPath);
                        }
                    }
                }
            }
            catch
            {
                NotificationManager.LogException(Strings.ReportGenerationFailure);
            }
        }
    }
}
