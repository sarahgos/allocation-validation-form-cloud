using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationsForm
{
    /// <summary>
    /// Class to hold the information about each of the processors.
    /// </summary>
    public class Processor
    {
        /// <summary>
        /// The type of processor.
        /// </summary>
        private string type;

        /// <summary>
        /// The frequency of a processor.
        /// </summary>
        private string frequency;

        /// <summary>
        /// The ram of a processor.
        /// </summary>
        private string ram;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Processor() { }

        /// <summary>
        /// Property to get and set the type of a processor.
        /// </summary>
        public string Type { get => type; set => type = value; }

        /// <summary>
        /// Property to get and set the frequency of a processor.
        /// </summary>
        public string Frequency { get => frequency; set => frequency = value; }

        /// <summary>
        /// Property to get and set the ram of a processor.
        /// </summary>
        public string RAM { get => ram; set => ram = value; }
    }
}
