using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationsForm
{
    /// <summary>
    /// Holds the information of the default logfile from the Taff file.
    /// </summary>
    public class DefaultLogfile
    {
        /// <summary>
        /// Stores the file name.
        /// </summary>
        string _filename;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DefaultLogfile() { }

        /// <summary>
        /// Property to get and set the filename.
        /// </summary>
        public string Filename { get => _filename; set => _filename = value; }


    }
}
