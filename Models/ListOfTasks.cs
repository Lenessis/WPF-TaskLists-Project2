using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksList.Models
{
    class ListOfTasks
    {
        public List<Task> list { get; set; }
        public Category category { get; set; }
        public int urgentState { get; set; }

        /* --- urgentState ---
         * 
         *  // 1 -- low
         *  // 2 -- medium
         *  // 3 -- high
         * 
        */

        public ListOfTasks () 
        {
            list = new List<Task>();
        }

        public ListOfTasks(Category category, int urgent)
        {
            list = new List<Task>();
            this.category = category;
            this.urgentState = urgent;
        }
        public ListOfTasks(string category, int urgent)
        {
            list = new List<Task>();
            this.category = new Category(category);
            this.urgentState = urgent;
        }
    }
}
