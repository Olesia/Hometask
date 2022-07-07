namespace Hometask.DAL.Entities;

public class Cart
{
    public string Id { get; set; }
    public IEnumerable<CartItem> Items { get; set; }
}
