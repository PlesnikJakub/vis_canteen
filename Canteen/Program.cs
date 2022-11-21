// See https://aka.ms/new-console-template for more information
using Canteen.Application.TableModule;
using Canteen.Application.TransactionScript;

Console.WriteLine("Hello, World!");

var items = new GetAllMenuItems().Execute();

foreach (var item in items)
{
    Console.Write(item.Id + " "); 
    Console.Write(item.Title);
    Console.WriteLine();
}

var tablemodule = new MenuItemTM();

var newItemId = new CreateMenuItem().Execute("hotdog", 150, false);
Console.WriteLine(newItemId);

var hotdog = tablemodule.GetById(newItemId);
Console.WriteLine("Original Price: " + hotdog.Price);

tablemodule.Update(hotdog.Id, hotdog.Title, 125, hotdog.IsVegan);

hotdog = tablemodule.GetById(newItemId);
Console.WriteLine("Changed Price: " + hotdog.Price);

tablemodule.Delete(newItemId);
