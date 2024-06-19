using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace IdilliaKP
{
    static class Filtr
    {
        public static void ForComboBox(object sender, System.Windows.RoutedEventArgs e)
        {
            (sender as ComboBox).IsDropDownOpen = true;
            (sender as ComboBox).SelectedItem = null;

            var tb = (TextBox)e.OriginalSource;
            tb.Select(tb.SelectionStart + tb.SelectionLength, 0);

            CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView((sender as ComboBox).Items);
            if (cv != null)
                cv.Filter = s => ((string)s).IndexOf((sender as ComboBox).Text, StringComparison.CurrentCultureIgnoreCase) >= 0;
        }
    }
}
