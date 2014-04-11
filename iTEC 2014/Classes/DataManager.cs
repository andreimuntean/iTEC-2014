namespace iTEC2014
{
    public enum ConnectionStatus
    {
        Success,
        TimedOut,
        InvalidInput
    }

    static class DataManager
    {
        public static User CurrentUser { get; private set; }
        public static bool IsLoggedIn { get { return CurrentUser != null; } }

        public static ConnectionStatus Login(string username, string password)
        {

            return ConnectionStatus.Success;
        }
    }
}
