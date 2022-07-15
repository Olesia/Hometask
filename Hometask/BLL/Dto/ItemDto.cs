namespace Hometask.BLL.Dto
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }

        public decimal Price { get; set; }
        public uint Amount { get; set; }
        public int CategoryId { get; set; }
    }
}
