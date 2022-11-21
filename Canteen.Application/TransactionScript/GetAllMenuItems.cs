using Canteen.DataAccess;
using System.Data;

namespace Canteen.Application.TransactionScript
{
    public class GetAllMenuItems
    {
        private readonly MenuItemTDG _menuItemTDG;
        public GetAllMenuItems()
        {
            _menuItemTDG = new MenuItemTDG();
        }

        public IEnumerable<string> Execute()
        {
            var table = _menuItemTDG.GetAll();
            List<string> result = new ();

            foreach (DataRow row in table.Rows)
            {
                result.Add(row["title"]?.ToString() ?? "");
            }

            return result;
        }
    }
}
