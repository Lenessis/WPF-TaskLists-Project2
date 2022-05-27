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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TasksList.list;
using TasksList.Models;

namespace TasksList.Lists
{
    /// <summary>
    /// Logika interakcji dla klasy ListsMainPage.xaml
    /// </summary>
    public partial class ListsMainPage : Page
    {
        public Collection<TasksListModel> tasksLists { get; } = TasksListModel.GetTasksListsFromData();

        public ListsMainPage()
        {
            InitializeComponent();
            TasksListListBox.ItemsSource = tasksLists;
        }

        private void AddTaskList_ClickButton(object sender, RoutedEventArgs e)
        {
            NewList dial = new NewList();
            dial.Title = "Dodaj listę";

            if(dial.ShowDialog()==true)
            {
                tasksLists.Add(new TasksListModel(dial.nameOfList.Text));
            }
        }

        private void ChangeTasksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TasksListListBox.SelectedIndex >= 0)
            {
                RemoveButton.IsEnabled = true;
                EditButton.IsEnabled = true;
            }
            else
            {
                RemoveButton.IsEnabled = false;
                EditButton.IsEnabled = false;
            }

        }

        private void EditCategory_ClickButton(object sender, RoutedEventArgs e)
        {

        }

        private void RemoveTasksList_ClickButton(object sender, RoutedEventArgs e)
        {

        }
    }
}
