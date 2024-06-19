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
    /// Логика взаимодействия для redactorDis.xaml
    /// </summary>
    public partial class redactorDis : Window
    {
        private Dishes bluda = new Dishes();
        public redactorDis(Dishes _context)
        {
            InitializeComponent();
            if (_context != null)
            {
                bluda = _context;
            }
            cmbCategor.ItemsSource = OlgaZuravlevaEntities.GetContext().Category.ToList();
            DataContext = bluda;           


           
        }
        public bool registr = false;

        private void btnSohranit_Click(object sender, RoutedEventArgs e)//сохраниение данных
        {
            try
            {
                Product product = new Product();
                string title = txtTitle.Text;
                int price = Convert.ToInt32(txtPrice.Text);
                product.Register(title, price, cmbCategor.SelectedIndex + 1);
                var result = MessageBox.Show("Все прошло отлично!","Внимание!",MessageBoxButton.OK);
                if(result == MessageBoxResult.OK)
                {
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("Что то не так!");
            }
        }
    }
}
