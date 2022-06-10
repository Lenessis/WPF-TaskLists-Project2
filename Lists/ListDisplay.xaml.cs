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
using System.Windows.Shapes;
using TasksList.list;
using TasksList.Models;

namespace TasksList.list
{
    /// <summary>
    /// Logika interakcji dla klasy ListDisplay.xaml
    /// </summary>
    public partial class ListDisplay : Window
    {

        public Collection<TasksListModel> listsTask { get; } = TasksListModel.GetTasksListsFromData(); // wczytuje wszystkie dane

        //public Collection<TasksList> tasks { get; } = TasksList
         //TaskModel listsOfTasks = new TaskModel();
        // public List<TaskModel> listss = new List<TaskModel>();

        TasksListModel listy = new TasksListModel();

        public ListDisplay()
        {
            InitializeComponent();
            //listy = listy.ReadFile();
            //treeView.ItemsSource = listsTask;
           // listsOfTasks.ReadFile();
        }

        private void GetBack_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void newTask_click(object sender, RoutedEventArgs e)
        {
            //listsOfTasks.ReadFile();
            NewTask dial = new NewTask();
            dial.NewTaskTitle.Content = "Dodaj zadanie";
            dial.NewTaskButton.Content = "Dodaj";
            // if(dial.TaskUrgentBox.SelectedItem.ToString())
            // {
            //    int x = int.Parse(dial.TaskUrgentBox.ToString());
            //}
            if (dial.ShowDialog() == true)
            {

               // listy.list.Add(new TaskModel(dial.TaskNameBox.Text, dial.TaskDescriptionBox.Text, dial.TaskDateChose.DisplayDate, dial.TaskUrgentBox));
                listy.WriteFile();
            }
           /* foreach (TaskModel aPart in listss)
            {
                //string str = aPart.ToFileString();
                
            }*/
            
            // listss.WriteFile();
            //   listsOfTasks.AddNewTask(new TaskModel(dial.TaskNameBox.Text, dial.TaskDescriptionBox.Text, dial.TaskDateChose.DisplayDate, int.Parse(dial.TaskUrgentBox.ToString()));
            //listsTask.Add(new)

        }

        private void editTask_click(object sender, RoutedEventArgs e)
        {
            //if (treeView >= 0)
           // {
                NewTask dial = new NewTask();
            dial.NewTaskTitle.Content = "Edytuj zadanie";
            dial.NewTaskButton.Content = "Edytuj";
            dial.ShowDialog();
            //}
        }

        private void removeTask_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Czy na pewno chcesz usunąć element?", "Usuń", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                TaskModel item = (TaskModel)treeView.SelectedValue ;
                listy.list.Remove(item);
                item.RemoveTask();
            }
            

        }
    }
}
