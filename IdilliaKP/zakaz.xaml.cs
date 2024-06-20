using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для zakaz.xaml
    /// </summary>
    public partial class zakaz : Window
    {
        private Order ordreBUY;
        private OlgaZuravlevaEntities _context;
        // BludaVzakaz zak = new BludaVzakaz();
        //zuravlevaEntitiesKPID db = new zuravlevaEntitiesKPID();

        public zakaz()
        {
            InitializeComponent();
            _context = OlgaZuravlevaEntities.GetContext();
            cmbStaff.ItemsSource = _context.Staff.ToList();
            cmbClient.ItemsSource = _context.Client.ToList();
        }





        private void btnDel_Click(object sender, RoutedEventArgs e)//удаление оъекта
        {
            
        }



        private void btnAdd_Click(object sender, RoutedEventArgs e)//Добавить в заказ
        {
           ordreBUY = null;
            OrderForm orderForm = new OrderForm();
            orderForm.ShowDialog();
            this.Close();
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)//Добавить в заказ
        {
            Dishes selected = (Dishes)bludazakazGrid.SelectedItem;
            if(ordreBUY == null)
            {
                ordreBUY = new Order
                {
                  ID_client = cmbClient.SelectedIndex+1,
                  ID_staff = cmbStaff.SelectedIndex+6,
                  Date = DateTime.Now,
                };
                _context.Order.Add(ordreBUY);
                _context.SaveChanges();
            }
            OrderAndSale orderAndSale = new OrderAndSale
            {
                ID_Dishes = selected.ID_Dishes,
                ID_Order = ordreBUY.ID_order,
                Summ = selected.Price,
            };
            _context.OrderAndSale.Add(orderAndSale);
            _context.SaveChanges();
            var saleProducts = _context.OrderAndSale.Where(sp => sp.ID_Order == ordreBUY.ID_order).ToList(); 
            ordreBUY.Summ = saleProducts.Sum(sp => sp.Summ);
            _context.SaveChanges();
            Update();

        }

        public void Update()
        {
            bludazakazGrid.ItemsSource = _context.Dishes.ToList();

        }
        private void bludazakazGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)//обращение к базе днных
        {
            Update();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Update();
        }

        private void btnClos_Click(object sender, RoutedEventArgs e)//переход на авторизацию
        {
            //MainWindow cookView = new MainWindow();
            //cookView.Show();
            //this.Close();
        }

        private void cmbStaff_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Update();
        }
    }
}

