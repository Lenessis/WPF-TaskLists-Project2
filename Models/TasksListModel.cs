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
        public CategoryModel category { get; set; } //--> na razie bez kateorii
        public int urgentState { get; set; }

        /* --- urgentState ---
         * 
         *  // 1 -- low
         *  // 2 -- medium
         *  // 3 -- high
         * 
        */

        public TasksListModel() 
        {
            list = new List<TaskModel>();
        }

        public TasksListModel(string name /*CategoryModel category, int urgent*/)
        {
            list = new List<TaskModel>();
            //this.category = category;
           // this.urgentState = urgent;
            this.name = name;
            AddTasksList();
        }

        public TasksListModel(string name, CategoryModel category/*, int urgent*/)
        {
            list = new List<TaskModel>();
            this.category = category;
            // this.urgentState = urgent;
            this.name = name;
            AddTasksList();
        }

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
                tw.WriteLine(name);
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

        public void EditTaskList(string newName)
        {
            File.Move($"{MainWindow.dataPath}/{category}/{name}.txt", $"{MainWindow.dataPath}/{category}/{newName}.txt");
            name = newName;
        }

        public override string ToString()
        {
            return name;
        }
    }
}