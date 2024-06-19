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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IdilliaKP
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();          
        }

        private void btnLogin1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OlgaStaff mizeQStaff = new OlgaStaff();
                string login = txtLogin.Text;
                string password = txtPass.Text;
                int IdRole;
                if (mizeQStaff.Authorization(login, password, out IdRole))
                {
                    switch (IdRole)
                    {
                        case 1:
                            {
                                AdminView admin = new AdminView();
                                MessageBox.Show($"Добро пожаловать, {login} ! Вы зашли как - Администратор!");
                                admin.Show();
                                this.Close();
                            }
                            break;
                        case 2:
                            {
                               MenuRedaktor povar = new MenuRedaktor();
                                MessageBox.Show($"Добро пожаловать, {login} ! Вы зашли как - Повар!");
                                povar.Show();
                                this.Close();
                            }
                            break;
                            case 3:
                            {
                               zakaz povar = new zakaz();
                                MessageBox.Show($"Добро пожаловать, {login} ! Вы зашли как - Официант!");
                                povar.Show();
                                this.Close();
                            }
                            break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Что-то пошло не так!");
                return;
            }

        }
    }
}
