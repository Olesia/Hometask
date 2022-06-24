using Hometask.Shared;

namespace Hometask.DAL.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }
        public float Price { get; set; }
        public int Quantity { get; set; }
    }
}
