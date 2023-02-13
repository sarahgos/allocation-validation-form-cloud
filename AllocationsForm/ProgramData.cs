using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationsForm
{
    /// <summary>
    /// Stores the program data.
    /// </summary>
    public class ProgramData
    {
        /// <summary>
        /// Stores the duration of a program.
        /// </summary>
        string duration;

        /// <summary>
        /// Stores the number of tasks in a program.
        /// </summary>
        string numTasks;

        /// <summary>
        /// Stores the number of processors in a program.
        /// </summary>
        string numProcessors;

        /// <summary>
        ///  Default Constructor.
        /// </summary>
        public ProgramData() { }

        /// <summary>
        /// Property to get and set the duration of a program.
        /// </summary>
        public string Duration { get => duration; set => duration = value; }

        /// <summary>
        /// Property to get and set the number of tasks of a program.
        /// </summary>
        public string NumTasks { get => numTasks; set => numTasks = value; }

        /// <summary>
        /// Property to get and set the number of processors of a program.
        /// </summary>
        public string NumProcessors { get => numProcessors; set => numProcessors = value; }
    }
}
