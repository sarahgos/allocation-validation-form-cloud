using System;
using System.Collections.Generic;
using System.Text;

namespace AllocationsForm
{
    /// <summary>
    /// Class to store the processor specs.
    /// </summary>
    public class ProcessorSpec
    {
        /// <summary>
        /// Store the coefficient string from file.
        /// </summary>
        string coeff0;

        /// <summary>
        /// Store the coefficient string from file.
        /// </summary>
        string coeff1;

        /// <summary>
        /// Store the coefficient string from file.
        /// </summary>
        string coeff2;

        /// <summary>
        /// Store the processor type from file.
        /// </summary>
        string type;

        /// <summary>
        /// Default constructor.
        /// </summary>
        public ProcessorSpec() { }

        /// <summary>
        /// Overloaded constructor.
        /// </summary>
        /// <param name="coefficient2">Coefficient 0</param>
        /// <param name="coefficient1">Coefficient 1</param>
        /// <param name="coefficient0">Coefficient 2</param>
        public ProcessorSpec(double coefficient2, double coefficient1, double coefficient0)
        {
            C2 = coefficient2;
            C1 = coefficient1;
            C0 = coefficient0;
        }

        /// <summary>
        /// Property to get and set the coefficient double.
        /// </summary>
        public double C0 { get; set; }

        /// <summary>
        /// Property to get and set the coefficient double.
        /// </summary>
        public double C1 { get; set; }

        /// <summary>
        /// Property to get and set the coefficient double.
        /// </summary>
        public double C2 { get; set; }

        /// <summary>
        /// Property to get and set the coefficient string.
        /// </summary>
        public string Coeff0 { get => coeff0; set => coeff0 = value; }

        /// <summary>
        /// Property to get and set the coefficient string.
        /// </summary>
        public string Coeff1 { get => coeff1; set => coeff1 = value; }

        /// <summary>
        /// Property to get and set the coefficient string.
        /// </summary>
        public string Coeff2 { get => coeff2; set => coeff2 = value; }

        /// <summary>
        /// Property to get and set the coefficient type.
        /// </summary>
        public string Type { get => type; set => type = value; }

        /// <summary>
        /// To compute the energy per second of a task.
        /// </summary>
        /// <param name="frequency">The task frequency.</param>
        /// <returns>The energy consumed per second by a task.</returns>
        public double EnergyPerSecond(double frequency)
        {
            return (C2 * frequency * frequency + C1 * frequency + C0);
        }

        /// <summary>
        /// Computes the energy consumed by a task.
        /// </summary>
        /// <param name="frequency">Task frequency.</param>
        /// <param name="runtime">Task runtime.</param>
        /// <returns>The energy consumed by a task.</returns>
        public double Energy(double frequency, double runtime)
        {
            return (EnergyPerSecond(frequency) * runtime);
        }



    }
}
