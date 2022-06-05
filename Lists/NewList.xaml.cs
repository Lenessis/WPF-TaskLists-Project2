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

namespace TasksList.list
{
    /// <summary>
    /// Logika interakcji dla klasy NewList.xaml
    /// </summary>
    public partial class NewList : Window
    {
        public NewList()
        {
            InitializeComponent();
        }
        //to do obslugi kategorii
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ExitButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Add_ClickButton(object sender, RoutedEventArgs e)
        {
            if (nameOfList.Text.Length <= 0)
            {
                MessageBox.Show("Musisz podać nazwę kategorii!", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);
                nameOfList.Focus();
            }
            else
                DialogResult = true;
        }
    }
}
