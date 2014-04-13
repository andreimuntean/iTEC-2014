using System;
using System.Windows.Forms;

namespace iTEC2014
{
    static class NotificationManager
    {
        public static void Alert(string message)
        {
            MessageBox.Show(message, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void LogException(string message)
        {
            MessageBox.Show(message, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        public static void LogException(Exception exception)
        {
            MessageBox.Show(exception.Message, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
