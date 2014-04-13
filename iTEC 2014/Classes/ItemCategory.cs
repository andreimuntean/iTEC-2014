using System.Collections.Generic;

namespace iTEC2014
{
    public class ItemCategory : IData
    {
        public int ItemCategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ItemCategory() { }
        public ItemCategory(int id, string name, string description)
        {
            ItemCategoryId = id;
            Name = name;
            Description = description;
        }

        public List<Item> GetItems()
        {
            return DataManager.GetItems(ItemCategoryId);
        }

        public void Add()
        {
            DataManager.Add<ItemCategory>(this);
        }

        public void Delete()
        {
            DataManager.Delete<ItemCategory>(this);
        }

        public void Update()
        {
            DataManager.Update<ItemCategory>(this);
        }
    }
}
