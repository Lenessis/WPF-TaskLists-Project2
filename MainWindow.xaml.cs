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

namespace TasksList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // -- Navigations Buttons -- //

        public void SetActiveControl(UserControl control)
        {
            ListsContent.Visibility = Visibility.Collapsed;
            CategoryContent.Visibility = Visibility.Collapsed;

            control.Visibility = Visibility.Visible;
        }

        private void ShowLists_Click(object sender, RoutedEventArgs e)
        {
            SetActiveControl(ListsContent);
        }

        private void ShowCategories_Click(object sender, RoutedEventArgs e)
        {
            SetActiveControl(CategoryContent);
        }

        // -- Moving window feature -- //

        private void DragAndMoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        // -- Minimalized, Maximize, Close Buttons -- //

        private void MinimalizeButton_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void MaximizeButton_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
                WindowState = WindowState.Maximized;


            else if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
