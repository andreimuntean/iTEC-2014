namespace iTEC2014
{
    public class Item : IData
    {
        public int ItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int Points { get; set; }
        public int Price { get; set; }

        public Item() { }

        public Item(int itemId, string name, string description, int categoryId, int points, int price)
        {
            ItemId = itemId;
            Name = name;
            Description = description;
            CategoryId = categoryId;
            Points = points;
            Price = price;
        }

        public void IncreasePoints()
        {
            DataManager.SelectedObject = this;
            Points++;
            Update();
        }

        public void ResetPoints()
        {
            DataManager.SelectedObject = this;
            Points = 0;
            Update();
        }

        public void Add()
        {
            DataManager.Add<Item>(this);
        }

        public void Delete()
        {
            DataManager.Delete<Item>(this);
        }

        public void Update()
        {
            DataManager.Update<Item>(this);
        }
    }
}
