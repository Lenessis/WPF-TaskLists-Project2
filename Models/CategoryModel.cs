using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TasksList;

namespace TasksList.Models
{
    public class CategoryModel
    {
        public string name { get; set; }       

        public CategoryModel()
        { }

        public CategoryModel(string name)
        {
            this.name = name;
            AddCategory();
        }

        /* --- METHODS --- */

        // -- Pobieranie listy katalogów (folderów) -- //

        public static Collection<CategoryModel> GetCatecoriesFromData()
        {
            // -- Jeśli nie ma folderów lista kategorii wyniesie 0

            Collection<CategoryModel> categories = new ObservableCollection<CategoryModel>();           

            foreach (var item in Directory.GetDirectories(MainWindow.dataPath).ToList())
                categories.Add(new CategoryModel(item.Replace(MainWindow.dataPath, "")));

            return categories;
        }

        // -- Dodawanie kategorii (folderu) -- //

        private void AddCategory()
        {
            Directory.CreateDirectory(MainWindow.dataPath + "/" + name);
        }

        public void AddCategory(string name)
        {
            this.name = name;
            Directory.CreateDirectory(MainWindow.dataPath + "/" + name);
        }

        // -- Usuwanie kategorii (folderu) -- //

        public void DeleteCategory()
        {
            //if(Directory.Exists(MainWindow.dataPath + "/" + name) && Directory.GetFiles(MainWindow.dataPath + "/" + name).ToList()==null)
                Directory.Delete(MainWindow.dataPath + "/" + name);
        }

        public void EditCategory(string newName)
        {
            Directory.Move(MainWindow.dataPath + "/" + name, MainWindow.dataPath + "/" + newName);
            name = newName;
        }

        public override string ToString()
        {
            return name;
        }

    }
}
