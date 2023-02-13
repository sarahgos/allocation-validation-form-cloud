using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace AllocationsForm
{
    /// <summary>
    /// This class stores each allocations data. It also contains functions to print the allocations data and 
    /// to compute the runtime an energy of each allocation based on the allocation data.
    /// </summary>
    public class AllocationData
    {
        /// <summary>
        /// Stores the id of an allocation.
        /// </summary>
        private string id;

        /// <summary>
        /// Stores the allocation data in an array.
        /// </summary>
        private List<string> array;

        /// <summary>
        /// Stores the ram data in an array.
        /// </summary>
        private List<string> ram;

        /// <summary>
        /// Stores validity of allocation.
        /// </summary>
        private bool isValid;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public AllocationData() 
        { 
            Ram = new List<string>();
            isValid = true;
        }

        /// <summary>
        /// Overloaded constructor.
        /// </summary> 
        public AllocationData(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Overloaded constructor.
        /// </summary>
        public AllocationData(string id, List<string> array, List<string> ram)
        {
            Id = id;
            Array = array;
            this.ram = ram;
            isValid = true;
        }

        /// <summary>
        /// Overloaded constructor.
        /// </summary>
        public AllocationData(List<string> array)
        {
            Array = array;
            isValid = true;
        }

        /// <summary>
        /// Property to get and set the id.
        /// </summary>
        public string Id { get => id; set => id = value; }

        /// <summary>
        /// Property to get and set the Array.
        /// </summary>
        public List<string> Array { get => array; set => array = value; }

        /// <summary>
        /// Property to get and set the ram.
        /// </summary>
        public List<string> Ram { get => ram; set => ram = value; }

        /// <summary>
        /// Property to get and set the allocations validity.
        /// </summary>
        public bool IsValid { get => isValid; set => isValid = value; }

        /// <summary>
        /// Method to print the allocation data onto the form.
        /// </summary>
        /// <param name="_allocList">The list of allocation objects</param>
        /// <param name="index">The index of the current allocation object</param>
        /// <param name="dataIndex">The index of the data array</param>
        /// <returns>The allocation data as a string</returns>
        public string PrintAllocations(List<AllocationData> _allocList, int index)
        {
            string line = null;
            List<string> allocations = new List<string>();
            int dataIndex;
            int allocationIndex;

            for (dataIndex = 0; dataIndex < _allocList[index].Array.Count; dataIndex++)
            {
                if (_allocList[index].Array[dataIndex] != Constants.SemiColon)
                {
                    allocations.Add(_allocList[index].Array[dataIndex]);
                }
                else
                {
                    for (allocationIndex = 0; allocationIndex < allocations.Count; allocationIndex++)
                    {
                        line += allocations[allocationIndex].ToString() + Constants.Comma;
                    }
                    line = line.Remove(line.Length - 1, 1);
                    line += Constants.NewLineUnicode;
                    allocations = new List<string>();
                }
            }
            return line;
        }

        /// <summary>
        /// Method to print out the allocation id, energy and time.
        /// </summary>
        /// <param name="id">Holds the allocation id</param>
        /// <param name="time">Holds the time data of an allocation.</param>
        /// <param name="energy">Holds the energy data of an allocation.</param>
        /// <returns>The allocation id, time and energy as a string.</returns>
        public string PrintAllocationsInfo(string id, string time, string energy, bool isValid)
        {
            string line = null;
          //  if (time != Constants.IsInvalidString)
            
            if (isValid)
                line += "Allocation ID = " + id.ToString() + ", Time = " + time + ", Energy = " + energy + Constants.NewLineUnicode;
            else
                line += "Allocation ID = " + id.ToString() + " is invalid" + Constants.NewLineUnicode;
            //   else
            //       line += "Allocation ID = "  + id.ToString() + " is valid" + Constants.NewLineUnicode;
            return line;
        }
    }
}
