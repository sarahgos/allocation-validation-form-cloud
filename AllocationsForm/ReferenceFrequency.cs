using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationsForm
{
    /// <summary>
    /// ReferenceFrequency class holds the program reference frequency.
    /// </summary>
    public class ReferenceFrequency
    {
        /// <summary>
        /// String holds the frequency.
        /// </summary>
        string _refFreq;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ReferenceFrequency() { }

        /// <summary>
        /// Property to get and set program reference frequency.
        /// </summary>
        public string RefFreq { get => _refFreq; set => _refFreq = value; }
    }
}
