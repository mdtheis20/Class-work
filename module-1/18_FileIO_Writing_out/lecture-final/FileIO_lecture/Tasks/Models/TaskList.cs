using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tasks.Models
{
    public class TaskList
    {
        public string Path { get; set; }
        private List<Task> taskList { get; set; }
        public int Count
        {
            get
            {
                return this.taskList.Count;
            }
        }
        public Task[] List
        {
            get
            {
                return this.taskList.ToArray();
            }
        }

        public TaskList(string path)
        {
            this.Path = path;
        }

        public void Load()
        {
            this.taskList = new List<Task>();

            //if (!File.Exists(Path))
            //{
            //    return;
            //}

            // TODO: Load tasks from the file (in Path), parse and create Tasks, add them to the list

            try
            {
                using (StreamReader sr = new StreamReader(Path))
                {
                    while (!sr.EndOfStream)
                    {
                        string s = sr.ReadLine();
                        string[] fields = s.Split("|");
                        string taskName = fields[0];
                        DateTime dueDate = DateTime.Parse(fields[1]);
                        bool isComplete = bool.Parse(fields[2]);
                        Task task = new Task(taskName, dueDate, isComplete);
                        taskList.Add(task);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                return;
            }

        }

        public void Save()
        {
            // Open the file at Path, and write all the tasks there
            using (StreamWriter sw = new StreamWriter(Path, false))
            {
                foreach (Task task in taskList)
                {
                    sw.WriteLine( string.Join("|", task.TaskName, task.DueDate, task.Completed) );
                }
            }
        }

        public void AddTask(Task newTask)
        {
            this.taskList.Add(newTask);
            this.Save();
        }

        public void RemoveTask(Task taskToRemove)
        {
            if (this.taskList.Contains(taskToRemove))
            {
                this.taskList.Remove(taskToRemove);
                this.Save();
            }
        }

    }
}
