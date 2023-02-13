using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using AllocationsForm;

namespace AllocationsFormUnitTests
{
    [TestClass]
    public class TaskEnergyTestSingle
    {
        const double Accuracy = 0.0001;

        [TestMethod]
        public void SingleTaskEnergyTest1()
        {
            // Arrange.
            double coefficient2 = 10.0;
            double coefficient1 = -25.0;
            double coefficient0 = 25.0;
            double frequency = 1.0;
            double runtime = 2.0;
            double expectedEnergy = 20.0;
            

            // Act.
            ProcessorSpec processorType = new ProcessorSpec(coefficient2, coefficient1, coefficient0);
            double actualEnergy = processorType.Energy(frequency, runtime);

            // Assert.
            Assert.AreEqual(expectedEnergy, actualEnergy, Accuracy, "the amount of energy consumed is incorrect");
        }

        [TestMethod]
        public void SingleTaskEnergyTest2()
        {
            // Arrange.
            double coefficient2 = 9.5;
            double coefficient1 = -26.0;
            double coefficient0 = 24;
            double frequency = 2.0;
            double runtime = 3.0;
            double expectedEnergy = 30.0;

            // Act.
            ProcessorSpec processorType = new ProcessorSpec(coefficient2, coefficient1, coefficient0);
            double actualEnergy = processorType.Energy(frequency, runtime);

            // Assert.
            Assert.AreEqual(expectedEnergy, actualEnergy, Accuracy, "the amount of energy consumed is incorrect");
        }

        [TestMethod]
        public void SingleTaskEnergyTest3()
        {
            // Arrange.
            double c2 = 10.0;
            double c1 = -25.0;
            double c0 = 25.0;
            double frequency = 1.0;
            double runtime = 5.0;
            double expectedEnergy = 50.0;

            // Act.
            ProcessorSpec processorType = new ProcessorSpec(c2, c1, c0);
            double actualEnergy = processorType.Energy(frequency, runtime);

            // Assert.
            Assert.AreEqual(expectedEnergy, actualEnergy, Accuracy, "the amount of energy consumed is incorrect");
        }
    }
}
