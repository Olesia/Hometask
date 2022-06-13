
namespace Hometask.DAL.Entities
{
    internal class CartItem
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid ItemId { get; set; }
        public int QuantityInTheCart { get; set; }
    }
}
