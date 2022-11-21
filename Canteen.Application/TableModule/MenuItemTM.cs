using Canteen.Application.DTO;
using Canteen.Application.Exceptions;
using Canteen.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen.Application.TableModule
{
    public class MenuItemTM
    {
        private readonly MenuItemTDG _menuItemTDG;
        public MenuItemTM()
        {
            _menuItemTDG = new MenuItemTDG();
        }

        public MenuItemDTO GetById(int id)
        {
            var table = _menuItemTDG.GetById(id);

            if(table.Rows.Count == 0)
            {
                throw new EntityNotFoundExeption();
            }

            var row = table.Rows[0];
            return new MenuItemDTO
            {
                Id = Convert.ToInt32(row["id"]),
                Title = row["title"]?.ToString() ?? "",
                Price = Convert.ToDouble(row["price"]),
                IsVegan = Convert.ToBoolean(row["is_vegan"])
            };
        }

        public IEnumerable<MenuItemDTO> GetAll()
        {
            var table = _menuItemTDG.GetAll();
            List<MenuItemDTO> result = new();

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

        public int Create(string title, double price, bool isVegan)
        {
            return _menuItemTDG.Create(title, price, isVegan);
        }

        public bool Update(int id, string title, double price, bool isVegan)
        {
            return _menuItemTDG.Update(id, title, price, isVegan);
        }

        public bool Delete(int id)
        {
            return _menuItemTDG.Delete(id);
        }
    }
}
