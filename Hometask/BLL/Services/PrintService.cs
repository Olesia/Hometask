using Hometask.BLL.Dto;

namespace Hometask.BLL.Services
{
    internal class PrintService
    {
        public void PrintItems(List<ItemDto> items)
        {
            foreach(var item in items)
            {
                Console.WriteLine($"Name: {item.Name}, Price: {item.Price}$");
            }
        }
    }
}
