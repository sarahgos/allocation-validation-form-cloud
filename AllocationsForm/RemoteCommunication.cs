using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace AllocationsForm
{
    /// <summary>
    /// Class to store the remote commmunications data.
    /// </summary>
    public class RemoteCommunication
    {
        /// <summary>
        /// List to store the remote communications data.
        /// </summary>
        private List<string> remoteCommunList;

        /// <summary>
        ///  Default constructor.
        /// </summary>
        public RemoteCommunication()
        {
            remoteCommunList = new List<string>();
        }

        /// <summary>
        /// Property to get and set the remote communications list.
        /// </summary>
        public List<string> List { get => remoteCommunList; set => remoteCommunList = value; }

        /// <summary>
        /// Function to get the remote communications for each task.
        /// </summary>
        /// <param name="tasks">List of tasks.</param>
        public void GetTaskRemoteCommunications(TaskList tasks)
        {
            /// Iterator.
            int index = 0;

            /// Task iterator.
            int taskIndex;

            /// Iterate through tasks list and get remote communication.
            for (taskIndex = 0; taskIndex < tasks.List.Count; taskIndex++)
            {
                /// Make a new list in the tasks object to store remote communication data.
                tasks.List[taskIndex].RemoteCommunications = new List<string>();

                /// Iterate through the remote communications list and set the data to the task object.
                for (int x = 0; x < remoteCommunList.Count; x++)
                {
                    if (remoteCommunList[index] != Constants.SemiColon)
                    {
                        tasks.List[taskIndex].RemoteCommunications.Add(remoteCommunList[index]);
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
