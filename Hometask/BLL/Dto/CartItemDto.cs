namespace Hometask.BLL.Dto
{
    public class CartItemDto
    {
        public Guid Id { get; set; }
        public Guid CartId { get; set; }
        public Guid ItemId { get; set; }
        public int Quantity { get; set; }
    }
}
