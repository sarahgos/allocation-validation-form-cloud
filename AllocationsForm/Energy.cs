using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace AllocationsForm
{
    public class Energy
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Energy() { }

        /// <summary>
        /// This method is used to compute the energy used for a single task.
        /// </summary>
        /// <param name="runtime">The runtime of a task.</param>
        /// <param name="referenceFrequency">The reference frequency of tasks processor.</param>
        /// <param name="processSpecList">A list of processor and their specs.</param>
        /// <param name="processorName">The processors type name.</param>
        /// <returns>A double variable of the energy used.</returns>
        public double GetTaskEnergy(double runtime, double referenceFrequency, ProcessorSpecList processSpecList, string processorName)
        {
            /// To store the energy.
            double energy = 0;

            /// These variables will store the processor coefficients.
            double coefficient0 = 0;
            double coefficient1 = 0;
            double coefficient2 = 0;

            /// Index of current processor.
            int processSpecIndex;

            /// Iterate through the processor specs and get the coefficients.
            for (processSpecIndex = 0; processSpecIndex < processSpecList.List.Count; processSpecIndex++)
            {
                if (processorName == processSpecList.List[processSpecIndex].Type)
                {
                    coefficient0 = Convert.ToDouble(processSpecList.List[processSpecIndex].Coeff0);
                    coefficient1 = Convert.ToDouble(processSpecList.List[processSpecIndex].Coeff1);
                    coefficient2 = Convert.ToDouble(processSpecList.List[processSpecIndex].Coeff2);
                }

                /// Instantiate new ProcessorSpec object with coefficients.
                ProcessorSpec processorType = new ProcessorSpec(coefficient2, coefficient1, coefficient0);

                /// Get the Energy.
                energy = processorType.Energy(referenceFrequency, runtime);
            }

             return energy;
        }


        /// <summary>
        /// This function gets the tasks for each allocation and adds them to a list based on which processor they are assigned to.
        /// The task then passes these lists to the ProcessLocalCommunicationsEnergy() function to get the local energy used
        /// and sets this to each task.
        /// </summary>
        /// <param name="tasks">A list of tasks.</param>
        /// <param name="taskProcessorList">A list of task id's and their processor id's.</param>
        public void LocalCommunicationEnergy(TaskList tasks, TaskProcessorList taskProcessorList)
        {
            /// Create a dictionary to hold the processors and their tasks.
            var dictionary = new Dictionary<int, List<Task>>();

            /// Holds the current processor id.
            int processorId;

            /// Holds the current task id.
            int taskIndex;

            /// Used to iterate through the task process list.
            int taskProcessIndex;

            ///Loop through the list of tasks and their processors.
            for (taskProcessIndex = 0; taskProcessIndex < taskProcessorList.List.Count; taskProcessIndex++)
            {
                /// Set the processor id.
                processorId = taskProcessorList.List[taskProcessIndex].ProcessorId;

                /// Set the task id.
                taskIndex = taskProcessorList.List[taskProcessIndex].Id;

                if (taskIndex < tasks.List.Count)
                {
                    /// Check if the processor id is already a key in the dictionary. If not, make new key and Task list.
                    if (!dictionary.ContainsKey(processorId))
                        dictionary.Add(processorId, new List<Task>());

                    /// Add the task to the correct processor key.
                    dictionary[processorId].Add(tasks.List[taskIndex]);
                }
            }

            /// Iterate through and process the local communication for each of the tasks.
            foreach (var processor in dictionary)
            {
                ProcessLocalCommunicationsEnergy(processor.Value, taskProcessorList);
            }
        }

        /// <summary>
        /// This function is used to compute and set the local energy energy consumed by a task.
        /// </summary>
        /// <param name="processor"></param>
        /// <param name="taskProcessorList"></param>
        public void ProcessLocalCommunicationsEnergy(List<Task> processor, TaskProcessorList taskProcessorList)
        {
            /// This loop calculates the local communications energy consumed and sets it to the tasks in taskProcessorList.
            for (int x = 0; x < processor.Count; x++)
            {
                double localCommunication = 0;
                int taskId = processor[x].Id;
                int nextTaskId = 0;

                while (nextTaskId < processor.Count)
                {
                    /// Get the local communication for the given task.
                    localCommunication += double.Parse(processor[x].LocalCommunications[processor[nextTaskId].Id]);

                    /// Set local communication energy in TaskProcessor object.
                    taskProcessorList.List[taskId].LocalCommunicationEnergy = localCommunication;

                    nextTaskId++;
                }
            }
        }

        /// <summary>
        /// This function gets the tasks for each allocation and adds them to a list based on which processor they are assigned to.
        /// The task then passes these lists to the ProcessLocalCommunicationsEnergy() function to get the remote energy used
        /// and sets this to each task.
        /// </summary>
        /// <param name="tasks">A list of tasks.</param>
        /// <param name="taskProcessorList">A list of task ids and their processor ids.</param>
        public void RemoteCommunicationEnergy(TaskList tasks, TaskProcessorList taskProcessorList)
        {
            /// Create a dictionary to hold the processors and their tasks.
            var dictionary = new Dictionary<int, List<Task>>();

            int processorId = 0;
            int taskIndex = 0;

            /// This loop iterates over the tasks in the list and adds each task to a list
            /// based on which processor they are NOT assigned to. 
            for (int i = 0; i < taskProcessorList.List.Count; i++)
            {
                processorId = taskProcessorList.List[i].ProcessorId;
                taskIndex = taskProcessorList.List[i].Id;

                if (taskIndex < tasks.List.Count)
                {
                    /// Check if the processor id is already a key in the dictionary. If not, make new key and Task list.
                    if (!dictionary.ContainsKey(processorId))
                        dictionary.Add(processorId, new List<Task>());
                }
            }

            /// Iterate through the rask processors list and if the processor id does not match the dictionary key, add task to dicionary.
            for (int i = 0; i < taskProcessorList.List.Count; i++)
            {
                processorId = taskProcessorList.List[i].ProcessorId;
                taskIndex = taskProcessorList.List[i].Id;

                if (taskIndex < tasks.List.Count)
                {
                    /// Loop through dictionary, if the task is not assigned to the processor id, add it to the list.
                    foreach (var processor in dictionary)
                    {
                        if (processor.Key != processorId)
                        {
                            /// Add tasks to processor id they are not assigned to.
                            dictionary[processor.Key].Add(tasks.List[taskIndex]);
                        }
                    }
                }
            }

            /// Loop through the task processor list and compute the remote communication for each task.
            for (int i = 0; i < taskProcessorList.List.Count; i++)
            {
                foreach (var processor in dictionary)
                {
                    if (taskProcessorList.List[i].ProcessorId == processor.Key)
                    {
                        /// Get the task id.
                        int taskId = taskProcessorList.List[i].Id;

                        /// Call function to compute and set remote communication.
                        ProcessRemoteCommunications(processor.Value, taskId, taskProcessorList, tasks);
                    }
                }
            }
        }

        /// <summary>
        /// This function is used to compute and set the remote energy energy consumed by a task.
        /// </summary>
        /// <param name="processor">A list of the tasks set to a certain processor.</param>
        /// <param name="taskId">The current task id.</param>
        /// <param name="taskProcessorList">A list of task ids and their processor ids.</param>
        /// <param name="tasks">A list of tasks.</param>
        public void ProcessRemoteCommunications(List<Task> processor, int taskId, TaskProcessorList taskProcessorList, TaskList tasks)
        {
            double remoteCommunication = 0;

            /// This loop calculates the remote communications energy consumed and sets it to the tasks in taskProcessorList.
            for (int x = 0; x < processor.Count; x++)
            {
                if (taskId < tasks.List.Count)
                {
                    /// Get the remote communication for the given task.
                    remoteCommunication += double.Parse(tasks.List[taskId].RemoteCommunications[processor[x].Id]);

                    /// Set remote communication energy in TaskProcessor object.
                    taskProcessorList.List[taskId].RemoteCommunicationEnergy = remoteCommunication;
                }
            }
        }

        /// <summary>
        /// This function computes the total energy used for a program.
        /// </summary>
        /// <param name="localCommunication">Local communication energy for an allocation.</param>
        /// <param name="remoteCommunication">Remote communication for an allocation.</param>
        /// <param name="taskEnergy">The task energy for an allocation.</param>
        /// <returns>a double variable containing the total energy.</returns>
        public double GetTotalEnergy(double localCommunication, double remoteCommunication, double taskEnergy)
        {
            double energy = 0;

            /// Compute the total energy of a program by adding task energy, with local and remote communications.
            energy = taskEnergy + localCommunication + remoteCommunication;

            return energy;
        }

        public double GetTotalAllocationEnergy()
        {
            double energy = 0;



            return energy;
        }
    }
}
