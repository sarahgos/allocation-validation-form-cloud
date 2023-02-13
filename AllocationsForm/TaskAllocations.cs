using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace AllocationsForm
{
	/// <summary>
	/// Processes a TAFF file.
	/// </summary>
	public class TaskAllocations
	{
		/// <summary>
		/// Variable to store the CFF name.
		/// </summary>
		private string CFFNameString = null;

		/// <summary>
		/// Variable to store the character to trim white spaces.
		/// </summary>
		private char trimWhiteSpaces = ' ';

		/// <summary>
		/// Variable to store the line from a text document.
		/// </summary>
		private String line;

		/// <summary>
		/// Variable to store number of allocations in TAFF file.
		/// </summary>
		private string allocations;

		/// <summary>
		/// Variable to store the number of tasks in TAFF file.
		/// </summary>
		private string tasks;

		/// <summary>
		/// Variable to store the number of processors in TAFF file.
		/// </summary>
		private string processors;

		/// <summary>
		/// Variable to store the allocations ID.
		/// </summary>
		private int allocationsID;

		/// <summary>
		/// Stores the validity of the taff file.
		/// </summary>
		private bool taffValidity;

		/// <summary>
		/// Property to get and set the tasks.
		/// </summary>
        public string Tasks { get => tasks; set => tasks = value; }

		/// <summary>
		/// Prroperty to get and set the cff filename.
		/// </summary>
        public string CFFName { get => CFFNameString; set => CFFNameString = value; }

        /// <summary>
        /// Function to open a Taff file and get the CFF filename.
        /// </summary>
        public bool GetCffFilename(String path)
		{
			StreamReader taffFileStream = new StreamReader(path);

			do
			{
				/// Get each line from the TAFF file and trim the white spaces.
				line = taffFileStream.ReadLine();
				line.Trim(trimWhiteSpaces);

				if (line.StartsWith(Constants.ConfigFile))
				{
					/// Get the filename of the CFF file.
					String name = line.Split(Constants.EqualSign)[Constants.SecondValue];
					CFFName = name.Split(Constants.QuotationChar)[Constants.SecondValue];
				}

			} while (!taffFileStream.EndOfStream);

			taffFileStream.Close();
			return true;
		}

		/// <summary>
		/// Function process a TAFF file.
		/// </summary>
		public bool ProcessTaffFile(String path, ErrorsForm errors)
		{
			StreamReader taffFileStream = new StreamReader(path);
			Validation validation = new Validation();

			do
			{
				/// Get each line from the TAFF file and trim the white spaces.
				line = taffFileStream.ReadLine();
				/// Bool to store the TAFF validity.
				taffValidity = false;

				/// Run the ValidateTAFF function on each line of data and set _taffValidity. If false immediately return false.
				bool taffValidation = validation.ValidateTAFF(line, errors);
				if (taffValidation)
					taffValidity = true;
				else
				{ 
					taffValidity = false;
				}

			} while (!taffFileStream.EndOfStream);

			return taffValidity;
		}

		/// <summary>
		/// Function to get the allocation data from the allocations.
		/// </summary>
		/// <param name="path">Taff file path.</param>
		/// <param name="errors">An error object to add errors to list.</param>
		/// <returns>A list containing the AllocationsData.</returns>
		public List<AllocationData> GetAllocationData(String path, ErrorsForm errors, ProgramData programData)
		{
			StreamReader taffFileStream = new StreamReader(path);

			/// Determines whether it is a new allocation.
			bool newAllocation = false;

			/// A data list for AllocationsData constructor.
			List<string> data = new List<string>();

			/// A ram list for allocationData constructor.
			List<string> ram = new List<string>();

			/// Instantiate new AllocationData object.
			AllocationData allocationData = new AllocationData(Constants.ZeroString, data, ram);

			/// Instantiate AllocactionsDataList.
			AllocationsDataList allocDataList = new AllocationsDataList();

			/// Iterator for checking the processors.
			int processorCheck = 0;

			/// Checks if each processor has at least one task.
			bool processorHasTask = false;

			/// Records the number of tasks in an allocation.
			int taskNumber = 0;

			do
			{
				/// Get each line from the TAFF file and trim the white spaces.
				line = taffFileStream.ReadLine();

				/// If line starts with ALLOCATION-DATA=.
				if (line.StartsWith(Constants.AllocationData))
                {
					/// Get data after equal sign.
					line = line.Substring(line.LastIndexOf(Constants.EqualsChar) + 1);

					/// Splits string at commas.
					string[] stringData = line.Split(Constants.Comma);

					/// Store the first value (number of allocations) of string in the allocations field.
					allocations = stringData[Constants.FirstValue];

					/// Store the second value (number of tasks) in the tasks field.
					tasks = stringData[Constants.SecondValue];

					/// Store the number of processors in the processors field.
					processors = stringData[Constants.ThirdValue];
				}

				/// If line starts with ALLOCATION-ID=.
				else if (line.StartsWith(Constants.AllocationId))
				{
					/// Get the data after the equals sign.
					string id = line.Substring(line.LastIndexOf(Constants.EqualsChar) + 1);

					/// Set the allocations id.
					allocationData.Id = id;

					/// Check validity of id.
					allocationData.IsValid = CheckAllocationId(id);

					/// Confirm it is a new allocations.
					newAllocation = true;
				}

				/// If the line is the allocations data.
				else if (newAllocation && line.StartsWith(Constants.ZeroString) || line.StartsWith(Constants.OneString))
				{
					/// Split at the comma.
					string[] stringData = line.Split(Constants.Comma);

					/// Iterator.
					int index = 0;

					/// Iterate through string and add to the allocations data array.
					foreach (var str in stringData)
					{
						/// If the string == 1.
						if (str == Constants.OneString)
						{
							/// Confirm that processor has a task.
							processorHasTask = true;

							/// Up the task number.
							taskNumber++;
						}

						/// Add allocation data to array.
						allocationData.Array.Add(str);
						index++;
					}

					/// Add semicolons after line ends.
					allocationData.Array.Add(Constants.SemiColon);

					/// Advance the processor check iterator.
					processorCheck++;

					/// If there is no task for a processor, set isvalid to false.
					if (!processorHasTask)
						allocationData.IsValid = false;
				}

				/// If there is a blank line.
				else if (newAllocation && line.Length == 0)
				{
					/// Check the amount of processors is correct.
					allocationData.IsValid = CheckProcessorAmount(processorCheck, errors, allocationData.Id, allocationData.IsValid);

					/// Check the number of tasks in this allocation.
					allocationData.IsValid =  CheckTaskNumber(taskNumber, errors, allocationData.Id, Convert.ToInt32(programData.NumTasks), allocationData.IsValid);

					/// It is no longer a new allocation.
					newAllocation = false;

					/// Add the allcoation data to a list.
					allocDataList.AddAllocData(allocationData);

					/// Instantiate new object.
					allocationData = new AllocationData(data);

					/// Instantiate new list on object to store allocations data.
					allocationData.Array = new List<string>();

					/// Reset processor check iterator.
					processorCheck = 0;

					/// Reset boolean.
					processorHasTask = false;

					/// Reset task number.
					taskNumber = 0;
				}

			} while (!taffFileStream.EndOfStream);

			return allocDataList.List;
		}

		/// <summary>
		/// This function gets the taks ids and their processors id.
		/// </summary>
		/// <param name="path">The taff directory path</param>
		/// <returns>A list of allocations and their task/processor ids.</returns>
		public AllocationsProcessorTaskList GetTaskProcessorData(String path)
		{
			StreamReader taffFileStream = new StreamReader(path);

			/// Determine where it is a new allocation.
			bool newAllocation = false;

			/// Instantiate TaskProcessor object.
			TaskProcessor taskProcessor = new TaskProcessor();

			/// Instantiate task processor list.
			TaskProcessorList taskProcessList = new TaskProcessorList();

			/// Instantiate allocations processor task list to store all the allocations.
			AllocationsProcessorTaskList allocProcTaskList = new AllocationsProcessorTaskList();

			/// Processor iterator.
			int processorIndex = -1;

			/// Task iterator.
			int taskIndex = 0;

			do
			{
				/// Get each line from the TAFF file and trim the white spaces.
				line = taffFileStream.ReadLine();

				/// Line starts with ALLCATION-ID=.
				if (line.StartsWith(Constants.AllocationId))
				{
					/// It is a new allocation.
					newAllocation = true;
				}

				/// When we reach the data line.
				else if (newAllocation && line.StartsWith(Constants.ZeroString) || line.StartsWith(Constants.OneString))
				{ 
					/// Split the string at the commas.
					string[] stringData = line.Split(Constants.Comma);
					
					/// Advance the processor iterator.
					processorIndex++;

					/// Iterate through the string.
					foreach (var str in stringData)
					{

						/// If the string == 1.
						if (str == Constants.OneString)
						{
							/// Set the task index.
							taskProcessor.Id = taskIndex;

							/// Set the processor index. 
							taskProcessor.ProcessorId = processorIndex;

							/// Add the task to the task processor list.
							taskProcessList.AddTask(taskProcessor);

							/// Create new taskProcessor object.
							taskProcessor = new TaskProcessor();
						}
						taskIndex++;
					}		

					taskIndex = 0;
				}
				/// If reach an empty line.
				else if (newAllocation && line.Length == 0)
				{
					/// No longer a new allocation.
					newAllocation = false;

					/// Add the taskProcessList to the allocations process task list.
					allocProcTaskList.AddTaskList(taskProcessList);

					/// Create new TaskProcessList object.
					taskProcessList = new TaskProcessorList();

					taskIndex = 0;
					processorIndex = -1;
				}

			} while (!taffFileStream.EndOfStream);

			return allocProcTaskList;
		}

		public bool CheckAllocationId(string id)
        {
			//	int intId = Convert.ToInt32(id);

			bool isNumber = int.TryParse(id, out int NumericValue);

			return isNumber;
        }

		/// <summary>
		/// Method to check if the amount of processors in a taff file is correct.
		/// </summary>
		/// <param name="number">Number of processors</param>
		/// <param name="errors">Errors object to add to list of errors.</param>
		/// <param name="id">The allocation id.</param>
		public bool CheckProcessorAmount(int number, ErrorsForm errors, string id, bool isValid)
        {
			/// If the number of processors in greater than the programs processor number.
			if (number > Convert.ToInt32(processors))
			{
				/// Add an error to the errors list.
				errors.TaffErrors.Add("In Allocation " + id + ". Too many processors, expecting " + processors + " processors.");

				isValid = false;
			}

			/// If the number of processors in lesser than the programs processor number.
			else if (number < Convert.ToInt32(processors))
			{
				/// Add an error to the errors list.
				errors.TaffErrors.Add("In Allocation " + id + ". Not enough processors, expecting " + processors + " processors.");

				isValid = false;
			}

			return isValid;
		}

		/// <summary>
		/// Checks the amount of tasks in an allocation matches that of the program info.
		/// </summary>
		/// <param name="taskNumber">Number of task in allocation.</param>
		/// <param name="errors">Errors object to record errors.</param>
		/// <param name="id">Allocation id.</param>
		public bool CheckTaskNumber(int taskNumber, ErrorsForm errors, string id, int programTaskNumber, bool isValid)
		{
			/// If the number of tasks in an allocation is greater than program task number.
			if (taskNumber > programTaskNumber)
			{
				/// Add to errors.
				errors.TaffErrors.Add("In Allocation " + id + ". Too many tasks, expecting " + Tasks + " tasks.");

				/// Set validity to false
				isValid = false;
			}

			/// If the number of tasks in an allocation is lesser than program task number.
			else if (taskNumber < programTaskNumber)
			{
				/// Add to errors.
				errors.TaffErrors.Add("In Allocation " + id + ". Not enough tasks, expecting " + Tasks + " tasks.");

				/// Set validity to false
				isValid = false;
			}

			return isValid;
		}
	}
}
