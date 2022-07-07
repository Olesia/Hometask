namespace Hometask.BLL.Dto
{
    public class CartItemDto
    {
        public int ExternalId { get; set; }
        public string CartId { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
