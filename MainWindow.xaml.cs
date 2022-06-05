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
using TasksList.Lists;
using TasksList.Categories;

namespace TasksList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string dataPath = "../../../Data/"; // -- Ścieżka dostępu do danych
        public static string filePath = "../../../File/"; // -- Ścieżka dostępu do plikow

        Page listsMainPage = new ListsMainPage();
        Page categoriesMainPage;

        public MainWindow()
        {
            InitializeComponent();
            FrameContent.Content = listsMainPage.Content;
        }

        // -- Navigations Buttons -- //

        private void ShowLists_Click(object sender, RoutedEventArgs e)
        {
            if (listsMainPage == null)
                listsMainPage = new ListsMainPage();
            FrameContent.Content = listsMainPage.Content;
        }

        private void ShowCategories_Click(object sender, RoutedEventArgs e)
        {
            if (categoriesMainPage == null)
                categoriesMainPage = new CategoryMainPage();
            FrameContent.Content = categoriesMainPage.Content;
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

        // ------------------------ //
    }
}
