using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace AllocationsForm
{
    /// <summary>
    /// The Validation class is used to perform validation on the taff and cff input files using regular expressions.
    /// </summary>
    public class Validation
    {
        /// <summary>
        /// To validate white spaces.
        /// </summary>
        Regex whiteSpacesRegex = new Regex("^\\s*$");

        /// <summary>
        /// To validate comments.
        /// </summary>
        Regex commentsRegex = new Regex("^\\s*//.*$");

        /// <summary>
        /// To validate config name. 
        /// </summary>
        Regex configNameRegex = new Regex("[^CONFIG-NAME=[\"].*.cff[\"]$");

        /// <summary>
        /// To validate allocation data.
        /// </summary>
        Regex allocationDataRegex = new Regex("^ALLOCATIONS-DATA=(\\d(,\\d)+)$");

        /// <summary>
        /// To validate allocation id.
        /// </summary>
        Regex allocationIdRegex = new Regex("^ALLOCATION-ID=\\d+$");

        /// <summary>
        /// To validate allocation set.
        /// </summary>
        Regex allocationSetRegex = new Regex("^(0|1)(,0|,1)*$");

        /// <summary>
        /// To validate default logfile.
        /// </summary>
        Regex defaultLogfileRegex = new Regex("^DEFAULT-LOGFILE=[\"].*.txt[\"]$");

        /// <summary>
        /// To validate limits tasks.
        /// </summary>
        Regex limitsTasksRegex = new Regex("^LIMITS-TASKS=\\d+,\\d+$");

        /// <summary>
        /// To validate limits processors.
        /// </summary>
        Regex limitsProcessorsRegex = new Regex("^LIMITS-PROCESSORS=\\d+,\\d+$");

        /// <summary>
        /// To validate limits processor frequency.
        /// </summary>
        Regex limitsProcFreqRegex = new Regex("^LIMITS-PROCESSOR-FREQUENCIES=\\d+[.]\\d+,\\d+[.]\\d+$");

        /// <summary>
        /// To validate limits ram.
        /// </summary>
        Regex limitsRamRegex = new Regex("^LIMITS-RAM=\\d+,\\d+$");

        /// <summary>
        /// To validate program data.
        /// </summary>
        Regex programDataRegex = new Regex("^PROGRAM-DATA=(\\d+[.]\\d+|\\d+),\\d+,\\d+$");

        /// <summary>
        /// To validate reference frequency.
        /// </summary>
        Regex referenceFreqRegex = new Regex("^REFERENCE-FREQUENCY=\\d+[.]\\d+$");

        /// <summary>
        /// To validate task runtime ram.
        /// </summary>
        Regex taskRuntimeRamRegex = new Regex("^TASK-RUNTIME-RAM=((\\d+|,\\d+)[.]?[\\d+]?)*$");

        /// <summary>
        /// To validate processor frequency ram.
        /// </summary>
        Regex processFreqRamRegex = new Regex("^PROCESSORS-FREQUENCIES-RAM=.*\\s.*,\\d+[.]\\d+,\\d+$");

        /// <summary>
        /// To validate processor coefficients.
        /// </summary>
        Regex processCoefficientsRegex = new Regex("^PROCESSORS-COEFFICIENTS=.*\\s.*,\\d+[.]?[\\d+]?,[-]\\d+[.]?[\\d+]?,\\d+[.]?[\\d+]?$");

        /// <summary>
        /// To validate local communication.
        /// </summary>
        Regex localCommunicationRegex = new Regex("^LOCAL-COMMUNICATION$");

        /// <summary>
        /// To validate local communication data.
        /// </summary>
        Regex localCommDataRegex = new Regex("^(0[.]\\d+|0)(,0|,0[.]\\d+|0)*$");

        /// <summary>
        /// To validate remote communication.
        /// </summary>
        Regex remoteCommunicationRegex = new Regex("^REMOTE-COMMUNICATION$");

        /// <summary>
        /// To validate remot communication data.
        /// </summary>
        Regex remoteCommDataRegex = new Regex("^(0[.]\\d+|0)(,0|,0[.]\\d+|0)*$");

        /// <summary>
        /// To store the validity result.
        /// </summary>
        bool validity = true;

        /// <summary>
        /// This function validates taff files by checking each line of the input file and checking it against a regular expression.
        /// If a line does not match any regular expressions, it is recorded as a validation violation.
        /// </summary>
        /// <param name="inputLine">The line of text from file.</param>
        /// <param name="errors">An errors object to add errors to list.</param>
        /// <returns>A boolean referring to whether the file is valid or not.</returns>
        public bool ValidateTAFF(String inputLine, ErrorsForm errors)
        {
            String[] data = inputLine.Replace(Constants.CarriageReturnUnicode, Constants.NewLineUnicode).Split(Constants.NewLineUnicode);

            try
            {
                foreach (String line in data)
                {

                    /// White space.
                    if (whiteSpacesRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Comments
                    else if (commentsRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Config name
                    else if (configNameRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Allocation data
                    else if (allocationDataRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Allocation id.
                    else if (allocationIdRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Allocation set.
                    else if (allocationSetRegex.IsMatch(line))
                    {
                        continue;
                    }
                    else
                    {
                        /// Line contains data not matching any regular expression, record as a violation.
                        errors.TaffErrors.Add(line + Constants.InvalidKeyword);
                        validity = false;
                    }
                }
            }
            catch (Exception ex)
            {
                validity = false;
                Trace.WriteLine(ex.Message);
            }

            return validity;
        }

        /// <summary>
        /// This function validates cff files by checking each line of the input file and checking it against a regular expression.
        /// If a line does not match any regular expressions, it is recorded as a validation violation.
        /// </summary>
        /// <param name="inputLine">The line of text from file.</param>
        /// <param name="errors">An errors object to add errors to list.</param>
        /// <returns>A boolean referring to whether the file is valid or not.</returns>
        public bool ValidateCFF(String inputLine, ErrorsForm errors)
        {
            String[] data = inputLine.Replace(Constants.CarriageReturnUnicode, Constants.NewLineUnicode).Split(Constants.NewLineUnicode);

            try
            {
                foreach (String line in data)
                {

                    /// White spaces.
                    if (whiteSpacesRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Comments.
                    else if (commentsRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Default logfile.
                    else if (defaultLogfileRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Limits tasks.
                    else if (limitsTasksRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Limits processors.
                    else if (limitsProcessorsRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Limits processor frequency.
                    else if (limitsProcFreqRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Limits ram.
                    else if (limitsRamRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Program data.
                    else if (programDataRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Reference frequency.
                    else if (referenceFreqRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Task runtime ram.
                    else if (taskRuntimeRamRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Processor frequency ram.
                    else if (processFreqRamRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Processor Coefficients.
                    else if (processCoefficientsRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Local communication.
                    else if (localCommunicationRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Local communication data.
                    else if (localCommDataRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Remote communication.
                    else if (remoteCommunicationRegex.IsMatch(line))
                    {
                        continue;
                    }

                    /// Remote communication data.
                    else if (remoteCommDataRegex.IsMatch(line))
                    {
                        continue;
                    }
                    else
                        /// Line contains data not matching any regular expression, record as a violation.
                        errors.CffErrors.Add(line + Constants.InvalidKeyword);
                        validity = false;
                }
            }
            catch (Exception ex)
            {
                validity = false;
                Trace.WriteLine(ex.Message);
            }

            return validity;
        }
    }
}
