using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using AllocationsForm;
using System.Diagnostics;

namespace AllocationsFormUnitTests
{
    [TestClass]
    public class TaskEnergyTestTotal
    {
        const double Accuracy = 0.0001;

        [TestMethod]
        public void TotalTaskEnergyTest1()
        {
            // Arrange.
            double coefficient2 = 10.0;
            double coefficient1 = -25.0;
            double coefficient0 = 25.0;
            double frequency = 1.0;
            double runtime = 2.0;
            double localCommunication = 0.0001;
            double remoteCommunication = 0.3;
            double expectedEnergy = 20.3001;

            // Act.
            ProcessorSpec processorType = new ProcessorSpec(coefficient2, coefficient1, coefficient0);
            double taskEnergy = processorType.Energy(frequency, runtime);

            Energy energy = new Energy();
            double actualEnergy = energy.GetTotalEnergy(taskEnergy, localCommunication, remoteCommunication);

            // Assert.
            Assert.AreEqual(expectedEnergy, actualEnergy, Accuracy, "the amount of energy consumed is incorrect");
        }

        [TestMethod]
        public void TotalTaskEnergyTest2()
        {
            // Arrange.
            double coefficient2 = 9.5;
            double coefficient1 = -26.0;
            double coefficient0 = 24;
            double frequency = 2.0;
            double runtime = 3.0;
            double localCommunication = 0.0003;
            double remoteCommunication = 0.2;
            double expectedEnergy = 30.2003;

            // Act.
            ProcessorSpec processorType = new ProcessorSpec(coefficient2, coefficient1, coefficient0);
            double taskEnergy = processorType.Energy(frequency, runtime);

            Energy energy = new Energy();
            double actualEnergy = energy.GetTotalEnergy(taskEnergy, localCommunication, remoteCommunication);

            // Assert.
            Assert.AreEqual(expectedEnergy, actualEnergy, Accuracy, "the amount of energy consumed is incorrect");
        }

        [TestMethod]
        public void TotalTaskEnergyTest3()
        {
            // Arrange.
            double coefficient2 = 10.0;
            double coefficient1 = -25.0;
            double coefficient0 = 25.0;
            double frequency = 1.0;
            double runtime = 5.0;
            double localCommunication = 0.0011;
            double remoteCommunication = 0.0;
            double expectedEnergy = 50.0011;

            // Act.
            ProcessorSpec processorType = new ProcessorSpec(coefficient2, coefficient1, coefficient0);
            double taskEnergy = processorType.Energy(frequency, runtime);

            Energy energy = new Energy();
            double actualEnergy = energy.GetTotalEnergy(taskEnergy, localCommunication, remoteCommunication);

            // Assert.
            Assert.AreEqual(expectedEnergy, actualEnergy, Accuracy, "the amount of energy consumed is incorrect");
        }
    }
}
