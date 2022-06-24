using Hometask.BLL.Dto;
using Hometask.Common.Interfaces;

namespace Hometask.BLL.Services
{
    public class PrintService : IPrintService
    {
        public void PrintItem(ItemDto item)
        {
            Console.WriteLine($"Name: {item.Name}, Price: {item.Price}$");
        }

        public void PrintItemsList(IEnumerable<ItemDto> itemsList)
        {
            foreach(var item in itemsList)
            {
                PrintItem(item);
            }
        }
    }
}
