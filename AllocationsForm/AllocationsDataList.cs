using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationsForm
{
    /// <summary>
    /// Class to hold a list of AllocationData objects.
    /// </summary>
    public class AllocationsDataList
    {
        /// <summary>
        /// Holds a list of AllocationData objects.
        /// </summary>
        private List<AllocationData> _list;

        /// <summary>
        /// Default COnstructor.
        /// </summary>
        public AllocationsDataList()
        {
            List = new List<AllocationData>();
        }

        /// <summary>
        /// Property to get and set list.
        /// </summary>
        public List<AllocationData> List { get => _list; set => _list = value; }

        /// <summary>
        /// Method to add the AllocationData objects to the list.
        /// </summary>
        /// <param name="data">This is the AllocationData object.</param>
        public void AddAllocData(AllocationData data)
        {
            _list.Add(data);
        }
    }
}
