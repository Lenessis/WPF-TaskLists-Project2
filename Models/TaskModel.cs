using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using TasksList.Models;

namespace TasksList.Models
{
    public class TaskModel
    {
        public string name { get; set; }
        public string description { get; set; }
        public DateTime? date { get; set; }
        public string urgentState { get; set; }
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

        public TaskModel(string name, string desc, string urgent) // -- bez daty
        {
            this.name = name;
            this.description = desc;
            this.urgentState = urgent;
            this.done = false;
            subtasks = new List<TaskModel>();
        }

        public TaskModel (string name, string desc, DateTime date, string urgent) // -- z data
        {
            this.name = name;
            this.description = desc;
            this.date = date;
            this.urgentState = urgent;
            this.done = false;
            subtasks = new List<TaskModel>();
        }

        /* --- METHODS --- */

        public string ToFileString()
        {
            string dateFormat = (date.HasValue == true) ? date.ToString() : "";
            Console.WriteLine(dateFormat);
            return $"{name};{done};{urgentState};{dateFormat};{description};{subtasks.Count}";
        }

        public void AddNewTask(string name, string desc, DateTime date, string urgent)
        {
           // TextWriter tw = new StreamWriter()
            //TaskModel taskM = new TaskModel();
            // subtasks.Add(new TaskModel(name, desc,date, urgent));
        }

        public void RemoveTask()
        {
            
        }

        public void EditTask(string newName, string newDescription, DateTime? newDateChose, string newUrgentState)
        {
            name = newName;
            description = newDescription;
            date = newDateChose;
            urgentState = newUrgentState;

        }

    }
}