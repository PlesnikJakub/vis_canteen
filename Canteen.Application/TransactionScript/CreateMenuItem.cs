using Canteen.DataAccess;

namespace Canteen.Application.TransactionScript
{
    public class CreateMenuItem
    {
        private readonly MenuItemTDG _menuItemTDG;
        public CreateMenuItem()
        {
            _menuItemTDG = new MenuItemTDG();
        }

        public int Execute(string title, double price, bool isVegan)
        {
            return _menuItemTDG.Create(title, price, isVegan);
        }
    }
}
