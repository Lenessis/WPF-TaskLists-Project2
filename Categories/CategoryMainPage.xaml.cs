using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using TasksList.Category;
using TasksList.Models;

namespace TasksList.Categories
{
    /* 
     * Używa folderu Data, w którym poszczególnymi katalogami są kategorie
     */

    public partial class CategoryMainPage : Page
    {   
       // public List<CategoryModel> categories; // lista kategorii
        public Collection<CategoryModel> categories { get; } = CategoryModel.GetCatecoriesFromData(); // lista kategorii

        public CategoryMainPage()
        {
            InitializeComponent();
            CategoryListBox.ItemsSource = categories;
        }

        private void PageLoaded(object sender, RoutedEventArgs e)
        {           
            CategoryListBox.ItemsSource = categories;
        }

        private void AddCategory_ClickButton(object sender, RoutedEventArgs e)
        {
            Add_EditCategory diag = new Add_EditCategory();
            diag.Title = "Dodaj kategorię";
            diag.ConfirmButton.Content = "Dodaj";

            if (diag.ShowDialog() == true)
                categories.Add(new CategoryModel(diag.CategoryNameBox.Text));
        }

        private void ChangeCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        
    }
}
