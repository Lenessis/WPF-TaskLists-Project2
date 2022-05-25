using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksList.Models
{
    class TaskModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public int urgentState { get; set; }
        public List<TaskModel> subtasks { get; set; }

        /* --- urgentState ---
         * 
         *  // 1 -- low
         *  // 2 -- medium
         *  // 3 -- high
         * 
        */

        public TaskModel () 
        {
            subtasks = new List<TaskModel>();
        }

        public TaskModel (string name, string desc, DateTime date, int urgent) 
        {
            this.name = name;
            this.description = desc;
            this.date = date;
            this.urgentState = urgent;
            subtasks = new List<TaskModel>();
        }

        /* --- METHODS --- */
    }
}
