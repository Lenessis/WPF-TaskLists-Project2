using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TasksList.Models
{
    public class TasksListModel
    {
        public List<TaskModel> list { get; set; }
        public string name { get; set; }
        public CategoryModel category { get; set; } 
        // -- rezygnujemy z urgent state, bo nie ma go gdzie zapisać i jest bez sensu

        /* --- CONSTRUCTORS --- */

        public TasksListModel() 
        {
            list = new List<TaskModel>();
            name = "";
        }


        public TasksListModel(string name, CategoryModel category)
        {
            list = new List<TaskModel>();
            this.category = category;
            this.name = name;
            AddTasksList();
        }

        /* --- METHODS --- */

        public static Collection<TasksListModel> GetTasksListsFromData()
        {
            Collection<TasksListModel> tasksListModels = new ObservableCollection<TasksListModel>();

            List<string> dataFolder = Directory.GetDirectories(MainWindow.dataPath).ToList();

            foreach(var categoryFolder in dataFolder) // -- odczytanie wszystkich folderów w Data
            {
               if(Directory.GetFiles($"{categoryFolder}").ToList() != null) // -- warunek sprawdzajacy czy folder nie jest pusty
                    foreach (var file in Directory.GetFiles($"{categoryFolder}").ToList()) // -- odczytanie folderu konkretnej kategorii
                    {
                        string listName = file.Replace($"{categoryFolder}\\", ""); // -- wycięcie ścieżki dostępu z nazwy
                        listName = listName.Replace(".txt", ""); // --  wycięcie rozszerzenia z nazwy
                        CategoryModel cat = new CategoryModel(); // -- stworzenie pustej zmiennej kategorii ( nie dodaje to nowej kategorii do folderu)
                        cat.name = categoryFolder.Replace($"{MainWindow.dataPath}", ""); // -- podmianka nazwy kategorii 

                        tasksListModels.Add(new TasksListModel(listName, cat)); // -- dodanie nowego elementu do listy
                    }              
            }

            return tasksListModels;
        }

        private void AddTasksList()
        {
            try
            {
                TextWriter tw = new StreamWriter($"{MainWindow.dataPath}/{category}/{name}.txt", true);
                tw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void DeleteTaskList()
        {
            File.Delete($"{MainWindow.dataPath}/{category}/{name}.txt");
        }

        public void EditTaskList(string newName, CategoryModel newCategory)
        {
            File.Move($"{MainWindow.dataPath}/{category}/{name}.txt", $"{MainWindow.dataPath}/{newCategory}/{newName}.txt");
            name = newName;
            category = newCategory;
        }

        public override string ToString()
        {
            return name;
        }
    }
}