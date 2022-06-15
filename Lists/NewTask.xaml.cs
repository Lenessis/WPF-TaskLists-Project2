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
using TasksList.Models;

namespace TasksList.list
{
    /// <summary>
    /// Logika interakcji dla klasy NewTask.xaml
    /// </summary>
    public partial class NewTask : Window
    {

        public NewTask()
        {
            InitializeComponent();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void CancelAddingTask_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AddNewTask_Click(object sender, RoutedEventArgs e)
        {
            if (TaskNameBox.Text.Length <= 0)
            {
                MessageBox.Show("Musisz podać nazwę zadania!", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);
                TaskNameBox.Focus();
            }
            else if (TaskUrgentBox.Text.Length <= 0)
            {
                MessageBox.Show("Musisz podać pilność zadania!", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);
                TaskUrgentBox.Focus();
            }
            else if (TaskDescriptionBox.Text.Length <= 0)
            {
                MessageBox.Show("Musisz podać opis zadania!", "Ostrzeżenie", MessageBoxButton.OK, MessageBoxImage.Warning);
                TaskNameBox.Focus();
            }
            else
                DialogResult = true;
            
        }
    }
}
