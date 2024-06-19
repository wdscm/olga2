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
    /// Логика взаимодействия для MenuRedaktor.xaml
    /// </summary>
    public partial class MenuRedaktor : Window
    {
       // private Bluda bluda = new Bluda();

       
        //private Bluda _context;
       
        public MenuRedaktor()
         {
             InitializeComponent();

                        
        }

        private void aaa_Click(object sender, RoutedEventArgs e)
        {
            dishesGrid.ItemsSource = OlgaZuravlevaEntities.GetContext().Dishes.ToList().Where(p => p.title.ToString() == txtName.Text).ToList();
            

        }
        public void Update()
        {
            dishesGrid.ItemsSource = OlgaZuravlevaEntities.GetContext().Dishes.ToList();

        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            Update();
        }

        private void dishesGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
        private void dobavit_Click(object sender, RoutedEventArgs e)//добавить заказ
        {
            redactorDis winAdd = new redactorDis(null);
            winAdd.ShowDialog();
            winAdd.registr = true;
        }

        private void delete_Click(object sender, RoutedEventArgs e)//удаление
        {
            var Delete = dishesGrid.SelectedItems.Cast<Dishes>().ToList();
            if (MessageBox.Show("вы точно хотите удалить ?", "Внимание ", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                try
                {
                   OlgaZuravlevaEntities.GetContext().Dishes.RemoveRange(Delete);
                    OlgaZuravlevaEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }

            }
        }
        private void Window_Activated(object sender, EventArgs e)
        {
            Update();
        }     
        private void btnClos_Click(object sender, RoutedEventArgs e)//переход на авторизацию
        {
            MainWindow cookView = new MainWindow();
            cookView.Show();
            this.Close();
        }
               
    }
}
