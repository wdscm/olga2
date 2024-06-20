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
    /// Логика взаимодействия для OrderForm.xaml
    /// </summary>
    public partial class OrderForm : Window
    {
        
        public OrderForm()
        {
            InitializeComponent();
            Update();
            
        }

       

       

        private void btnSohranit_Click(object sender, RoutedEventArgs e)
        {
           

        }
        private void Window_Activated(object sender, EventArgs e)
        {
           
        }
        public void Update()//отображение номера заказа
        {
            dgOrder.ItemsSource = OlgaZuravlevaEntities.GetContext().OrderAndSale.ToList();
            dgOrder_Копировать.ItemsSource = OlgaZuravlevaEntities.GetContext().Order.ToList();
        }

        private void btnCloce_Click(object sender, RoutedEventArgs e)//выход авторизация
        {
            MainWindow mainWindow = new MainWindow();   
            this.Close();
        }

        //private void btnOrder_Click(object sender, RoutedEventArgs e)
        //{
        //    orderbuy = null;
        //    this.Close();
        //}

        //private void btnBuy_Click(object sender, RoutedEventArgs e)
        //{
        //    zakaz zakaz = new zakaz();
           
        //}

        private void btnBuy_Click_1(object sender, RoutedEventArgs e)
        {
            zakaz zakaz = new zakaz();
            zakaz.ShowDialog();
            Update();
        }
    }
}
    

       

