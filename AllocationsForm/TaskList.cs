using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationsForm
{
    /// <summary>
    /// Class to store the list of Task objects.
    /// </summary>
    public class TaskList
    {
        /// <summary>
        /// List to store the task objects.
        /// </summary>
        private List<Task> list;

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public TaskList()
        {
            List = new List<Task>();
        }

        /// <summary>
        /// Property to get and set the List.
        /// </summary>
        internal List<Task> List { get => list; set => list = value; }

        /// <summary>
        /// Method to add a Task to the list.
        /// </summary>
        /// <param name="task">A task object to be added to list.</param>
        public void AddTask(Task task)
        {
            list.Add(task);
        }
    }
}
