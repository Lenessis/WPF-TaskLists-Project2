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

        public Collection<TasksListModel> listsTask { get; }

        public TasksListModel listy = new TasksListModel();

        public ListDisplay()
        {
            InitializeComponent();
            treeView.ItemsSource = listy.list;
        }

        private void newTask_click(object sender, RoutedEventArgs e)
        {
            NewTask dial = new NewTask();
            dial.NewTaskTitle.Content = "Dodaj zadanie";
            dial.NewTaskButton.Content = "Dodaj";

            if (dial.ShowDialog() == true)
            {
                TaskModel temp = new TaskModel(dial.TaskNameBox.Text, dial.TaskDescriptionBox.Text, dial.TaskDateChose.DisplayDate, Convert.ToInt32(dial.TaskUrgentBox.Text));
               listy.list.Add(temp);
                listy.WriteFile();
                treeView.ItemsSource = listy.list;
                treeView.Items.Refresh();
            }

        }

        private void editTask_click(object sender, RoutedEventArgs e)
        {
            NewTask dial = new NewTask();
            dial.NewTaskTitle.Content = "Edytuj zadanie";
            dial.NewTaskButton.Content = "Edytuj";
            dial.ShowDialog();
        }

        private void removeTask_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Czy na pewno chcesz usunąć element?", "Usuń", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                TaskModel item = (TaskModel)treeView.SelectedValue;
                listy.list.Remove(item);
                item.RemoveTask();
            }

        }
    }
}
