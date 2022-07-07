
namespace Hometask.BLL.Dto
{
    public class CartDto
    {
        public string Id { get; set; }
        public IEnumerable<CartItemDto> CartItems { get; set; }
    }
}
