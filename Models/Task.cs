using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TasksList.Models
{
    class Task
    {
        public string name { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public int urgentState { get; set; }
        public List<Task> subtasks { get; set; }

        /* --- urgentState ---
         * 
         *  // 1 -- low
         *  // 2 -- medium
         *  // 3 -- high
         * 
        */

        public Task () 
        {
            subtasks = new List<Task>();
        }

        public Task (string name, string desc, DateTime date, int urgent) 
        {
            this.name = name;
            this.description = desc;
            this.date = date;
            this.urgentState = urgent;
            subtasks = new List<Task>();
        }

        /* --- METHODS --- */
    }
}
