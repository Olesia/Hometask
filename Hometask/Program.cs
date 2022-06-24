using Hometask;
using Hometask.BLL.Dto;
using Hometask.Common.Interfaces;
using Hometask.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

#region DI Preparations

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
        services.AddStartupServices())
    .Build();

InitialiseDataBase(host.Services);
 
var cartItemService = host.Services.GetRequiredService<ICartItemSevice>();
var itemService = host.Services.GetRequiredService<IItemService>();
var printService = host.Services.GetRequiredService<IPrintService>();

await host.RunAsync();

#endregion

#region Print All Items

Console.WriteLine("All items in the db:");
var itemsList = itemService.GetAllItems().ToList();
printService.PrintItemsList(itemsList);
Console.WriteLine("=========================================");

#endregion

#region Add items to the cart and print

var cartId = Guid.NewGuid();

var cartItemId1 = cartItemService.AddCartItem(new CartItemDto { CartId = cartId, ItemId = itemsList[0].Id, Quantity = 5 });
var cartItemId2 = cartItemService.AddCartItem(new CartItemDto { CartId = cartId, ItemId = itemsList[1].Id, Quantity = 5 });
var cartItemId3 = cartItemService.AddCartItem(new CartItemDto { CartId = cartId, ItemId = itemsList[2].Id, Quantity = 5 });

Console.WriteLine("Next items were added to the cart:");

var cartItemsList = cartItemService.GetCartItemsList();
printService.PrintItemsList(cartItemsList);

Console.WriteLine("=========================================");

#endregion

#region Remove some items from the cart and print

Console.WriteLine("Second item was removed:");

cartItemService.DeleteCartItem(cartItemId2);

var listAfterDelete = cartItemService.GetCartItemsList();
printService.PrintItemsList(listAfterDelete);

#endregion

static void InitialiseDataBase(IServiceProvider services)
{
    using (var scope = services.CreateScope())
    {
        var dbInitialiser = scope.ServiceProvider.GetRequiredService<ApplicationDbContextInitialiser>();
        dbInitialiser.SeedItems();
    }
}