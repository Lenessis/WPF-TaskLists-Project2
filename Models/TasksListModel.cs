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
            AddTasksList();
        }

        public static Collection<TasksListModel> GetTasksListsFromData()
        {
            Collection<TasksListModel> tasksListModels = new ObservableCollection<TasksListModel>();

            foreach (var item in Directory.GetFiles(MainWindow.filePath).ToList())
               tasksListModels.Add(new TasksListModel(item.Replace(MainWindow.filePath, "")));
            

            return tasksListModels;
        }

        private void AddTasksList()
        {
            try
            {
                TextWriter tw = new StreamWriter(MainWindow.filePath + "/" + name+".txt", true);
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
            File.Delete(MainWindow.filePath + "/" + name+".txt");
        }

        public void EditTaskList(string newName)
        {
            File.Move(MainWindow.filePath + "/" + name+".txt", MainWindow.filePath + "/" + newName+".txt");
            name = newName;
        }

        public override string ToString()
        {
            return name; //+ urgentState + list;
        }
    }
}