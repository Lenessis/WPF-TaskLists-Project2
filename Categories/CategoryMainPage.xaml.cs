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
        public Collection<CategoryModel> categories { get; } = CategoryModel.GetCatecoriesFromData(); // lista kategorii

        public CategoryMainPage()
        {
            InitializeComponent();
            CategoryListBox.ItemsSource = categories;
        }

        private void AddCategory_ClickButton(object sender, RoutedEventArgs e)
        {
            Add_EditCategory diag = new Add_EditCategory();
            diag.WindowTitle.Content = "Dodaj kategorię";
            diag.ConfirmButton.Content = "Dodaj";

            if (diag.ShowDialog() == true)
                categories.Add(new CategoryModel(diag.CategoryNameBox.Text));
        }

        private void EditCategory_ClickButton(object sender, RoutedEventArgs e)
        {
            if(CategoryListBox.SelectedIndex >= 0)
            {
                Add_EditCategory diag = new Add_EditCategory();
                diag.WindowTitle.Content = "Edytuj kategorię";
                diag.ConfirmButton.Content = "Edytuj";

                CategoryModel temp = (CategoryModel)CategoryListBox.SelectedItem;

                diag.CategoryNameBox.Text = temp.name;

                if(diag.ShowDialog() == true)
                {
                    categories[CategoryListBox.SelectedIndex].EditCategory(diag.CategoryNameBox.Text);
                    CategoryListBox.Items.Refresh();
                }
            }
        }

        private void DeleteCategory_ClickButton(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć element?", "Usuń", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                // categories.RemoveAt(CategoryListBox.SelectedIndex);
                CategoryModel item = (CategoryModel)CategoryListBox.SelectedItem;
                categories.Remove(item);
                item.DeleteCategory();
            }
        }

        private void ChangeCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CategoryListBox.SelectedIndex >= 0)
            {
                DeleteButton.IsEnabled = true;
                EditButton.IsEnabled = true;
            }
            else
            {
                DeleteButton.IsEnabled = false;
                EditButton.IsEnabled = false;
            }

        }
  
    }
}
