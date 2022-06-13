namespace Hometask.DAL.Entities
{
    internal class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
