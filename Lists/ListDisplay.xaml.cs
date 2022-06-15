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
                TaskModel temp = new TaskModel(dial.TaskNameBox.Text, dial.TaskDescriptionBox.Text, dial.TaskDateChose.DisplayDate, dial.TaskUrgentBox.Text);
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

            TaskModel item = (TaskModel)treeView.SelectedItem;

            if ((TaskModel)treeView.SelectedItem != null)
            {
                dial.TaskNameBox.Text = item.name;
                dial.TaskDescriptionBox.Text = item.description;

                if (dial.ShowDialog() == true)
                {
                    listy.list[treeView.SelectedIndex].EditTask(dial.TaskNameBox.Text, dial.TaskDescriptionBox.Text, dial.TaskDateChose.DisplayDate, dial.TaskUrgentBox.Text);
                    listy.WriteFile();
                    treeView.ItemsSource = listy.list;
                    treeView.Items.Refresh();
                }
            }
        }

        private void removeTask_Click(object sender, RoutedEventArgs e)
        {
            if ((TaskModel)treeView.SelectedItem != null)
            {
                if (MessageBox.Show("Czy na pewno chcesz usunąć element?", "Usuń", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    TaskModel item = (TaskModel)treeView.SelectedItem;
                    if (item.countSub > 0)
                    {
                        MessageBox.Show("W pierwszej kolejności musisz usunąć podzania.");
                    }
                    else
                    {
                        listy.list.Remove(item);
                        listy.WriteFile();
                        treeView.ItemsSource = listy.list;
                        treeView.Items.Refresh();
                    }
                }
            }

        }

        private void CheckBoxChanged(object sender, RoutedEventArgs e)
        {
            treeView.ItemsSource = listy.list;
            //TaskModel item = (TaskModel)treeView.SelectedItem;
            if(treeView.SelectedItem != null)
            {
                listy.list[treeView.SelectedIndex].EditStateTask(true);
            }
            listy.WriteFile();
            treeView.ItemsSource = listy.list;
            treeView.Items.Refresh();

        }

        private void CheckBoxUnChanged(object sender, RoutedEventArgs e)
        {
            treeView.ItemsSource = listy.list;
            if (treeView.SelectedItem != null)
            {
                listy.list[treeView.SelectedIndex].EditStateTask(false);
            }
            listy.WriteFile();
            treeView.ItemsSource = listy.list;
            treeView.Items.Refresh();
        }

        private void newSubtask_click(object sender, RoutedEventArgs e)
        {
            if ((TaskModel)treeView.SelectedItem != null)
            {
                NewTask dial = new NewTask();
                dial.NewTaskTitle.Content = "Dodaj podzadanie";
                dial.NewTaskButton.Content = "Dodaj";

                treeView.ItemsSource = listy.list;
                TaskModel item = (TaskModel)treeView.SelectedItem;
                if (dial.ShowDialog() == true)
                {
                    listy.list[treeView.SelectedIndex].AddNewSubtask("--------> " + dial.TaskNameBox.Text, dial.TaskDescriptionBox.Text, dial.TaskDateChose.DisplayDate, dial.TaskUrgentBox.Text);
                    //TaskModel temp = new TaskModel(dial.TaskNameBox.Text, dial.TaskDescriptionBox.Text, dial.TaskDateChose.DisplayDate, dial.TaskUrgentBox.Text);
                    //listy.list.Add(temp);
                    listy.WriteFile();
                    listy.list.Clear();
                    listy.ReadFile();

                    treeView.ItemsSource = listy.list;
                    treeView.Items.Refresh();
                }
            }
        }
    }
}
