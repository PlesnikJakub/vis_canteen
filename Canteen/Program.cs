// See https://aka.ms/new-console-template for more information
using Canteen.Application.TransactionScript;

Console.WriteLine("Hello, World!");

var items = new GetAllMenuItems().Execute();

foreach (var item in items)
{
    Console.WriteLine(item);
}