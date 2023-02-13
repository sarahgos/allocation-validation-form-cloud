using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationsForm
{
    /// <summary>
    /// This class stores the data for each of the tasks.
    /// </summary>
    public class Task
    {
        /// <summary>
        /// Stores the task runtime.
        /// </summary>
        private string runtime;

        /// <summary>
        /// Stores the task ram.
        /// </summary>
        private string ram;

        /// <summary>
        /// Stores the tasks processor id.
        /// </summary>
        private int processorID;

        /// <summary>
        /// Stores the tasks local communications.
        /// </summary>
        private List<string> localCommunications;

        /// <summary>
        /// Stores the tasks remote communications.
        /// </summary>
        private List<string> remoteCommunications;

        /// <summary>
        /// Stores task id.
        /// </summary>
        private int id;

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Task() { }

        /// <summary>
        /// Property to get and set task runtime.
        /// </summary>
        public string Runtime { get => runtime; set => runtime = value; }

        /// <summary>
        /// Property to get and set task ram.
        /// </summary>
        public string RAM { get => ram; set => ram = value; }

        /// <summary>
        /// Property to get and set task processor id.
        /// </summary>
        public int ProcessorID { get => processorID; set => processorID = value; }

        /// <summary>
        /// Property to get and set task local communications.
        /// </summary>
        public List<string> LocalCommunications { get => localCommunications; set => localCommunications = value; }

        /// <summary>
        /// Property to get and set task remote communications.
        /// </summary>
        public List<string> RemoteCommunications { get => remoteCommunications; set => remoteCommunications = value; }

        /// <summary>
        /// Property to get and set task id.
        /// </summary>
        public int Id { get => id; set => id = value; }
    }

}
