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

namespace TasksList.Category
{
    /// <summary>
    /// Logika interakcji dla klasy Add_EditCategory.xaml
    /// </summary>
    public partial class Add_EditCategory : Window
    {
        public Add_EditCategory()
        {
            InitializeComponent();
        }

        private void Confirm_ClickButton(object sender, RoutedEventArgs e)
        {
            if (CategoryNameBox.Text.Length <= 0)
            {
                MessageBox.Show("Musisz podać nazwę kategorii!", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);
                CategoryNameBox.Focus();
            }
            else
                DialogResult = true;
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
