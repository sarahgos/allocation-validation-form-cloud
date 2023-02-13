using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AllocationsForm
{
	/// <summary>
	/// The Configuration class processes a CFF file, stores the data into separate classes. 
	/// Some validation checks are also performed on the cff file in this class.
	/// </summary>
	public class Configuration
	{
		/// <summary>
		/// Variable to store the line from a text document.
		/// </summary>
		private String line;

		/// <summary>
		/// Boolean to store whether or not the cff file is valid.
		/// </summary>
		private bool _cffValidity;

		/// <summary>
		/// Processes a cff file.
		/// </summary>
		/// <param name="path">Contains the path of the cff file.</param>
		/// <param name="errors">Contains the errors form to add any errors to.</param>
		/// <returns>A boolean showing the validity of the file</returns>
		public bool ProcessCffFile(String path, ErrorsForm errors)
		{
			StreamReader cffFileStream = new StreamReader(path);
			Validation validation = new Validation();

			do
			{
				/// Get each line from the CFF file and trim the white spaces.
				line = cffFileStream.ReadLine();

				/// Bool to store the CFF validity.
				_cffValidity = false;

				/// Run the ValidateCFF function on each line of data and set _cffValidity..
				bool cffValidation = validation.ValidateCFF(line, errors);
				if (cffValidation)
					_cffValidity = true;
				else
				{
					_cffValidity = false;
				//	return _cffValidity;
				}

			} while (!cffFileStream.EndOfStream);

			return _cffValidity;
		}

		/// <summary>
		/// Function to get the default logfile name.
		/// </summary>
		/// <param name="path">Contains the path of the file.</param>
		/// <returns>A DefaultLogfile object</returns>
		public DefaultLogfile GetDefaultLogfile(string path)
        {
			StreamReader cffFileStream = new StreamReader(path);
			DefaultLogfile defLogfile = new DefaultLogfile();

			do
			{
				/// Get each line from the CFF file and trim the white spaces.
				line = cffFileStream.ReadLine();

				// Find the default logfile line and save the name into object.
				if (line.StartsWith(Constants.DefaultLogfile))
				{
					defLogfile.Filename = line.Substring(line.LastIndexOf(Constants.EqualSign) + 1);
				}

			} while (!cffFileStream.EndOfStream);

			return defLogfile;
		}

		/// <summary>
		/// Function to get the Limits from cff file.
		/// </summary>
		/// <param name="path">Contains the path of the file.</param>
		/// <returns>A Limits object</returns>
		public Limits GetLimits(string path)
        {
			StreamReader cffFileStream = new StreamReader(path);

			/// Object to store program limits.
			Limits limits = new Limits();

			do
			{
				/// Get each line from the CFF file and trim the white spaces.
				line = cffFileStream.ReadLine();

				/// Stores the limits on the amount of tasks.
				if (line.StartsWith(Constants.LimitsTasks))
				{
					string data = line.Substring(line.LastIndexOf(Constants.EqualSign) + 1);
					string[] stringData = data.Split(Constants.Comma);
					
					limits.TasksLower = stringData[Constants.FirstValue];
					limits.TasksUpper = stringData[Constants.SecondValue];
				}

				/// Stores the limits on the amount of processors.
				if (line.StartsWith(Constants.LimitsProcessors))
				{
					string data = line.Substring(line.LastIndexOf(Constants.EqualSign) + 1);
					string[] stringData = data.Split(Constants.Comma);

					limits.ProcessorLower = stringData[Constants.FirstValue];
					limits.ProcessorUpper = stringData[Constants.SecondValue];
				}

				/// Stores the limits on the amount of processor frequencies.
				if (line.StartsWith(Constants.LimitsProcessorFrequencies))
				{
					string data = line.Substring(line.LastIndexOf(Constants.EqualSign) + 1);
					string[] stringData = data.Split(Constants.Comma);

					limits.ProcessFreqLower = stringData[Constants.FirstValue];
					limits.ProcessFreqUpper = stringData[Constants.SecondValue];
				}

				/// Stores the RAM limits.
				if (line.StartsWith(Constants.LimitsRam))
				{
					string data = line.Substring(line.LastIndexOf(Constants.EqualSign) + 1);
					string[] stringData = data.Split(Constants.Comma);

					limits.RAMLower = stringData[Constants.FirstValue];
					limits.RAMUpper = stringData[Constants.SecondValue];
				}

			} while (!cffFileStream.EndOfStream);

			return limits;
		}

		/// <summary>
		/// Function to get the program data from cff file.
		/// </summary>
		/// <param name="path">Contains the path of the file.</param>
		/// <returns>ProgramData object</returns>
		public ProgramData GetProgramData(string path)
        {
			StreamReader cffFileStream = new StreamReader(path);

			/// For storing the program data.
			ProgramData programData = new ProgramData();

			do
			{
				/// Get each line from the CFF file and trim the white spaces.
				line = cffFileStream.ReadLine();

				/// Get to PROGRAM-DATA= line.
				if (line.StartsWith(Constants.ProgramData))
                {
					/// Get data after equal sign.
					string data = line.Substring(line.LastIndexOf(Constants.EqualSign) + 1);

					/// Split at commas.
					string[] stringData = data.Split(Constants.Comma);

					/// Set duration, number of tasks and umber of processors.
					programData.Duration = stringData[Constants.FirstValue];
					programData.NumTasks = stringData[Constants.SecondValue];
					programData.NumProcessors = stringData[Constants.ThirdValue];
				}

			} while (!cffFileStream.EndOfStream);

			return programData;
		}

		/// <summary>
		/// Function to get the reference frequency from a cff file.
		/// </summary>
		/// <param name="path">Contains the path of the file.</param>
		/// <returns>ReferenceFrequency object</returns>
		public ReferenceFrequency GetReferenceFrequency(string path)
        {
			StreamReader cffFileStream = new StreamReader(path);

			/// Stores the program reference frequency.
			ReferenceFrequency refFreq = new ReferenceFrequency();

			do
			{
				/// Get each line from the CFF file and trim the white spaces.
				line = cffFileStream.ReadLine();

				/// Find the REFERENCE-FREQUENCY= line
				if (line.StartsWith(Constants.ReferenceFrequency))
				{
					/// Set the reference frequency.
					refFreq.RefFreq = line.Substring(line.LastIndexOf(Constants.EqualSign) + 1);
				}

			} while (!cffFileStream.EndOfStream);

			return refFreq;
        }

		/// <summary>
		/// Function to get the task runtime and ram from cff file.
		/// </summary>
		/// <param name="path">Contains the path of the file.</param>
		/// <returns>A list of Task objects</returns>
		public TaskList GetTaskRuntime(string path)
        {
            StreamReader cffFileStream = new StreamReader(path);

			/// Tasks objects to store the task data.
			Task tasks = new Task();

			/// List to hold the task objects.
			TaskList taskList = new TaskList();

			/// To store the task id.
			int id = 0;

			/// Iterator.
			int dataIndex;

			do
			{
				/// Get each line from the CFF file and trim the white spaces.
				line = cffFileStream.ReadLine();

				/// Line starts with TASK-RUNTIME-RAM.
				if (line.StartsWith(Constants.TaskRuntimeRam))
				{
					/// Get the data after the equals sign.
					string data = line.Substring(line.LastIndexOf(Constants.EqualSign) + 1);

					/// Split at the commas.
					string[] stringData = data.Split(Constants.Comma);

					/// Iterates over the string and stores the Runtime value, Ram value and Id in Task() object.
					for (dataIndex = 0; dataIndex < stringData.Length; dataIndex+=2)
                    {
						tasks.Runtime = stringData[dataIndex];
						tasks.RAM = stringData[dataIndex + 1];
						tasks.Id = id;

						/// Add Task() object to a tasks list.
						taskList.AddTask(tasks);

						/// Instantiate new Task() object.
						tasks = new Task();
						id++;
					}
				}
			} while (!cffFileStream.EndOfStream);

			return taskList;
		}

		/// <summary>
		/// Function to get the processors from cff file.
		/// </summary>
		/// <param name="path">Contains the path of the file.</param>
		/// <param name="errors">Contains the errors list to add any errors.</param>
		/// <returns>A list of Processor ojects.</returns>
		public ProcessorList GetProcessors(string path, ErrorsForm errors)
        {
			StreamReader cffFileStream = new StreamReader(path);

			/// Instantiate new Processor() object to store processor data.
			Processor processor = new Processor();

			/// List to store processor objects.
			ProcessorList processList = new ProcessorList();
			int stringIndex;

			do
			{
				/// Get each line from the CFF file and trim the white spaces.
				line = cffFileStream.ReadLine();

				/// If line starts with PROCESSOR-FREQUENCY-RAM.
				if (line.StartsWith(Constants.ProcessorsFrequencyRam))
				{
					/// Get data after equals sign.
					string data = line.Substring(line.LastIndexOf(Constants.EqualSign) + 1);

					/// Split at the comma.
					string[] stringData = data.Split(Constants.Comma);

					/// Iterate through and store the Type, Frequency and RAM in the object.
					for (stringIndex = 0; stringIndex < stringData.Length; stringIndex += 3)
					{
						processor.Type = stringData[stringIndex];
						processor.Frequency = stringData[stringIndex + 1];
						processor.RAM = stringData[stringIndex + 2];

						/// Add Processor() object to list.
						processList.AddProcessor(processor);

						/// Instantiate new object.
						processor = new Processor();
					}
				}

			} while (!cffFileStream.EndOfStream);

			/// Check that each Processor type is unique.
			CheckProcessorType(processList, errors);

			return processList;
		}

		/// <summary>
		/// Function to get the processor coefficients from cff file.
		/// </summary>
		/// <param name="path">Contains the path of the file.</param>
		/// <param name="errors">Error list to add any errors to.</param>
		/// <param name="processors">A list of processors and their info.</param>
		/// <returns>List of ProcessorSpec objects</returns>
		public ProcessorSpecList GetProcessorCoefficients(string path, ProcessorList processors, ErrorsForm errors)
		{
			StreamReader cffFileStream = new StreamReader(path);

			/// To store process specs data.
			ProcessorSpec processSpec = new ProcessorSpec();

			/// To store a list of the process spec objects.
			ProcessorSpecList processSpecList = new ProcessorSpecList();
			int stringIndex;

			do
			{
				/// Get each line from the CFF file and trim the white spaces.
				line = cffFileStream.ReadLine();

				/// Line starts with PROCESSORS-COEFFICIENTS.
				if (line.StartsWith(Constants.ProcessorsCoefficients))
				{
					/// Get data after equal sign.
					string data = line.Substring(line.LastIndexOf(Constants.EqualSign) + 1);

					/// Split at the commas.
					string[] stringData = data.Split(Constants.Comma);

					/// Loop through and store the data in ProcessSpecs() object.
					for (stringIndex = 0; stringIndex < stringData.Length; stringIndex += 4)
					{
						processSpec.Type = stringData[stringIndex];
						processSpec.Coeff0 = stringData[stringIndex + 1];
						processSpec.Coeff1 = stringData[stringIndex + 2];
						processSpec.Coeff2 = stringData[stringIndex + 3];

						/// Add the object to the process specs list.
						processSpecList.AddProcessorSpec(processSpec);

						/// Create new object.
						processSpec = new ProcessorSpec();
					}
				}
			} while (!cffFileStream.EndOfStream);

			/// Check whether the Processor Specs types match those of the Processor types.
			CheckProcessorCoefficientType(processors, processSpecList, errors);

			return processSpecList;
		}

		/// <summary>
		/// Function to get the local communication from cff file.
		/// </summary>
		/// <param name="path">Contains the path of the file.</param>
		/// <returns>LocalCommunications object</returns>
		public LocalCommunication GetLocalCommunication(string path)
        {
			StreamReader cffFileStream = new StreamReader(path);

			/// Instantiate LocalCommmunications() object to store the local communications data.
			LocalCommunication locComm = new LocalCommunication();

			/// Boolean to update to true when "LOCAL-COMMUNICATION=" is reached in data.
			bool localComm = false; 

			do
			{
				/// Get each line from the CFF file and trim the white spaces.
				line = cffFileStream.ReadLine();

				/// Line starts with REMOTE-COMMUNICATION, boolean changed to true.
				if (line.StartsWith(Constants.LocalCommunication))
				{
					localComm = true;
				}

				/// If boolean true and line starts with zero.
				else if (localComm && line.StartsWith(Constants.ZeroString))
				{
					/// Split the data at the comma.
					string[] stringData = line.Split(Constants.Comma);
					int index = 0;

					/// Loop through and add the local communcations data to list.
					foreach (var str in stringData)
					{
						locComm.List.Add(str);
						index++;
					}

					/// At the end of each line add a semicolon.
					locComm.List.Add(Constants.SemiColon);
				}

				/// Once reach the end of the remote communications data, change to false.
				else if (localComm && line.Length == 0)
				{
					localComm = false;
				}
			} while (!cffFileStream.EndOfStream);

			return locComm;
		}

		/// <summary>
		/// Function to get the remote communication from a cff file.
		/// </summary>
		/// <param name="path">Contains the path of the file.</param>
		/// <returns>RemoteCommunication object.</returns>
		public RemoteCommunication GetRemoteCommunication(string path)
		{
			StreamReader cffFileStream = new StreamReader(path);

			/// Instantiate new RemoteCommunication object to store the data. 
			RemoteCommunication remoteComm = new RemoteCommunication();

			/// Boolean to update to true when "REMOTE-COMMUNICATION=" is reached in data.
			bool remoteCommBool = false; 

			do
			{
				/// Get each line from the CFF file and trim the white spaces.
				line = cffFileStream.ReadLine();

				/// Line starts with REMOTE-COMMUNICATION, boolean changed to true.
				if (line.StartsWith(Constants.RemoteCommunication))
				{
					remoteCommBool = true;
				}

				/// If boolean true and line starts with zero.
				else if (remoteCommBool && line.StartsWith(Constants.ZeroString))
				{
					/// Split the data at the comma.
					string[] stringData = line.Split(Constants.Comma);
					int index = 0;

					/// Loop through and add the remote communcations data to list.
					foreach (var str in stringData)
					{
						remoteComm.List.Add(str);
						index++;
					}

					/// At the end of each line add a semicolon.
					remoteComm.List.Add(Constants.SemiColon);
				}

				/// Once reach the end of the remote communications data, change to false.
				else if (remoteCommBool && line.Length == 0)
				{
					remoteCommBool = false;
				}

			} while (!cffFileStream.EndOfStream);

			return remoteComm;
		}

		/// <summary>
		/// This function validates whether or not a processor type is unique. If not, add an error
		/// to the list of cffErrors.
		/// </summary>
		/// <param name="processors">List of processors and their info.</param>
		/// <param name="errors">List of errors to add errors to.</param>
		public void CheckProcessorType(ProcessorList processors, ErrorsForm errors)
        {
			/// Make new list to store processor types.
			List<string> processorTypes = new List<string>();

			/// Add the processor types to the list.
			foreach (var processor in processors.List)
				processorTypes.Add(processor.Type);

			/// Check if the processor types in the list are unique.
			bool isUnique = processorTypes.Distinct().Count() == processorTypes.Count();

			/// If not, add it to the errors list
			if (!isUnique)
				errors.CffErrors.Add(Constants.InvalidProcessorTypeError);
		}

		/// <summary>
		/// This function validates if the processor coefficient types match the processor types in a cff file.
		/// If they don't match, add it as an error to the cfferrors log.
		/// </summary>
		/// <param name="processors"></param>
		/// <param name="processSpecs"></param>
		/// <param name="errors"></param>
		public void CheckProcessorCoefficientType(ProcessorList processors, ProcessorSpecList processSpecs, ErrorsForm errors)
        {
			/// List to store the processor types.
			List<string> processorTypes = new List<string>();

			/// List to store the processor spec types.
			List<string> processSpecTypes = new List<string>();

			/// Add the processor types to a processorTypes list.
			foreach (var processor in processors.List)
				processorTypes.Add(processor.Type);

			/// Add the processSpec to a processPecList.
			foreach (var processSpec in processSpecs.List)
				processSpecTypes.Add(processSpec.Type);

			/// Check if the processor types are the same in both lists.
			bool isUnique = processorTypes.Distinct().Count() == processSpecTypes.Count();

			/// If not, add a a cff error.
			if (!isUnique)
				errors.CffErrors.Add(Constants.InvalidProcessorCoefficientTypeError);
		}
	}
}
