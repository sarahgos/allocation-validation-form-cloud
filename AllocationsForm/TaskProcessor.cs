using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationsForm
{
    /// <summary>
    /// This class stores a tasks id along with their processor id.
    /// </summary>
    public class TaskProcessor
    {
        /// <summary>
        /// Stores the tasks id.
        /// </summary>
        private int id;

        /// <summary>
        /// Stores the processor id.
        /// </summary>
        private int processorId;

        /// <summary>
        /// Stores the local communication energy of a task.
        /// </summary>
        private double localCommunicationEnergy;

        /// <summary>
        /// Stores the remote communication energy of a task.
        /// </summary>
        private double remoteCommunicationEnergy;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public TaskProcessor() { }

        /// <summary>
        /// Property to get and set the task id.
        /// </summary>
        public int Id { get => id; set => id = value; }

        /// <summary>
        /// Property to get and set the processor id.
        /// </summary>
        public int ProcessorId { get => processorId; set => processorId = value; }

        /// <summary>
        /// Property to get and set the local communication energy.
        /// </summary>
        public double LocalCommunicationEnergy { get => localCommunicationEnergy; set => localCommunicationEnergy = value; }

        /// <summary>
        /// Property to get and set the remote communication energy.
        /// </summary>
        public double RemoteCommunicationEnergy { get => remoteCommunicationEnergy; set => remoteCommunicationEnergy = value; }
    }
}
