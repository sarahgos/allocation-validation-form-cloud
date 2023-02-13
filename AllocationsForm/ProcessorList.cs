using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationsForm
{
    /// <summary>
    /// Class to store the list of processors.
    /// </summary>
    public class ProcessorList
    {
        /// <summary>
        /// Stores the processors list.
        /// </summary>
        private List<Processor> list;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ProcessorList()
        {
            list = new List<Processor>();
        }


        /// <summary>
        /// Property to get and set the processors list.
        /// </summary>
        public List<Processor> List { get => list; set => list = value; }

        /// <summary>
        /// Function to add a processor to the processors list.
        /// </summary>
        /// <param name="processor">The processor object.</param>
        public void AddProcessor(Processor processor)
        {
            list.Add(processor);
        }
    }
}
