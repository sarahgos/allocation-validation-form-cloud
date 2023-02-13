using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace AllocationsForm
{
	/// <summary>
	/// This class validates the allocations and displays the errors of invalid allocations in the GUI.
	/// </summary>
    public partial class AllocationValidation : Form
    {
		/// <summary>
		/// List to store the validation errors.
		/// </summary>
        private List<string> validationErrors;

		/// <summary>
		/// List to store the allocation runtime.
		/// </summary>
		private List<string> allocationRuntime;

		/// <summary>
		/// Stores the program runtime.
		/// </summary>
		private string programRuntime;

		/// <summary>
		/// List to store the allocation energy.
		/// </summary>
		private List<string> allocationEnergy;

		/// <summary>
		/// Stores the number of tasks per program.
		/// </summary>
		private string programTaskNumber;

		/// <summary>
		/// Stores the list of allocations and their processor tasks.
		/// </summary>
		private AllocationsProcessorTaskList allocationsList;

		/// <summary>
		/// List to store taff errors.
		/// </summary>
		private List<string> taffErrors;

		/// <summary>
		/// List to store cff errors.
		/// </summary>
		private List<string> cffErrors;

		/// <summary>
		/// Default constructor.
		/// </summary>
        public AllocationValidation()
        {
            validationErrors = new List<string>(); 
        }

        /// <summary>
        /// Overloaded constructor.
        /// </summary>
        /// <param name="validationErrors">The list of validation errors.</param>
        /// <param name="allocationRuntime">The list of allocation runtimes.</param>
        /// <param name="programRuntime">The program runtime.</param>
        /// <param name="allocationEnergy">List of allocations energy.</param>
        /// <param name="programTaskNumber">The number of tasks per program.</param>
        /// <param name="allocationsList">The list of allocations.</param>
        /// <param name="taffErrors">The list of taff errors.</param>
        /// <param name="cffErrors">The list of cff errors.</param>
        public AllocationValidation(List<string> validationErrors, List<string> allocationRuntime, string programRuntime, List<string> allocationEnergy, string programTaskNumber, AllocationsProcessorTaskList allocationsList, List<string> taffErrors, List<string> cffErrors)
        {
            InitializeComponent();
            this.validationErrors = validationErrors;
            this.allocationRuntime = allocationRuntime;
            this.programRuntime = programRuntime;
            this.allocationEnergy = allocationEnergy;
            this.programTaskNumber = programTaskNumber;
            this.allocationsList = allocationsList;
            this.cffErrors = cffErrors;
            this.taffErrors = taffErrors;
        }

        /// <summary>
        /// Property to get and set the validation errors.
        /// </summary>
        public List<string> ValidationErrors { get => validationErrors; set => validationErrors = value; }

		/// <summary>
		/// This function loads up the validation errors onto the labels to display on GUI.
		/// </summary>
		/// <param name="XPosition">The x position of the label.</param>
		/// <param name="YPosition">The y position of the label.</param>
		/// <returns></returns>
		private int ValidationErrorsLoad(int XPosition, int YPosition)
		{
			/// Extension to the y position.
			int yExtension = 30;

			/// Label to display the errors.
			Label errorsLabel = new Label { AutoSize = true };

			/// Label to display the heading.
			Label headingLabel = new Label { AutoSize = true };

			/// Set the location of the heading label.
			headingLabel.Location = new Point(XPosition, YPosition);

			/// Set the location of the errors label.
			errorsLabel.Location = new Point(XPosition, YPosition + yExtension);

			/// To print out the index of the allocation.
			int number = 1;

			/// Set the text to the heading.
			headingLabel.Text = Constants.AllocationsError;

			/// If validation errors list is not empty.
			if (validationErrors.Count == 0)
			{
				/// Set the errors label text.
				errorsLabel.Text += Constants.NoAllocationErrors;
			}
			else
			{
				/// Iterate through the errors and set them to the label.
				foreach (string line in validationErrors)
				{
					errorsLabel.Text += "Error " + number + ": " + line + Constants.NewLineUnicode;
					number++;
				}
			}
			this.Controls.Add(headingLabel);
			this.Controls.Add(errorsLabel);

			/// Get the bottom of the labels for next label.
			int bottomOfLabel = errorsLabel.Bottom;

			return bottomOfLabel;
		}

		/// <summary>
		/// Function calls the validation functionc when te button it pressed.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ValidationButton_Click(object sender, EventArgs e)
        {
			/// X position for label.
			int XPosition = 10;

			/// Y position for label.
			int YPosition = 90;

			/// Validate the runtime.
			ValidateRuntime(allocationRuntime, programRuntime);

			/// Validate the energy.
			ValidateEnergy(allocationEnergy);

			/// Validate the task number.
			ValidateTaskNumber(allocationsList, programTaskNumber);

			/// Load the errors and create the labels 
			ValidationErrorsLoad(XPosition, YPosition);
        }

		/// <summary>
		/// Function to validate the runtime of an allocation.
		/// </summary>
		/// <param name="allocationRuntime">List of allocation runtimes.</param>
		/// <param name="programRuntime">The program runtime.</param>
		public void ValidateRuntime(List<string> allocationRuntime, string programRuntime)
        {
			/// Iterator.
			int index = 1;

			/// Iterate through and check if the allocation runtime is greater than the program runtime and record error.
			foreach (var runtime in allocationRuntime)
			{
				if (double.Parse(runtime) > double.Parse(programRuntime))
					validationErrors.Add("The runtime (" + runtime + ") of an allocation (ID=" + index + ") is greater than the expected program runtime (" + programRuntime + Constants.ClosingBracket);

				index++;
			}
        }

		/// <summary>
		/// Function to validate energy of an allocation.
		/// </summary>
		/// <param name="allocationEnergy">A list of allocation energies.</param>
		public void ValidateEnergy(List<string> allocationEnergy)
		{
			/// The first allocation id.
			int firstId = 1;

			/// The current allocation id.
			int currentId = 1;

			/// Set the first energy.
			string firstEnergy = allocationEnergy[0];

			/// Iterate through and check if the energy differs between allocations and if so record the error.
			foreach (var energy in allocationEnergy)
			{
				if (energy != firstEnergy)
					validationErrors.Add("The energy (" + energy + ") of an allocation (ID=" + currentId + ") differs to the energy value (" + firstEnergy + ") of another allocation (ID=" + firstId + Constants.ClosingBracket);

				currentId++;
			}
		}

		/// <summary>
		/// Function to validate the number of tasks in an allocation.
		/// </summary>
		/// <param name="taskProcessors">A list of the allocations and their task and processor ids.</param>
		/// <param name="programTaskNumber">The amount of tasks per program.</param>
		public void ValidateTaskNumber(AllocationsProcessorTaskList taskProcessors, string programTaskNumber)
        {
			/// Iterator.
			int index = 1;

			/// Iterate through and check if the amount of tasks per allocation is greater or lesser than the program task amount, if so record the error.
			foreach (var alloc in taskProcessors.AllocationsList)
			{
				if (alloc.List.Count < Convert.ToInt32(programTaskNumber))
					validationErrors.Add("Not enough tasks in Allocation " + index + ". Got " + alloc.List.Count + ", expecting " + programTaskNumber);
				if (alloc.List.Count > Convert.ToInt32(programTaskNumber))
					validationErrors.Add("Too many tasks in Allocation " + index + ". Got " + alloc.List.Count + ", expecting " + programTaskNumber);

				index++;
			}
        }

		/// <summary>
		/// When errors button in menu is clicked, load up the errors form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void errorsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var errorsForm = new ErrorsForm(taffErrors, cffErrors);
			errorsForm.Location = this.Location;
			errorsForm.StartPosition = FormStartPosition.Manual;
			errorsForm.FormClosing += delegate { this.Show(); };
			errorsForm.Show();
			this.Hide();
		}
	}
}
