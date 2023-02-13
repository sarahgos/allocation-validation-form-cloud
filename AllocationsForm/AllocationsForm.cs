using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace AllocationsForm
{
	/// <summary>
	/// The Allocations form, used for displaying the allocations data and time and energy consumptions.
	/// </summary>
	public partial class AllocationsForm : Form
	{
		/// <summary>
		/// Stores whether taff file is valid or invalid.
		/// </summary>
		private bool taffValid;

		/// <summary>
		/// Stores if a cff file is valid or invalid.
		/// </summary>
		private bool cffValid;

		/// <summary>
		/// Stored the directory path of a cff file.
		/// </summary>
		private string cffPath;

		/// <summary>
		/// Object to access the AllocationsData methods.
		/// </summary>
		private AllocationData allocationData;

		/// <summary>
		/// A list to store all the allocations and their data.
		/// </summary>
		private List<AllocationData> allocDataList;

		/// <summary>
		/// Stores the default logfile info.
		/// </summary>
		private DefaultLogfile defaultLogFile;

		/// <summary>
		/// Used to access the Limits class.
		/// </summary>
		private Limits limits;

		/// <summary>
		/// Used to access ProgramData.
		/// </summary>
		private ProgramData programData;

		/// <summary>
		/// Used to access ReferenceFrequency.
		/// </summary>
		private ReferenceFrequency referenceFreq;

		/// <summary>
		/// Used to access the ProcessorList.
		/// </summary>
		private ProcessorList processList;

		/// <summary>
		/// To access the list of tasks.
		/// </summary>
		private TaskList taskList;

		/// <summary>
		/// Object to access the ProcessorSpecList.
		/// </summary>
		private ProcessorSpecList processorSpecList;

		/// <summary>
		/// LocalCommunication object.
		/// </summary>
		private LocalCommunication localCommunication;

		/// <summary>
		/// LocalCommunication object.
		/// </summary>
		private RemoteCommunication remoteCommunication;

		/// <summary>
		/// List to store the runtime and energy of allocations.
		/// </summary>
		private List<string> runtimeEnergyList;

		/// <summary>
		///  Object to access Energy class methods.
		/// </summary>
		private Energy energy;

		/// <summary>
		/// List to store the allocation times.
		/// </summary>
		private List<string> allocationTimes;

		/// <summary>
		/// List to store the allocation energy.
		/// </summary>
		private List<string> allocationEnergy;

		/// <summary>
		/// Object that holds the allocations and their tasks and processor ids.
		/// </summary>
		private AllocationsProcessorTaskList allocProcTaskList;

		/// <summary>
		/// List to hold the total energy used by an allocation.
		/// </summary>
		private List<string> totalAllocationEnergy;

		/// <summary>
		/// To store the errors.
		/// </summary>
		private ErrorsForm errors;

		/// <summary>
		/// To store the Allocation Validation.
		/// </summary>
		private AllocationValidation allocationValidation;

		/// <summary>
		/// Check if a taff file has been validated.
		/// </summary>
		private bool taffValidated;

		/// <summary>
		/// Check if a cff file has been validated.
		/// </summary>
		private bool cffValidated;

		/// <summary>
		/// Object to access TaskAllocation methods.
		/// </summary>
		private TaskAllocations taskAllocation;

		/// <summary>
		/// Object to access Ram class.
		/// </summary>
		private Ram ram;

		/// <summary>
		/// Object to acces Runtime class.
		/// </summary>
		private Runtime runtime;

		/// <summary>
		/// Default Constructor.
		/// </summary>
        public AllocationsForm()
		{ 
            InitializeComponent();

			this.allocationData = new AllocationData();
			this.allocDataList = new List<AllocationData>();
            this.defaultLogFile = new DefaultLogfile();
            this.limits = new Limits();
			this.programData = new ProgramData();
			this.referenceFreq = new ReferenceFrequency();
			this.processList = new ProcessorList();
			this.taskList = new TaskList();
			this.processorSpecList = new ProcessorSpecList();
			this.localCommunication = new LocalCommunication();
			this.remoteCommunication = new RemoteCommunication();
			this.runtimeEnergyList = new List<string>();
			this.energy = new Energy();
			this.allocationTimes = new List<string>();
			this.allocationEnergy = new List<string>();
			this.allocProcTaskList = new AllocationsProcessorTaskList();
			this.totalAllocationEnergy = new List<string>();
			this.errors = new ErrorsForm();
			this.allocationValidation = new AllocationValidation();
			this.taskAllocation = new TaskAllocations();
			this.ram = new Ram();
			this.runtime = new Runtime();
        }

		/// <summary>
		/// This function opens the taff and cff file, gets the data, processors the data and displays on the GUI.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
		{
			/// Open the dialog box to select file.
			openFileDialog1 = new OpenFileDialog();
			DialogResult result = openFileDialog1.ShowDialog();

			/// String to store the cff filename.
			string CffFilename = null;

			/// task iterator.
			int taskIndex;

			/// If the file is opened successfully.
			if (result == DialogResult.OK)
			{
				/// Get the taff directory path.
				string taffFilepath = openFileDialog1.FileName;

				/// Instantiate new Configuration object.
				Configuration configuration = new Configuration();

				/// If the cff filename was successfully obtained.
				if (taskAllocation.GetCffFilename(taffFilepath))
				{
					/// String to store the validity result string.
					string validResult;

					/// Get the cff filename.
					CffFilename = taskAllocation.CFFName;
					
					/// Process the taff file.
					taffValid = taskAllocation.ProcessTaffFile(taffFilepath, errors);

					/// Get the taff validity and set the validity string.
					if (taffValid)
						validResult = Constants.ValidityTrue;
					else
						validResult = Constants.ValidityFalse;

					/// Get the taff filepath.
					string fileName = taffFilepath;

					/// Get the last index after the last two backclashes.
					int index = fileName.LastIndexOf(Constants.TwoBackwardSlash);

					/// Get the filename.
					if (index >= 0)
						fileName = fileName.Substring(index + 1);

					/// Set the taff validation label to describe the filename and validity.
					taffValidation.Text = "Allocations file: (" + fileName + ") is " + validResult;
					taffValidated = true;
				}

				/// If the CFF filename has been accessed by the TAFF file, get the path to the CFF file and check validation.
				if (CffFilename != null)
				{
					/// String to hole the validity result of the cff file.
					string validResult;

					/// Get the taff file path and replace the last section with the cff filename.
					cffPath = taffFilepath;
					int index = cffPath.LastIndexOf(Constants.TwoBackwardSlash);
					if (index >= 0)
						cffPath = cffPath.Substring(0, index + 1);

					cffPath = cffPath.Insert(index + 1, CffFilename);

					/// Process the cff file and check for validity.
					cffValid = configuration.ProcessCffFile(cffPath, errors);

					/// Get the taff validity and set the validity string.
					if (cffValid)
						validResult = Constants.ValidityTrue;
					else
						validResult = Constants.ValidityFalse;

					/// Set the taff validation label to describe the filename and validity.
					cffValidation.Text = "Configurations file: (" + CffFilename + ") " + validResult;
					cffValidated = true;
				}

				/// If both taff and cff are valid enable to Allocations in menu.
				if (cffValidated && taffValidated)
					allocationsToolStripMenuItem.Enabled = true;
                else
					allocationsToolStripMenuItem.Enabled = false;

				/// Call function to get the data from the cff file.
				GetConfigurationData(configuration, cffPath);

				/// Call function to get the allocation data from the taff file.
				GetAllocationData(taskAllocation, taffFilepath);

				GetProcessorRuntimeAndEnergy();

				/// Set the ram data for each task.
				ram.GetRamData(allocProcTaskList, processList, taskList, allocDataList, Convert.ToInt32(programData.NumProcessors));

				/// Set the local communications for each task.
				localCommunication.GetTaskLocalCommunications(taskList);

				/// Set the remote communications for each task.
				remoteCommunication.GetTaskRemoteCommunications(taskList);
				
				/// Iterate through the each of the allocations and compute the energy used for remote and local communications.
				foreach (var allocation in allocProcTaskList.AllocationsList)
				{
					energy.LocalCommunicationEnergy(taskList, allocation);
					energy.RemoteCommunicationEnergy(taskList, allocation);
				}

				/// Compute and set the total energy used by an allocation.
				ComputeTotalAllocationEnergy();

				/// Set the allocation data onto the labels in the form.
				SetFormLabels();
			}
		}

		/// <summary>
		/// Gets the allocation data from the taff file.
		/// </summary>
		/// <param name="allocation">The task allocations class.</param>
		/// <param name="taffFile">The taff file path</param>
		private void GetAllocationData(TaskAllocations allocation, string taffFile)
        {
			/// Get the allocation data and store it in a list.
			allocDataList = allocation.GetAllocationData(taffFile, errors, programData);

			/// Get the task processor data and store it in a list.
			allocProcTaskList = allocation.GetTaskProcessorData(taffFile);
		}

		/// <summary>
		/// Get the data from the cff file and store it.
		/// </summary>
		/// <param name="configuration">The configuration class object.</param>
		/// <param name="cffFile">The cff file path.</param>
		private void GetConfigurationData(Configuration configuration, string cffFile)
		{
			/// Get default logfile data.
			defaultLogFile = configuration.GetDefaultLogfile(cffFile);

			/// Get limits data.
			limits = configuration.GetLimits(cffFile);

			/// Get program data. 
			programData = configuration.GetProgramData(cffFile);

			/// Get reference frequency data.
			referenceFreq = configuration.GetReferenceFrequency(cffFile);

			/// Get the task runtimes data.
			taskList = configuration.GetTaskRuntime(cffFile);

			/// Get the processors data.
			processList = configuration.GetProcessors(cffFile, errors);

			/// Get the processor specs data.
			processorSpecList = configuration.GetProcessorCoefficients(cffFile, processList, errors);

			/// Get the local communication data.
			localCommunication = configuration.GetLocalCommunication(cffFile);

			/// Get the remote communications data.
			remoteCommunication = configuration.GetRemoteCommunication(cffFile);
		}

		/// <summary>
		/// Function runs through each of the allocations in a program and computes the runtime and energy for each processor tasks are assigned to.
		/// </summary>
		public void GetProcessorRuntimeAndEnergy()
        {
			/// Dictionary to store the runtime data for each processor assigned a task.
			Dictionary<int, double> runtimeDictionary = new Dictionary<int, double>();

			/// Stores the allocation energy.
			double allocEnergy;

			/// Stores the allocation runtime.
			double allocRuntime;

			/// Stores the highest runtime.
			double highestRuntime;

			/// Iterate through each of the allocations in a program.
			foreach (var alloc in allocProcTaskList.AllocationsList)
			{
				/// Get the runtime values of each processor with a task assigned.
				runtimeDictionary = runtime.ProcessorRuntimeConsumed(referenceFreq, taskList, processList, alloc, Convert.ToInt32(programData.NumProcessors));
				 
				allocEnergy = 0;
				allocRuntime = 0;
				highestRuntime = 0;

				/// Iterate through runtime dictionary and compute the energy or each processor.
				foreach (var processor in runtimeDictionary)
				{
					/// Compute energy for each processor.
					allocEnergy += energy.GetTaskEnergy(processor.Value, double.Parse(processList.List[processor.Key].Frequency), processorSpecList, processList.List[processor.Key].Type);

					/// Get the runtime value of an allocation.
					if (processor.Value > highestRuntime)
						highestRuntime = processor.Value;
				}

				/// Add these values to their lists. 
				allocationEnergy.Add(allocEnergy.ToString());
				allocationTimes.Add(Math.Round(highestRuntime, 2).ToString());
			}
		}

		/// <summary>
		/// Function to compute the total energy consumed by an allocation.
		/// </summary>
		public void ComputeTotalAllocationEnergy()
        {
			/// Set the iterator.
			int index = 0;

			/// Iterate through the allocations task processor list.
			foreach (var allocation in allocProcTaskList.AllocationsList)
			{
				/// Store the total energy.
				double totalEnergy = 0;

				/// Store the allocation energy.
				double allocatEnergy = 0;

				/// Store the local communications energy.
				double local = 0;

				/// Store the remot communications energy.
				double remote = 0;

				/// Iterate through each task in the allocations list and get local and remote communications energy.
				foreach (var task in allocation.List)
				{
					local += task.LocalCommunicationEnergy;
					remote += task.RemoteCommunicationEnergy;
				}
				/// Get the total energy of the program.
				totalEnergy = energy.GetTotalEnergy(local, remote, double.Parse(allocationEnergy[index]));
				index++;

				/// Round the energy to 2 decimal places.
				allocatEnergy = Math.Round(totalEnergy, 2);

				/// Add the the totalAllocationEnergy list.
				totalAllocationEnergy.Add(allocatEnergy.ToString());
			}
		}

		/// <summary>
		/// Set the data onto the labels on the form.
		/// </summary>
		public void SetFormLabels()
        {
			/// X axis of the label position.
			int locationX = 10;

			/// Y axis of the label position.
			int locationY = 150;

			/// Extra y axis for further labels.
			int extraYLength = 20;

			/// Extra x axis for further labels.
			int extraXLength = 80;

			/// Extra space for after the end of a label.
			int extraYExtension = 100;

			/// The index for the time and energy list.
			int timeEnergyIndex = 0;

			/// The index for the allocations list.
			int allocationIndex = 0;

			/// The index for the ram list.
			int ramIndex = 0;

			/// To store the string of text.
			string line = null;

			/// String to store the ram text.
			string ramLine = null;

			/// Loop through the list of allocations.
			foreach (var data in allocDataList)
			{
				/// Label1 for the allocation id, time and energy.
				Label label1 = new Label() { AutoSize = true };

				/// Label2 for the allocations data.
				Label label2 = new Label() { AutoSize = true };

				/// Label3 for the ram data.
				Label label3 = new Label() { AutoSize = true };

				/// Set the locations of the 3 labels.
				label1.Location = new Point(locationX, locationY);
				label2.Location = new Point(locationX, locationY + extraYLength);
				label3.Location = new Point(locationX + extraXLength, locationY + extraYLength);

				/// Set the allocation id data.
				label1.Text = allocationData.PrintAllocationsInfo(data.Id, allocationTimes[timeEnergyIndex], totalAllocationEnergy[timeEnergyIndex], data.IsValid);


				/// Set the allocations data.
				label2.Text = allocationData.PrintAllocations(allocDataList, allocationIndex);

				/// Reset line to null.
				line = null;

				/// Iterate through the ram list and set to line.
				foreach (var str in data.Ram)
				{
					if (str != Constants.SemiColon)
						line += str;
					else
						line += Constants.EndOfRamLine;

					ramLine = line;
				}

				/// Set ram data to label3.
				label3.Text = ramLine;

				this.Controls.Add(label1);
				this.Controls.Add(label2);
				this.Controls.Add(label3);

				/// Add space for next labels.
				locationY += extraYExtension;

				/// Up the iterators.
				timeEnergyIndex++;
				allocationIndex++;
				ramIndex += 2;
			}
		}

		/// <summary>
		/// When the errors button in the menu is clicked, open a new errors form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void errorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
			var errorsForm = new ErrorsForm(errors.TaffErrors, errors.CffErrors);
			errorsForm.Location = this.Location;
			errorsForm.StartPosition = FormStartPosition.Manual;
			errorsForm.FormClosing += delegate { this.Show(); };
			errorsForm.Show();
			this.Hide();
		}

		/// <summary>
		/// When the allocations button in the menu is clicked, open a new allocation validation form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void allocationsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var validateAllocations = new AllocationValidation(allocationValidation.ValidationErrors, allocationTimes, programData.Duration, totalAllocationEnergy, 
				taskAllocation.Tasks, allocProcTaskList, errors.TaffErrors, errors.CffErrors);
			validateAllocations.Location = this.Location;
			validateAllocations.StartPosition = FormStartPosition.Manual;
			validateAllocations.FormClosing += delegate { this.Show(); };
			validateAllocations.Show();
			this.Hide();
		}


		private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void AllocationsForm_Load(object sender, EventArgs e)
        {
			
		}

		private void label1_Click(object sender, EventArgs e)
		{

		}
	}
}



