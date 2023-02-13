using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace AllocationsForm
{
    /// <summary>
    /// This class holds the functions to compute the ram for tasks and allocations.
    /// </summary>
    public class Ram
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Ram() { }

        /// <summary>
        /// Gets the highest ram of two ram values.
        /// </summary>
        /// <param name="taskRam">The current tasks ram.</param>
        /// <param name="highestRam">The current highest ram.</param>
        /// <returns>The highiest ram.</returns>
        public int GetRam(int taskRam, int highestRam)
        {
            if (taskRam > highestRam)
                highestRam = taskRam;

            return highestRam;
        }

        /// <summary>
        /// Checks if the ram is lower than the processor ram.
        /// </summary>
        /// <param name="taskRam">The tasks ram.</param>
        /// <param name="processorRam">The processors ram.</param>
        /// <returns>A boolean isLower.</returns>
        public bool CheckRam(double taskRam, double processorRam)
        {
            bool isLower = false;

            /// Check if task ram is less than or equal to processor ram.
            if (taskRam <= processorRam)
                isLower = true;
            else
                isLower = false;

            return isLower;
        }

        /// <summary>
        /// This function gets the ram data for each of the tasks assigned to processors in an allocation.
        /// </summary>
        /// <param name="allocProcessTaskList">A list containing the allocation, their task id and processor id.</param>
        /// <param name="processorList">A list containing the processor data.</param>
        /// <param name="tasks">A list of tasks.</param>
        /// <param name="allocDataList">The allocations data list.</param>
        public void GetRamData(AllocationsProcessorTaskList allocProcessTaskList, ProcessorList processorList, TaskList tasks, List<AllocationData> allocDataList, int processorNumber)
        {
            /// Dictionary to store the ram for each processor.
            Dictionary<int, double> ramDictionary = new Dictionary<int, double>();

            /// Updates with the current processor id.
            int processorId = 0;

            /// Stores the highest ram for processor 0; 
            int highestRam = 0;

            /// Stores the current allocation id.
            int allocID = 0;

            /// Instantiate new Ram list to set the ram data.
            allocDataList[allocID].Ram = new List<string>();

            /// Holds the current task id.
            int taskId;

            /// The index of the task in each allocation.
            int taskIndex;

            /// Stores the current processor index.
            int processorIndex;

            /// Create the keys for the dictionary based on processor id.
            while (processorId < processorNumber)
            {
                ramDictionary.Add(processorId, 0);
                processorId++;
            }

            /// Loops through each allocation.
            foreach (var alloc in allocProcessTaskList.AllocationsList)
            {
                /// Reset processor index.
                processorIndex = 0;
                
                /// Loop while the processor index is less than the number of processors.
                while (processorIndex < processorNumber)
                {
                    /// Reset highest ram.
                    highestRam = 0;

                    /// Loop through each task in an allocation.
                    for (taskIndex = 0; taskIndex < alloc.List.Count; taskIndex++)
                    {
                        /// Set task id.
                        taskId = alloc.List[taskIndex].Id;

                        /// Set processor id.
                        processorId = alloc.List[taskIndex].ProcessorId;

                        /// Check if the processor id matches the processor index.
                        if (processorId == processorIndex)
                        {
                            /// Get the highest ram.
                            highestRam = GetHighestRam(highestRam, taskId, tasks);

                            /// Add the ram to the dicionary at the correct processor index.
                            ramDictionary[processorId] = highestRam;
                        }
                      }
                    processorIndex++;
                }

                /// Iterate through dictionary and add the ram to list.
                foreach (var ram in ramDictionary)
                {
                    AddRamToList(allocDataList[allocID].Ram, ram.Value.ToString(), processorList.List[ram.Key].RAM);
                }

                /// Update allocation id to next allocation.
                allocID++;
                
                /// Instantiate new list to set ram.
                if (allocID < allocDataList.Count)
                    allocDataList[allocID].Ram = new List<string>();
            }
        }

        /// <summary>
        /// Adds the task ram and processor ram to a list.
        /// </summary>
        /// <param name="ramList">A list of rams.</param>
        /// <param name="processorList">A list of the processors.</param>
        /// <param name="ram">The amount of ram of a task.</param>
        /// <param name="processorRam">The amount of ram of a processor.</param>
        public void AddRamToList(List<string> ramList, string ram, string processorRam)
        {
            ramList.Add(ram);
            ramList.Add(Constants.ForwardSlash);
            ramList.Add(processorRam);
            ramList.Add(Constants.SemiColon);
        }

        /// <summary>
        /// Gets the highest ram.
        /// </summary>
        /// <param name="highestRam">The current highest ram.</param>
        /// <param name="taskId">The current task id.</param>
        /// <param name="tasks">A list of tasks.</param>
        /// <returns></returns>
        public int GetHighestRam(int highestRam, int taskId, TaskList tasks)
        {
            if (taskId < tasks.List.Count)
            {
                int taskRam = Convert.ToInt32(tasks.List[taskId].RAM);
                highestRam = GetRam(taskRam, highestRam);
            }

            return highestRam;
        }
    }
}
