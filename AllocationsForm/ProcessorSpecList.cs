using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationsForm
{
    /// <summary>
    /// A list to store the processor specs.
    /// </summary>
    public class ProcessorSpecList
    {
        /// <summary>
        /// List to store the processor spec objects.
        /// </summary>
        List<ProcessorSpec> list;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ProcessorSpecList()
        {
            List = new List<ProcessorSpec>();
        }

        /// <summary>
        /// Property to get and set the processor spec list.
        /// </summary>
        public List<ProcessorSpec> List { get => list; set => list = value; }

        /// <summary>
        ///  Function to add processor spec object to list.
        /// </summary>
        /// <param name="processorSpec"></param>
        public void AddProcessorSpec(ProcessorSpec processorSpec)
        {
            List.Add(processorSpec);
        }
    }
}
