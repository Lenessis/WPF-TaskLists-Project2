using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksList.Models
{
    public class TasksListModel
    {
        public List<TaskModel> list { get; set; }
        public string name { get; set; }
       // public CategoryModel category { get; set; } --> na razie bez kateorii
       // public int urgentState { get; set; }

        /* --- urgentState ---
         * 
         *  // 1 -- low
         *  // 2 -- medium
         *  // 3 -- high
         * 
        */

        public TasksListModel () 
        {
            list = new List<TaskModel>();
        }

        public TasksListModel(string name /*CategoryModel category, int urgent*/)
        {
            list = new List<TaskModel>();
            //this.category = category;
           // this.urgentState = urgent;
            this.name = name;
        }

        public static Collection<TasksListModel> GetTasksListsFromData()
        {
            Collection<TasksListModel> tasksListModels = new ObservableCollection<TasksListModel>();

            foreach (var item in Directory.GetFiles(MainWindow.filePath).ToList())
               tasksListModels.Add(new TasksListModel(item));

            return tasksListModels;
        }

        public void AddTasksList(string name)
        {
            using (StreamWriter sw = File.CreateText(MainWindow.filePath + "/" + name + ".txt"))
            {
                sw.WriteLine("Hello");
                sw.WriteLine("And");
                sw.WriteLine("Welcome");
            }
        }

        public void DeleteTaskList()
        {
            File.Delete(MainWindow.filePath + "/" + name);
        }

        public void EditTaskList(string newName)
        {
            File.Move(MainWindow.filePath + "/" + name, MainWindow.filePath + "/" + newName);
        }

        public override string ToString()
        {
            return name; //+ urgentState + list;
        }
    }
}