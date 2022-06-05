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
            NewList diag = new NewList();
            diag.HeaderTitle.Content = "Dodaj listę";
            diag.ListAcceptButton.Content = "Dodaj";

            if (diag.ShowDialog()==true)
                tasksLists.Add(new TasksListModel(diag.nameOfList.Text, (CategoryModel) diag.CategoryComboBox.SelectedItem));

        }

        private void EditCategory_ClickButton(object sender, RoutedEventArgs e)
        {
            if (TasksListListBox.SelectedIndex >= 0)
            {
                NewList diag = new NewList();
                diag.HeaderTitle.Content = "Edytuj listę";
                diag.ListAcceptButton.Content = "Edytuj";

                TasksListModel temp = (TasksListModel)TasksListListBox.SelectedItem;

                diag.nameOfList.Text = temp.name;
                /*diag.CategoryComboBox.SelectedItem = temp.category;
                  diag.CategoryComboBox.SelectedValue = temp.category.ToString();*/
                diag.CategoryComboBox.SelectedIndex = 0; // -- inaczej jak po indeksie nie chce działać, nawet nie chce wyciągnąć indeksu elementu

                if (diag.ShowDialog() == true)
                {
                    tasksLists[TasksListListBox.SelectedIndex].EditTaskList(diag.nameOfList.Text, (CategoryModel) diag.CategoryComboBox.SelectedItem);
                    TasksListListBox.Items.Refresh();
                }
            }
        }

        private void RemoveTasksList_ClickButton(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno chcesz usunąć element?", "Usuń", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
            {
                TasksListModel item = (TasksListModel)TasksListListBox.SelectedItem;
                tasksLists.Remove(item);
                item.DeleteTaskList();
            }
        }

        private void ChangeTasksList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TasksListListBox.SelectedIndex >= 0)
            {
                RemoveButton.IsEnabled = true;
                EditButton.IsEnabled = true;
                SelectListBtn.IsEnabled = true;
            }
            else
            {
                RemoveButton.IsEnabled = false;
                EditButton.IsEnabled = false;
                SelectListBtn.IsEnabled = false;
            }           
        }

        private void DisplayList_Click(object sender, RoutedEventArgs e)
        {
            ListDisplay diag = new ListDisplay();
            TasksListModel temp = (TasksListModel) TasksListListBox.SelectedItem;
            diag.ListName.Content = temp.name;
            diag.CategoryName.Content = temp.category;

            diag.Show();

        }
    }
}
