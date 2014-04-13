using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

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
        private static SqlConnection Connection { get; set; }
        private static SqlDataReader Reader { get; set; }
        public static object SelectedObject { get; set; }
        public static User CurrentUser { get; set; }
        public static bool IsLoggedIn { get { return CurrentUser != null; } }

        #region Connection.
        static DataManager()
        {
            Connection = new SqlConnection("Data Source=itec2014db.cloudapp.net;Initial Catalog=itec;Persist Security Info=True;User ID=sa;Password=iTEC2014");
        }

        public static void Open()
        {
            Connection.Open();
        }

        public static void Close()
        {
            Reader.Close();
            Connection.Close();
        }
        #endregion

        #region Logging.
        public static ConnectionStatus Login(string username, string password)
        {
            try
            {
                Open();
                using (var command = new SqlCommand(@"SELECT * FROM Users WHERE Username='" + username + @"' AND Password='" + password + @"'", Connection))
                {
                    Reader = command.ExecuteReader();
                    if (Reader.Read())
                    {
                        int id = (int)Reader["UserId"];
                        string user = (string)Reader["Username"];
                        string firstName = (string)Reader["FirstName"];
                        string lastName = (string)Reader["LastName"];
                        int groupId = (int)Reader["GroupId"];
                        int points = (int)Reader["Points"];
                        string welcomeMessage = (string)Reader["WelcomeMessage"];
                        bool isAdministrator = (bool)Reader["IsAdministrator"];

                        CurrentUser = new User(id, user, password, firstName, lastName, groupId, points, welcomeMessage, isAdministrator);
                        
                        Reader.Close();

                        return ConnectionStatus.Success;
                    }
                    else
                    {
                        Close();
                        return ConnectionStatus.InvalidInput;
                    }
                }
            }
            catch
            {
                Close();
                return ConnectionStatus.TimedOut;
            }
        }

        public static void Logout()
        {
            Close();
            CurrentUser = null;
        }
        #endregion

        #region Getters.
        public static List<ItemCategory> GetCategories()
        {
            try
            {
                var categories = new List<ItemCategory>();
                using (var command = new SqlCommand(@"SELECT * FROM ItemCategories", Connection))
                {
                    Reader = command.ExecuteReader();
                    while (Reader.Read())
                    {
                        int id = (int)Reader["ItemCategoryId"];
                        string name = (string)Reader["Name"];
                        string description = (string)Reader["Description"];

                        categories.Add(new ItemCategory(id, name, description));
                    }
                    
                    Reader.Close();
                }
                return categories;
            }
            catch
            {
                return null;
            }
        }

        public static List<UserGroup> GetGroups()
        {
            try
            {
                var groups = new List<UserGroup>();
                using (var command = new SqlCommand(@"SELECT * FROM UserGroups", Connection))
                {
                    Reader = command.ExecuteReader();
                    while (Reader.Read())
                    {
                        int id = (int)Reader["UserGroupId"];
                        string name = (string)Reader["Name"];
                        string description = (string)Reader["Description"];
                        int points = (int)Reader["Points"];

                        groups.Add(new UserGroup(id, name, description, points));
                    }
                    
                    Reader.Close();
                }
                return groups;
            }
            catch
            {
                return null;
            }
        }

        public static List<Item> GetItems(int itemCategoryId)
        {
            try
            {
                var items = new List<Item>();
                using (var command = new SqlCommand(@"SELECT * FROM Items WHERE CategoryId=" + itemCategoryId.ToString(), Connection))
                {
                    Reader = command.ExecuteReader();
                    while (Reader.Read())
                    {
                        int itemId = (int)Reader["ItemId"];
                        string name = (string)Reader["Name"];
                        string description = (string)Reader["Description"];
                        int points = (int)Reader["Points"];
                        int price = (int)Reader["Price"];

                        items.Add(new Item(itemId, name, description, itemCategoryId, points, price));
                    }

                    Reader.Close();
                }
                return items;
            }
            catch
            {
                return null;
            }
        }

        public static List<Item> GetTopItems()
        {
            try
            {
                var items = new List<Item>();
                using (var command = new SqlCommand(@"SELECT * FROM Items ORDER BY Points DESC", Connection))
                {
                    Reader = command.ExecuteReader();
                    while (Reader.Read())
                    {
                        int itemId = (int)Reader["ItemId"];
                        string name = (string)Reader["Name"];
                        string description = (string)Reader["Description"];
                        int itemCategoryId = (int)Reader["CategoryId"];
                        int points = (int)Reader["Points"];
                        int price = (int)Reader["Price"];

                        items.Add(new Item(itemId, name, description, itemCategoryId, points, price));
                    }

                    Reader.Close();
                }
                return items;
            }
            catch
            {
                return null;
            }
        }

        public static List<User> GetUsers(int userGroupId)
        {
            try
            {
                var users = new List<User>();
                using (var command = new SqlCommand(@"SELECT * FROM Users WHERE GroupId=" + userGroupId.ToString(), Connection))
                {
                    Reader = command.ExecuteReader();
                    while (Reader.Read())
                    {
                        int id = (int)Reader["UserId"];
                        string user = (string)Reader["Username"];
                        string firstName = (string)Reader["FirstName"];
                        string lastName = (string)Reader["LastName"];
                        int groupId = (int)Reader["GroupId"];
                        int points = (int)Reader["Points"];
                        string welcomeMessage = (string)Reader["WelcomeMessage"];
                        bool isAdministrator = (bool)Reader["IsAdministrator"];

                        users.Add(new User(id, user, "", firstName, lastName, groupId, points, welcomeMessage, isAdministrator));
                    }

                    Reader.Close();
                }
                return users;
            }
            catch
            {
                return null;
            }
        }

        public static User GetUser(int userId)
        {
            try
            {
                User result = null;
                using (var command = new SqlCommand(@"SELECT * FROM Users WHERE UserId=" + userId.ToString(), Connection))
                {
                    Reader = command.ExecuteReader();
                    if (Reader.Read())
                    {
                        int id = (int)Reader["UserId"];
                        string userName = (string)Reader["Username"];
                        string firstName = (string)Reader["FirstName"];
                        string lastName = (string)Reader["LastName"];
                        int groupId = (int)Reader["GroupId"];
                        int points = (int)Reader["Points"];
                        string welcomeMessage = (string)Reader["WelcomeMessage"];
                        bool isAdministrator = (bool)Reader["IsAdministrator"];

                        result = new User(id, userName, "", firstName, lastName, groupId, points, welcomeMessage, isAdministrator);
                    }

                    Reader.Close();
                }
                return result;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region Update.
        public static ConnectionStatus Update<T>(T value)
        {
            try
            {
                if (value is User)
                {
                    var user = value as User;

                    if (user.Password.Length == 0)
                    {

                        using (var command = new SqlCommand(@"UPDATE Users SET
                                                    UserId = " + user.UserId.ToString() + @",
                                                    GroupId = " + user.GroupId.ToString() + @",
                                                    Username = '" + user.Username + @"',
                                                    FirstName = '" + user.FirstName + @"',
                                                    LastName = '" + user.LastName + @"',
                                                    WelcomeMessage = '" + user.WelcomeMessage + @"',
                                                    IsAdministrator = '" + user.IsAdministrator.ToString() + @"',
                                                    Points = " + user.Points.ToString() + " WHERE UserId=" + (SelectedObject as User).UserId.ToString(), Connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        using (var command = new SqlCommand(@"UPDATE Users SET
                                                    UserId = " + user.UserId.ToString() + @",
                                                    GroupId = " + user.GroupId.ToString() + @",
                                                    Username = '" + user.Username + @"',
                                                    FirstName = '" + user.FirstName + @"',
                                                    LastName = '" + user.LastName + @"',
                                                    Password = '" + user.Password + @"',
                                                    WelcomeMessage = '" + user.WelcomeMessage + @"',
                                                    IsAdministrator = '" + user.IsAdministrator.ToString() + @"',
                                                    Points = " + user.Points.ToString() + " WHERE UserId=" + (SelectedObject as User).UserId.ToString(), Connection))
                        {
                            command.ExecuteNonQuery();
                        }
                    }
                }
                else if (value is Item)
                {
                    var item = value as Item;

                    using (var command = new SqlCommand(@"UPDATE Items SET
                                                    ItemId = " + item.ItemId.ToString() + @",
                                                    Name = '" + item.Name + @"',
                                                    Description = '" + item.Description + @"',
                                                    CategoryId = " + item.CategoryId + @",
                                                    Points = " + item.Points.ToString() + @",
                                                    Price = " + item.Price.ToString() + " WHERE ItemId=" + (SelectedObject as Item).ItemId.ToString(), Connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                else if (value is UserGroup)
                {
                    var userGroup = value as UserGroup;

                    using (var command = new SqlCommand(@"UPDATE UserGroups SET
                                                    UserGroupId = " + userGroup.UserGroupId.ToString() + @",
                                                    Name = '" + userGroup.Name + @"',
                                                    Description = '" + userGroup.Description + @"',
                                                    Points = " + userGroup.Points + " WHERE UserGroupId=" + (SelectedObject as UserGroup).UserGroupId.ToString(), Connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SqlCommand(@"UPDATE Users SET UserGroupId = " + userGroup.UserGroupId.ToString() + " WHERE UserGroupId = " + (SelectedObject as UserGroup).UserGroupId.ToString(), Connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                else if (value is ItemCategory)
                {
                    var itemCategory = value as ItemCategory;

                    using (var command = new SqlCommand(@"UPDATE ItemCategories SET
                                                    ItemCategoryId = " + itemCategory.ItemCategoryId.ToString() + @",
                                                    Name = '" + itemCategory.Name + @"',
                                                    Description = '" + itemCategory.Description + "' WHERE ItemCategoryId=" + (SelectedObject as ItemCategory).ItemCategoryId.ToString(), Connection))
                    {
                        command.ExecuteNonQuery();
                    }

                    using (var command = new SqlCommand(@"UPDATE Items SET ItemCategoryId = " + itemCategory.ItemCategoryId.ToString() + " WHERE ItemCategoryId = " + (SelectedObject as ItemCategory).ItemCategoryId.ToString(), Connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }

                return ConnectionStatus.Success;
            }
            catch
            {
                return ConnectionStatus.TimedOut;
            }
        }
        #endregion

        #region Delete.
        private static ConnectionStatus Delete(string table, string condition)
        {
            try
            {
                using (var command = new SqlCommand("DELETE FROM " + table + " WHERE " + condition, Connection))
                {
                    command.ExecuteNonQuery();
                    return ConnectionStatus.Success;
                }
            }
            catch
            {
                return ConnectionStatus.TimedOut;
            }
        }

        public static ConnectionStatus Delete<T>(T value)
        {
            var connectionStatus = ConnectionStatus.TimedOut;

            if (value is User)
            {
                connectionStatus = DataManager.Delete("Users", "UserId=" + (value as User).UserId.ToString());
            }
            else if (value is UserGroup)
            {
                connectionStatus = DataManager.Delete("UserGroups", "UserGroupId=" + (value as UserGroup).UserGroupId.ToString());
                
                if (connectionStatus == ConnectionStatus.Success)
                {
                    connectionStatus = DataManager.Delete("Users", "GroupId=" + (value as UserGroup).UserGroupId.ToString());
                }
            }
            else if (value is Item)
            {
                connectionStatus = DataManager.Delete("Items", "ItemId=" + (value as Item).ItemId.ToString());
            }
            else if (value is ItemCategory)
            {
                connectionStatus = DataManager.Delete("ItemCategories", "ItemCategoryId=" + (value as ItemCategory).ItemCategoryId.ToString());
                
                if (connectionStatus == ConnectionStatus.Success)
                {
                    connectionStatus = DataManager.Delete("Items", "CategoryId=" + (value as ItemCategory).ItemCategoryId.ToString());
                }
            }

            return connectionStatus;
        }
        #endregion

        #region Add.
        public static ConnectionStatus Add<T>(T value)
        {
            var connectionStatus = ConnectionStatus.TimedOut;

            if (value is User)
            {
                var user = value as User;

                using (var command = new SqlCommand(@"INSERT INTO Users (UserId, GroupId, Username, FirstName, LastName, Password, WelcomeMessage, IsAdministrator, Points)
                                                    VALUES (" + user.UserId.ToString() + ", " + user.GroupId.ToString() + @", '" + user.Username + @"', '" + user.FirstName + @"', '" + user.LastName + @"', '" + user.Password + @"', '" + user.WelcomeMessage + @"', '" + user.IsAdministrator.ToString() + "', " + user.Points.ToString() + ")", Connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            else if (value is UserGroup)
            {
                var userGroup = value as UserGroup;

                using (var command = new SqlCommand(@"INSERT INTO UserGroups (UserGroupId, Name, Description, Points)
                                                    VALUES (" + userGroup.UserGroupId.ToString() + @", '" + userGroup.Name + @"', '" + userGroup.Description + @"', " + userGroup.Points.ToString() + ")", Connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            else if (value is Item)
            {
                var item = value as Item;

                using (var command = new SqlCommand(@"INSERT INTO Items (ItemId, Name, Description, CategoryId, Points, Price)
                                                    VALUES (" + item.ItemId.ToString() + @", '" + item.Name + @"', '" + item.Description + @"', " + item.CategoryId.ToString() + ", " + item.Points.ToString() + ", " + item.Price.ToString() + ")", Connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            else if (value is ItemCategory)
            {
                var itemCategory = value as ItemCategory;

                using (var command = new SqlCommand(@"INSERT INTO ItemCategories (ItemCategoryId, Name, Description)
                                                    VALUES (" + itemCategory.ItemCategoryId.ToString() + @", '" + itemCategory.Name + @"', '" + itemCategory.Description + @"')", Connection))
                {
                    command.ExecuteNonQuery();
                }
            }

            return connectionStatus;
        }
        #endregion
    }
}
