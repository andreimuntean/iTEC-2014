namespace iTEC2014
{
    public class User : IData
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GroupId { get; set; }
        public int Points { get; set; }
        public string WelcomeMessage { get; set; }
        public bool IsAdministrator { get; set; }

        public User() { }
        
        public User(int id, string username, string password, string firstName, string lastName, int groupId, int points, string welcomeMessage, bool isAdministrator)
        {
            UserId = id;
            Username = username;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
            GroupId = groupId;
            Points = points;
            WelcomeMessage = welcomeMessage;
            IsAdministrator = isAdministrator;
        }

        public void Add()
        {
            DataManager.Add<User>(this);
        }

        public void Delete()
        {
            DataManager.Delete<User>(this);
        }

        public void Update()
        {
            DataManager.Update<User>(this);
            DataManager.CurrentUser = DataManager.GetUser(UserId);
        }

        public void Vote(Item item)
        {
            if (Points > 0)
            {
                item.IncreasePoints();

                DataManager.SelectedObject = this;
                Points--;
                Update();
            }
        }
    }
}
