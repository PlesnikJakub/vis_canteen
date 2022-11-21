using Canteen.Application.DTO;
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

        public IEnumerable<MenuItemDTO> Execute()
        {
            var table = _menuItemTDG.GetAll();
            List<MenuItemDTO> result = new ();

            foreach (DataRow row in table.Rows)
            {
                var item = new MenuItemDTO
                {
                    Id = Convert.ToInt32(row["id"]),
                    Title = row["title"]?.ToString() ?? "",
                    Price = Convert.ToDouble(row["price"]),
                    IsVegan = Convert.ToBoolean(row["is_vegan"])
                };
                result.Add(item);
            }

            return result;
        }
    }
}
