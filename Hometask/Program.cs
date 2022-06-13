using Hometask.BLL.Services;

var cartService = new CartService();
var itemService = new ItemsService();
var printService = new PrintService();

itemService.CreateAllItems();
var allExistedItems = itemService.GetAllItems().ToList();

printService.PrintItems(allExistedItems);
Console.WriteLine("=========================================");
var cart = cartService.CreateCart(Guid.NewGuid());

cartService.AddItemToTheCart(cart, allExistedItems[0], 5);
cartService.AddItemToTheCart(cart, allExistedItems[2], 10);
cartService.AddItemToTheCart(cart, allExistedItems[3], 15);

Console.WriteLine("Next items were added to the cart:");
printService.PrintItems(cart.ItemsList.ToList());

Console.WriteLine("=========================================");
Console.WriteLine("Some second item was removed:");
cartService.DeleteItemFromTheCart(cart, allExistedItems[2]);

printService.PrintItems(cart.ItemsList.ToList());
