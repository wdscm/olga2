using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace IdilliaKP
{
    /// <summary>
    /// Логика взаимодействия для AddUsers.xaml
    /// </summary>
    public partial class AddUsers : Window
    {
        private Staff u = new Staff();
        public AddUsers(Staff _context)
        {
            InitializeComponent();

            if (_context != null)
            {
                u = _context;
            }
            cmbRole.ItemsSource = OlgaZuravlevaEntities.GetContext().Role.ToList();
            DataContext = u;//для привязки

           // DataContext = _context;

            
        }
        public bool registr = false;
        private void Button_Click(object sender, RoutedEventArgs e)//создание нового пользователя
        {
            OlgaStaff olgaStaff = new OlgaStaff();
            string login = txtLogin.Text;
            string password = txtPass.Text;
            string fio = txtFIO.Text;
            olgaStaff.Register(login, fio, password, cmbRole.SelectedIndex + 1);
            this.Close();
        }

        
    }
}
