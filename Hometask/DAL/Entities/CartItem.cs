
using Hometask.Shared;

namespace Hometask.DAL.Entities
{
    public class CartItem : BaseEntity
    {
        public Guid Id { get; set; }
        public int ExternalId { get; set; }
        public string CartId { get; set; }
        public string Name { get; set; }    
        public string? Image { get; set; }   
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
