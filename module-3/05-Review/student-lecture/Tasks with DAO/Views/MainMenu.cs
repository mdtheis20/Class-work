using System;
using System.Collections.Generic;
using System.Linq;
using Tasks.DAL;
using Tasks.Models;

namespace CLI
{
    /// <summary>
    /// The top-level menu in our application
    /// </summary>
    public class MainMenu : CLIMenu
    {
        // You may want to store some private variables here.  YOu may want those passed in 
        // in the constructor of this menu
        private ITaskDAO taskDAO;


        /// <summary>
        /// Constructor adds items to the top-level menu. You will likely have parameters  passed in
        /// here...
        /// </summary>
        public MainMenu(ITaskDAO taskDAO) : base("Main Menu")
        {
            this.taskDAO = taskDAO;
        }

        protected override void SetMenuOptions()
        {
            // A Sample menu.  Build the dictionary here
            this.menuOptions.Add("A", "Add a Task");
            this.menuOptions.Add("C", "Complete a Task");
            this.menuOptions.Add("Q", "Quit program");
        }

        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            IList<Task> list = taskDAO.GetOpenTasks();
            int taskId;
            switch (choice)
            {
                case "A": 
                    // Prompt the user to add a task
                    Task task = GetTaskinfo();
                    taskDAO.AddTask(task);
                    Pause("Press enter to continue");
                    return true;    // Keep running the main menu
                case "C": 
                    taskId = GetTaskId(list);
                    if (taskId > 0)
                    {
                        task = taskDAO.GetById(taskId);
                        task.Completed = true;
                        taskDAO.Update(task);
                    }
                    Pause("");
                    return true;    // Keep running the main menu
            }
            return true;
        }

        protected override void BeforeDisplayMenu()
        {
            PrintHeader();

            // List all the tasks
            IList<Task> list = taskDAO.GetOpenTasks();
            ListTasks(list);
        }


        private void PrintHeader()
        {
            SetColor(ConsoleColor.Yellow);
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Tasks!!"));
            ResetColor();
        }



        /// <summary>
        /// Prompt the user for a valid task id, which is in the list
        /// </summary>
        /// <returns>The task id entered by the user</returns>
        private int GetTaskId(IList<Task> taskList)
        {
            int taskId = 0;
            while (true)
            {
                // Prompt the user for a task# and complete it
                Console.Write("Task # (0 to quit): ");
                if (int.TryParse(Console.ReadLine().Trim(), out taskId))
                {
                    if (taskId == 0)
                    {
                        return 0;
                    }

                    if (taskList.Any(t => t.Id == taskId))
                    {
                        return taskId;
                    }
                }
            }
        }

        private void ListTasks(IList<Task> list)
        {
            string[] headings = { "Number", "Task", "Due Date", "Completed" };
            Console.WriteLine($"{headings[0],6} {headings[1],-30} {headings[2],-15} {headings[3],-10}");
            foreach (Task task in list)
            {
                Console.WriteLine($"{task.Id,6} {task.TaskName,-30} {task.DueDate,-15:d} {task.Completed,-10}");
            }
        }

        private Task GetTaskinfo()
        {
            Console.WriteLine("\r\n*** Add a Task ***");
            Console.Write("\tTask name: ");
            string taskName = Console.ReadLine();

            DateTime dueDate = DateTime.MinValue;
            while (dueDate == DateTime.MinValue)
            {
                try
                {
                    Console.Write("\tDue Date: ");
                    dueDate = DateTime.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("No!");
                }
            }
            return new Task(0, taskName, dueDate);
        }

    }
}
