using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksList.Models
{
    class TasksListModel
    {
        public List<TaskModel> list { get; set; }
        public CategoryModel category { get; set; }
        public int urgentState { get; set; }

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

        public TasksListModel(CategoryModel category, int urgent)
        {
            list = new List<TaskModel>();
            this.category = category;
            this.urgentState = urgent;
        }
        public TasksListModel(string category, int urgent)
        {
            list = new List<TaskModel>();
            this.category = new CategoryModel(category);
            this.urgentState = urgent;
        }
    }
}
