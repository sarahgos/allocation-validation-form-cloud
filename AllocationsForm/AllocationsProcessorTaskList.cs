using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationsForm
{
    /// <summary>
    /// Class to hold a list of allocations and their task id's and processor id's.
    /// </summary>
    public class AllocationsProcessorTaskList
    {
        /// <summary>
        /// List to hold the TaskProcessorList objects.
        /// </summary>
        private List<TaskProcessorList> allocationsList;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public AllocationsProcessorTaskList()
        {
            allocationsList = new List<TaskProcessorList>();
        }

        /// <summary>
        /// Property to get and set the list.
        /// </summary>
        internal List<TaskProcessorList> AllocationsList { get => allocationsList; set => allocationsList = value; }

        /// <summary>
        /// Method to add TaskProcessorList to this classes allocationsList.
        /// </summary>
        /// <param name="taskProcessorList">A list of task id's and their respective processor id's.</param>
        public void AddTaskList(TaskProcessorList taskProcessorList)
        {
            allocationsList.Add(taskProcessorList);
        }
    }
}
