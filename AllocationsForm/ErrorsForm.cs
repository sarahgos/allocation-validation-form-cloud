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
	/// The ErrorsForm class is to store errors and process errors to display on the form.
	/// </summary>
	public partial class ErrorsForm : Form
	{
		/// <summary>
		/// List to store the taff errors for display.
		/// </summary>
		private List<string> taffErrorsList;

		/// <summary>
		/// List to store cff errors for display.
		/// </summary>
		private List<string> cffErrorsList;

		/// <summary>
		/// Default constructor initializing the lists.
		/// </summary>
		public ErrorsForm()
		{
			TaffErrors = new List<string>();
			CffErrors = new List<string>();
		}

		/// <summary>
		/// Overloaded constructor taking in the updated lists.
		/// </summary>
		/// <param name="taffErrorsList">List to store the taff errors.</param>
		/// <param name="cffErrorsList">List to store the cff errors.</param>
		public ErrorsForm(List<string> taffErrorsList, List<string> cffErrorsList)
		{
			InitializeComponent();
			this.taffErrorsList = taffErrorsList;
			this.cffErrorsList = cffErrorsList;
		}

		/// <summary>
		/// Taff errors list property for setting the errors.
		/// </summary>
		public List<string> TaffErrors { get => taffErrorsList; set => taffErrorsList = value; }

		/// <summary>
		/// Cff errors list property for setting the errors.
		/// </summary>
        public List<string> CffErrors { get => cffErrorsList; set => cffErrorsList = value; }

		/// <summary>
		/// Load the errors and set them to the labels for display on the form.
		/// </summary>
		/// <param name="errorsList">The list of errors.</param>
		/// <param name="errorsType">The type of error, (cff or taff).</param>
		/// <param name="positionX">The location of the label.</param>
		/// <param name="positionY">The location of the label.</param>
		/// <returns>The location of the bottom of the label for future labels.</returns>
		private int ErrorsLoad(List<string> errorsList, string errorsType, int positionX, int positionY)
        {
			/// Label for the errors.
			Label errorsLabel = new Label { AutoSize = true };

			/// Label for the heading.
			Label headingLabel = new Label { AutoSize = true };

			/// Set the heading label location.
			headingLabel.Location = new Point(positionX, positionY);

			/// Set the errors label location.
			errorsLabel.Location = new Point(positionX, positionY + 30);

			/// Number used to iterate through the errors list.
			int number = 1;

			/// Set the heading label text.
			headingLabel.Text = errorsType + Constants.FileErrorsString;

			/// If the list is empty, there is no errors.
			if (errorsList.Count == 0)
			{
				errorsLabel.Text += "There are no errors in " + errorsType + " file.";
			}
			else
			{
				/// Else loop through the errors and set the text to the label.
				foreach (string line in errorsList)
				{
					errorsLabel.Text += "Error " + number + ": " + line + Constants.NewLineUnicode;
					number++;
				}
			}

			/// Add to the controls.
			this.Controls.Add(headingLabel);
			this.Controls.Add(errorsLabel);

			/// Get the bottom of the errors label for use when setting the next label location.
			int bottomOfLabel = errorsLabel.Bottom;

			return bottomOfLabel;
		}

		/// <summary>
		/// When the button is clicked display the errors information.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void DisplayErrorsButton_Click(object sender, EventArgs e)
        {
			/// Get the bottom of label position.
			int bottomOfLabel;
			int positionX = 10;
			int positionY = 90; 

			/// Load the errors for the taff file.
			bottomOfLabel = ErrorsLoad(taffErrorsList, Constants.TaffString, positionX, positionY);

			/// Add extra space the to bottom label.
			bottomOfLabel = bottomOfLabel + positionX;

			/// Load the errors for the cff file.
			ErrorsLoad(cffErrorsList, Constants.CffString, positionX, bottomOfLabel);
        }
    }
}
