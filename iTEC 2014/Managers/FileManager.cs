using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace iTEC2014
{
    static class FileManager
    {
        public static string RootPath { get { return ""; } }
        public static void OpenHelp()
        {
            try
            {
                Process.Start(RootPath + "Documentation.rtf");
            }
            catch
            {
                NotificationManager.LogException(Strings.CannotFindHelpFile);
            }
        }

        public static void GenerateReport(string path, double budget)
        {
            // Excel indexing starts from 1, not 0.
            // Yep. NOT EVEN KIDDING RIGHT NOW.

            Excel.Application excel = null;
            Excel._Workbook workbook = null;
            Excel._Worksheet sheet = null;

            bool SaveChanges = false;
            try
            {
                if (File.Exists(path))
                    File.Delete(path);

                GC.Collect();

                // Instantiate Excel.
                excel = new Excel.Application() { Visible = false };

                // Create Workbook.
                workbook = (Excel._Workbook)(excel.Workbooks.Add(Missing.Value));
                sheet = (Excel._Worksheet)(workbook.Sheets[1]);
                
                sheet.Name = "Items";

                sheet.Cells[2, 4] = "HIGHEST";
                sheet.Cells[2, 5] = "RATED";

                sheet.Cells[3, 2] = "POINTS";
                sheet.Cells[3, 3] = "PRICE";
                sheet.Cells[3, 4] = "NAME";
                sheet.Cells[3, 5] = "DESCRIPTION";
                sheet.Cells[3, 6] = "CATEGORY ID";
                sheet.Cells[3, 7] = "ITEM ID";

                var items = DataManager.GetTopItems();

                for (int i = 0; i < items.Count && i <= 100; ++i)
                {
                    sheet.Cells[i + 4, 2] = items[i].Points;
                    sheet.Cells[i + 4, 3] = items[i].Price;
                    sheet.Cells[i + 4, 4] = items[i].Name;
                    sheet.Cells[i + 4, 5] = items[i].Description;
                    sheet.Cells[i + 4, 6] = items[i].CategoryId;
                    sheet.Cells[i + 4, 7] = items[i].ItemId;
                }

                if (budget > 0)
                {
                    workbook.Sheets.Add(Missing.Value);
                    sheet = (Excel._Worksheet)(workbook.Sheets[1]);
                    
                    sheet.Name = "Budget";

                    sheet.Cells[2, 2] = "NAME";
                    sheet.Cells[2, 3] = "PRICE";

                    var costs = BudgetManager.CalculateOptimalBudget(items, budget);

                    for (int i = 0; i < costs.Count && i <= 100; ++i)
                    {
                        sheet.Cells[i + 3, 2] = costs[i].Name;
                        sheet.Cells[i + 3, 3] = costs[i].Price.ToString() + " " + CurrencyManager.Current;
                    }
                }

                // Release Excel file.
                excel.Visible = false;
                excel.UserControl = false;
                SaveChanges = true;

                // Save file.
                workbook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal,
                          null, null, false, false, Excel.XlSaveAsAccessMode.xlShared,
                          false, false, null, null, null);

            }
            catch { }
            finally
            {
                // Make sure everything is disposed.
                try
                {
                    excel.Visible = false;
                    excel.UserControl = false;
                    workbook.Close(SaveChanges, null, null);
                    excel.Workbooks.Close();
                }
                catch { }

                excel.Quit();

                if (sheet != null) { Marshal.ReleaseComObject(sheet); }
                if (workbook != null) { Marshal.ReleaseComObject(workbook); }
                if (excel != null) { Marshal.ReleaseComObject(excel); }

                sheet = null;
                workbook = null;
                excel = null;
                GC.Collect();
            }
        }
    }
}
