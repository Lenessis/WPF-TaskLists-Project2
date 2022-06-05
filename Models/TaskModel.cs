using System;
using System.Collections.Generic;

namespace TasksList.Models
{
    public class TaskModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public DateTime? date { get; set; }
        public int urgentState { get; set; }
        public bool done { get; set; }
        public List<TaskModel> subtasks { get; set; }

        /* --- urgentState ---
         * 
         *  // 1 -- low
         *  // 2 -- medium
         *  // 3 -- high
         * 
        */

        public TaskModel() 
        {
            this.done = false;
            subtasks = new List<TaskModel>();
        }

        public TaskModel(string name, string desc, int urgent) // -- bez daty
        {
            this.name = name;
            this.description = desc;
            this.urgentState = urgent;
            this.done = false;
            subtasks = new List<TaskModel>();
        }

        public TaskModel (string name, string desc, DateTime date, int urgent) // -- z data
        {
            this.name = name;
            this.description = desc;
            this.date = date;
            this.urgentState = urgent;
            this.done = false;
            subtasks = new List<TaskModel>();
        }

        /* --- METHODS --- */

        public String ToFileString()
        {
            string dateFormat = (date.HasValue == true) ? date.ToString() : "";
            return $"{name};{done};{urgentState};{dateFormat};{description};{subtasks.Count}";
        }

    }
}