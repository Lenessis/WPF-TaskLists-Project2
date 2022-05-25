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
using TasksList.Models;

namespace TasksList.Categories
{
    /* 
     * Używa folderu Data, w którym poszczególnymi katalogami są kategorie
     */

    public partial class CategoryMainPage : Page
    {   
        public List<CategoryModel> categories; // lista kategorii


        public CategoryMainPage()
        {
            InitializeComponent();
            categories = CategoryModel.GetCatecoriesFromData();
        }

        private void ChangeCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
