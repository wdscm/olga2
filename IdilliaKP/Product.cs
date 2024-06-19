using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdilliaKP
{
  public class Product
    {
        public void Register(string title, int price, int roleId)
        {
            try
            {
                Dishes dishes = new Dishes
                {
                    title = title,
                    Price = price,
                    ID_category = roleId,                  
                };

                OlgaZuravlevaEntities.GetContext().Dishes.Add(dishes);
                OlgaZuravlevaEntities.GetContext().SaveChanges();
            }
            catch
            {

            }
        }
    }
}
