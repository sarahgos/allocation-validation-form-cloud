using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationsForm
{
    /// <summary>
    /// Class to hold the limits of the processor amount, task amount, frequency and ram.
    /// </summary>
    public class Limits
    {
        /// <summary>
        /// Stores the lowest task limit.
        /// </summary>
        string tasksLower;

        /// <summary>
        /// Stores the upper task limit.
        /// </summary>
        string tasksUpper;

        /// <summary>
        /// Stored the lowest processor amount limit.
        /// </summary>
        string processorLower;

        /// <summary>
        /// Stores the upper processor amount limit.
        /// </summary>
        string processorUpper;

        /// <summary>
        /// Stores the lower processor frequency limit.
        /// </summary>
        string processFreqLower;

        /// <summary>
        /// Stores the upper processor frequency limit.
        /// </summary>
        string processFreqUpper;

        /// <summary>
        /// Stores the lower ram limit.
        /// </summary>
        string ramLower;

        /// <summary>
        /// Stores the upper ram limit.
        /// </summary>
        string ramUpper;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Limits() { }

        /// <summary>
        /// Property to set and get the lower task limits.
        /// </summary>
        public string TasksLower { get => tasksLower; set => tasksLower = value; }

        /// <summary>
        /// Property to set and get the upper task limits.
        /// </summary>
        public string TasksUpper { get => tasksUpper; set => tasksUpper = value; }

        /// <summary>
        /// Property to get and set the lower processor amount limit.
        /// </summary>
        public string ProcessorLower { get => processorLower; set => processorLower = value; }

        /// <summary>
        /// Property to get and set the upper processor amount limit.
        /// </summary>
        public string ProcessorUpper { get => processorUpper; set => processorUpper = value; }

        /// <summary>
        /// Property to get and set the lower processor frequency amount limit.
        /// </summary>
        public string ProcessFreqLower { get => processFreqLower; set => processFreqLower = value; }

        /// <summary>
        /// Property to get and set the upper processor frequency amount limit.
        /// </summary>
        public string ProcessFreqUpper { get => processFreqUpper; set => processFreqUpper = value; }

        /// <summary>
        /// Property to get and set the lower ram limit.
        /// </summary>
        public string RAMLower { get => ramLower; set => ramLower = value; }

        /// <summary>
        /// Property to get and set the upper ram limit.
        /// </summary>
        public string RAMUpper { get => ramUpper; set => ramUpper = value; }
    }
}
