using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdilliaKP
{
    public class OlgaClient
    {
        public void Register(string fio, int table)
        {
            try
            {
                Client client = new Client
                {                  
                    Table = table,
                    FIO = fio
                };
                OlgaZuravlevaEntities.GetContext().Client.Add(client);
                OlgaZuravlevaEntities.GetContext().SaveChanges();
            }
            catch
            {

            }
        }
    }
}
