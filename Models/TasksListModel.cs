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

        public void ReadFile()
        {
            StreamReader file = new StreamReader($"{MainWindow.dataPath}/{category}\\{name}.txt");
            string line;

            // -- dopóki plik będzie mieał linie
            while((line = file.ReadLine()) != null)
            {
                string[] taskInformation = line.Split(";"); // -- rozdzielenie linii średnikami i wpisanie zmiennych do tablicy
                TaskModel newTask = new TaskModel();

                newTask.name =          taskInformation[0];
                newTask.done =          Convert.ToBoolean(taskInformation[1]);
                newTask.urgentState =   Convert.ToInt32(taskInformation[2]);

                if (taskInformation[3] != "") // -- jesli data została ustawiona
                {
                    // -- trzeba ją przeczytać i przekształcić na typ DateTime
                    char[] signs = new char[] { '.', ' ', ':' };
                    string[] tempDate = taskInformation[3].Split(signs);
                    newTask.date = new DateTime( 
                        Convert.ToInt32(tempDate[2]),
                        Convert.ToInt32(tempDate[1]),
                        Convert.ToInt32(tempDate[0]),
                        Convert.ToInt32(tempDate[3]),
                        Convert.ToInt32(tempDate[4]),
                        Convert.ToInt32(tempDate[5])
                        );
                }
                newTask.description = taskInformation[4];
                int listCount = Convert.ToInt32(taskInformation[5]); // -- ilość zadań na liście podzadań 

                if ( listCount != 0) // -- jeśli sa podzadania
                {
                    for (int i = 0; i < listCount; i++) // -- przeczyta tyle kolejnych linii ile wynosiła liczba zapisana przy zadaniu
                    {
                        line = file.ReadLine(); // -- przeczytaj kolejną linię
                        string[] subTaskInformation = line.Split(";");
                        TaskModel newSubTask = new TaskModel();

                        newSubTask.name = subTaskInformation[0];
                        newSubTask.done = Convert.ToBoolean(subTaskInformation[1]);
                        newSubTask.urgentState = Convert.ToInt32(subTaskInformation[2]);

                        if (subTaskInformation[3] != "")
                        {
                            char[] signs = new char[] { '.', ' ', ':' };
                            string[] tempDate = subTaskInformation[3].Split(signs);
                            newSubTask.date = new DateTime(
                                Convert.ToInt32(tempDate[0]),
                                Convert.ToInt32(tempDate[1]),
                                Convert.ToInt32(tempDate[2]),
                                Convert.ToInt32(tempDate[3]),
                                Convert.ToInt32(tempDate[4]),
                                Convert.ToInt32(tempDate[5])
                                );
                        }
                        //newSubTask.date = subTaskInformation[3].ToString();
                        newSubTask.description = subTaskInformation[4];

                        // -- nie ma tutaj tworzenia kolejnych podzadań
                        newTask.subtasks.Add(newSubTask); // -- dodawanie do listy podzadań w zadaniu głównym
                    }
                }
                list.Add(newTask); // -- dodaj nowe zadanie do listy Tasków
            }
            file.Close();
        }

        //public override ToString ()

        public void WriteFile()
        {
            
            //MessageBox.Show(category);
            MessageBox.Show($"{MainWindow.dataPath}/{category}\\{name}.txt");
            StreamWriter file = new StreamWriter($"{MainWindow.dataPath}/Kappa\\sss.txt");
            foreach (var task in list)
            {   
                MessageBox.Show(task.ToFileString());
                file.WriteLine(task.ToFileString());
                
                if (task.subtasks.Count>0)
                {
                    MessageBox.Show("done");
                    foreach (var subtask in task.subtasks)
                    {
                        
                        file.WriteLine(subtask.ToFileString());
                    }
                }
            }
            file.Close();

        }
    }
}