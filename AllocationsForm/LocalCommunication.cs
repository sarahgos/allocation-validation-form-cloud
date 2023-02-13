using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace AllocationsForm
{
    /// <summary>
    /// Class to store the local communications data.
    /// </summary>
    public class LocalCommunication
    {
        /// <summary>
        /// List to store the data.
        /// </summary>
        private List<string> localCommList;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LocalCommunication()
        {
            localCommList = new List<string>();
        }

        /// <summary>
        /// Property to get and set the list.
        /// </summary>
        public List<string> List { get => localCommList; set => localCommList = value; }

        /// <summary>
        /// Function to get the local communications of the tasks.
        /// </summary>
        /// <param name="tasks">A list of tasks.</param>
        public void GetTaskLocalCommunications(TaskList tasks)
        {
            /// Iterator index.
            int index = 0;

            /// Task iterator index.
            int taskIndex;

            /// Local communication iterator.
            int localCommIndex;

            /// Iterate through tasks list and get local communication.
            for (taskIndex = 0; taskIndex < tasks.List.Count; taskIndex++)
            {
                /// Make a new list in the tasks object to store local communication data.
                tasks.List[taskIndex].LocalCommunications = new List<string>();

                /// Iterate through the local communications list and set the data to the task object.
                for (localCommIndex = 0; localCommIndex < localCommList.Count; localCommIndex++)
                {
                    if (localCommList[index] != Constants.SemiColon)
                    {
                        tasks.List[taskIndex].LocalCommunications.Add(localCommList[index]);
                        index++;
                    }
                    else
                    {
                        index++;
                        break;
                    }
                }    
            }
        }
    }
}
