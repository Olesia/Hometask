namespace Hometask.BLL.Dto
{
    internal class CartDto
    {
        public Guid Id { get; set; }
        public IList<ItemDto> ItemsList { get; set; }

        public CartDto()
        {
            ItemsList = new List<ItemDto>();
        }
    }
}
