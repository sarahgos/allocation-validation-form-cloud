using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace AllocationsForm
{
    /// <summary>
    /// This class holds the runtime data, and contains the functions to compute runtime and energy consumption for an allocation.
    /// </summary>
    public class Runtime
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        public Runtime() { }

        /// <summary>
        /// Computes a task runtime.
        /// </summary>
        /// <param name="runtime">The tasks given runtime.</param>
        /// <param name="refFreq">The programs reference frequency.</param>
        /// <param name="processorFreq">The processors reference frequency.</param>
        /// <returns>A double result containing the task runtime.</returns>
        public double GetTaskRuntime(double runtime, double refFreq, double processorFreq)
        {
            double result = 0;

            result = runtime * (refFreq / processorFreq);

            return result;
        }

        /// <summary>
        /// This function gets the runtime for each processor that a task is assigned to and returns a dictionary with a processor id and runtime value.
        /// </summary>
        /// <param name="referenceFreq">The reference frequency of a program.</param>
        /// <param name="tasks">A list of tasks.</param>
        /// <param name="processorList">A list of processors and their info.</param>
        /// <param name="taskProcessList">A list of task ids and their respective processor ids.</param>
        /// <param name="processorAmount">The amount of processors in program.</param>
        /// <returns>A dictionary containing the processor ids as a key and runtime as a value.</returns>
        public Dictionary<int , double> ProcessorRuntimeConsumed(ReferenceFrequency referenceFreq, TaskList tasks, ProcessorList processorList, TaskProcessorList taskProcessList, int processorAmount)
        {
            /// Create a dictionary to hold the processors and their tasks.
            var resultDictionary = new Dictionary<int, double>();

            /// To store the result.
            double processorResult;
            
            /// The task index to be iterated through.
            int taskIndex;

            /// The processor index to be iterated through.
            int processorIndex = 0;

            /// While the processor index is less than the amount of processors.
            while (processorIndex < processorAmount)
            {
                processorResult = 0;

                /// Iterate through the allocations list and get the runtime for each task.
                for (taskIndex = 0; taskIndex < taskProcessList.List.Count; taskIndex++)
                {
                    /// Set the processor id.
                    int processorId = taskProcessList.List[taskIndex].ProcessorId;

                    /// If the processor id matches the processor index.
                    if (processorId == processorIndex)
                    {
                        /// Get the runtime for the tasks on that processor.
                        processorResult += GetAllocationRuntime(taskProcessList.List[taskIndex].Id, tasks, referenceFreq.RefFreq, processorList.List[processorId].Frequency);

                        /// Add to the dictionary.
                        resultDictionary[processorId] = processorResult;
                    }
                }
                processorIndex++;
            }

           return resultDictionary;
        }

        /// <summary>
        /// This function gets the allocation runtime.
        /// </summary>
        /// <param name="taskId">The id of the current task.</param>
        /// <param name="tasks">A list of tasks.</param>
        /// <param name="refFreq">The reference frequency of the program.</param>
        /// <param name="processFreq">The reference frequency of the processor.</param>
        /// <returns>A double result containing the runtime.</returns>
        public double GetAllocationRuntime(int taskId, TaskList tasks, string refFreq, string processFreq)
        {
            /// Stores the runtime result.
            double result = 0;

            /// Runtime object to access runtime methods.
            Runtime runtime = new Runtime();

            if (taskId < tasks.List.Count)
            {
                /// Get the task runtimes and store as the result.
                result = runtime.GetTaskRuntime(double.Parse(tasks.List[taskId].Runtime), double.Parse(refFreq),
                    double.Parse(processFreq));
            }

            return result;
        }
    }
}
