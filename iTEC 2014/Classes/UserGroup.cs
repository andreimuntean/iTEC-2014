using System.Collections.Generic;

namespace iTEC2014
{
    public class UserGroup : IData
    {
        public int UserGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Points { get; set; }

        public UserGroup() { }
        public UserGroup(int id, string name, string description, int points)
        {
            UserGroupId = id;
            Name = name;
            Description = description;
            Points = points;
        }

        public List<User> GetUsers()
        {
            return DataManager.GetUsers(UserGroupId);
        }

        public void Add()
        {
            DataManager.Add<UserGroup>(this);
        }

        public void Delete()
        {
            DataManager.Delete<UserGroup>(this);
        }

        public void Update()
        {
            DataManager.Update<UserGroup>(this);
        }
    }
}
