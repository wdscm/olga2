using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для AdminView.xaml
    /// </summary>
    public partial class AdminView : Window
    {
        public AdminView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)//поиск пользователя
        {
            usersGrid.ItemsSource = OlgaZuravlevaEntities.GetContext().Staff.ToList().Where(p => p.login.ToString() == txtName.Text).ToList();
        }

      
      

        public void Update()
        {
            usersGrid.ItemsSource = OlgaZuravlevaEntities.GetContext().Staff.ToList();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)// добавить нового пользователя
        {
            AddUsers winAdd = new AddUsers(null);
            winAdd.ShowDialog();
            winAdd.registr = true;

        }
        private void Button_Click4(object sender, RoutedEventArgs e)// удаление 
        {
            var userDelete = usersGrid.SelectedItems.Cast<Staff>().ToList();
            if (MessageBox.Show("вы точно хотите удалить ?", "Внимание ", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                   OlgaZuravlevaEntities.GetContext().Staff.RemoveRange(userDelete);
                    OlgaZuravlevaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }


        private void usersGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Activated_1(object sender, EventArgs e)
        {
            Update();
        }

        private void btnClos_Click(object sender, RoutedEventArgs e)//переход наавторизацию
        {
            MainWindow cookView = new MainWindow();
            cookView.Show();
            this.Close();
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
