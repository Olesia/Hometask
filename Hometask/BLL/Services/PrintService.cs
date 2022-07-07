using Hometask.BLL.Dto;
using Hometask.Common.Interfaces;

namespace Hometask.BLL.Services
{
    public class PrintService : IPrintService
    {
        public void PrintItem(CartItemDto cartItem)
        {
            Console.WriteLine($"Name: {cartItem.Name}, Price: {cartItem.Price}$");
        }

        public void PrintItemsList(IEnumerable<CartItemDto> itemsList)
        {
            foreach(var item in itemsList)
            {
                PrintItem(item);
            }
        }
    }
}
