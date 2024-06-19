using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdilliaKP
{
    public class OlgaStaff
    {
        private List<Staff> _staffs;
        public OlgaStaff()
        {
            _staffs = new List<Staff>();
            // инициализация списка пользователей
        }
        public bool Authorization(string login, string password, out int idRole)
        {
            Staff staff = OlgaZuravlevaEntities.GetContext().Staff.Where(s => s.login == login && s.password == password).FirstOrDefault();
            if (staff != null)
            {
                idRole = staff.ID_Role;
                return true;
            }
            else
            {
                idRole = 0;
                return false;
            }
        }
        public void Register(string login, string fio, string password, int roleId)
        {
            try
            {
                Staff staff = new Staff
                {
                    login = login,
                    password = password,
                    ID_Role = roleId,
                    FIO = fio
                };
                OlgaZuravlevaEntities.GetContext().Staff.Add(staff);
                OlgaZuravlevaEntities.GetContext().SaveChanges();
            }
            catch
            {

            }
        }
    }
}
