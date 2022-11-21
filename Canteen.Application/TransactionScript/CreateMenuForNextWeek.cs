using Canteen.DataAccess;

namespace Canteen.Application.TransactionScript
{
    public class CreateMenuForNextWeek
    {
        private readonly MenuItemTDG _menuItemTDG;
        public CreateMenuForNextWeek()
        {
            _menuItemTDG = new MenuItemTDG();
        }

        public void Execute()
        {
            // TODO get all items and generate menu
            // there must be one item cheaper than 100
            // there must be atleas one vegan item per day but no more than 2
            // generate menu for 5 day 4 meals per day
            // dont repeat food in a week
        }
    }
}
