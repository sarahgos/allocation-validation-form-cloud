using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using AllocationsForm;
using System.Diagnostics;

namespace AllocationsFormUnitTests
{
    [TestClass]
    public class AllocationEnergyTests
    {
        [TestMethod]
        public void AllocationEnergyTest1()
        {
            // Arrange.
            Energy energy = new Energy();
            ProcessorSpec processorSpec0 = new ProcessorSpec { Coeff0 = "25", Coeff1 = "-25", Coeff2 = "10", Type = "Intel i5"};
            ProcessorSpec processorSpec1 = new ProcessorSpec { Coeff0 = "25", Coeff1 = "-26", Coeff2 = "9.5", Type = "Intel i9" }; 
            ProcessorSpec processorSpec2 = new ProcessorSpec { Coeff0 = "24", Coeff1 = "-25", Coeff2 = "10", Type = "AMD EPYC" };

            ProcessorSpecList processorSpecList = new ProcessorSpecList();
            Processor processor0 = new Processor { Type = "Intel i5", Frequency = "1.8", RAM = "2" };
            Processor processor1 = new Processor { Type = "AMD EPYC", Frequency = "2.4", RAM = "8" };
            Processor processor2 = new Processor { Type = "Intel i9", Frequency = "3.6", RAM = "16" };

            ProcessorList processList = new ProcessorList();
            double runtimeTask1 = 2.2222222222222223;
            double runtimeTask2 = 2.5;
            double runtimeTask3 = 1.6666666666666667;

            List<double> runtimes = new List<double>();

            runtimes.Add(runtimeTask1);
            runtimes.Add(runtimeTask2);
            runtimes.Add(runtimeTask3);

            processorSpecList.List.Add(processorSpec0);
            processorSpecList.List.Add(processorSpec1);
            processorSpecList.List.Add(processorSpec2);

            processList.List.Add(processor0);
            processList.List.Add(processor1);
            processList.List.Add(processor2);

            double localCommunication = 0.00015;
            double remoteCommunication = 0.5;
            double totalEnergy = 0;
            double expectedEnergy = 172.92;

            // Act
            for (int i = 0; i < processList.List.Count; i++)
            {
                totalEnergy += energy.GetTaskEnergy(runtimes[i], double.Parse(processList.List[i].Frequency), processorSpecList, processList.List[i].Type);
            }
            double allocationEnergy = energy.GetTotalEnergy(localCommunication, remoteCommunication, totalEnergy);
            double actualEnergy = Math.Round(allocationEnergy, 2);

            //Assert
            Assert.AreEqual(expectedEnergy, actualEnergy, "the amount of energy consumed is incorrect");
        }

        [TestMethod]
        public void AllocationEnergyTest2()
        {
            // Arrange.
            Energy energy = new Energy();
            ProcessorSpec processorSpec0 = new ProcessorSpec { Coeff0 = "25", Coeff1 = "-25", Coeff2 = "10", Type = "Intel i5" };
            ProcessorSpec processorSpec1 = new ProcessorSpec { Coeff0 = "25", Coeff1 = "-26", Coeff2 = "9.5", Type = "Intel i9" };
            ProcessorSpec processorSpec2 = new ProcessorSpec { Coeff0 = "24", Coeff1 = "-25", Coeff2 = "10", Type = "AMD EPYC" };

            ProcessorSpecList processorSpecList = new ProcessorSpecList();
            Processor processor0 = new Processor { Type = "Intel i5", Frequency = "1.8", RAM = "2" };
            Processor processor1 = new Processor { Type = "AMD EPYC", Frequency = "2.4", RAM = "8" };
            Processor processor2 = new Processor { Type = "Intel i9", Frequency = "3.6", RAM = "16" };

            ProcessorList processList = new ProcessorList();
            double runtimeTask1 = 11.11111111111111;
            double runtimeTask2 = 4.166666666666667;
            double runtimeTask3 = 8.88888888888889;

            List<double> runtimes = new List<double>();

            runtimes.Add(runtimeTask1);
            runtimes.Add(runtimeTask2);
            runtimes.Add(runtimeTask3);

            processorSpecList.List.Add(processorSpec0);
            processorSpecList.List.Add(processorSpec1);
            processorSpecList.List.Add(processorSpec2);

            processList.List.Add(processor0);
            processList.List.Add(processor1);
            processList.List.Add(processor2);

            double localCommunication = 0.0003;
            double remoteCommunication = 0.92;
            double totalEnergy = 0;
            double expectedEnergy = 713.32;

            // Act
            for (int i = 0; i < processList.List.Count; i++)
            {
                totalEnergy += energy.GetTaskEnergy(runtimes[i], double.Parse(processList.List[i].Frequency), processorSpecList, processList.List[i].Type);
            }
            double allocationEnergy = energy.GetTotalEnergy(localCommunication, remoteCommunication, totalEnergy);
            double actualEnergy = Math.Round(allocationEnergy, 2);

            //Assert
            Assert.AreEqual(expectedEnergy, actualEnergy, "the amount of energy consumed is incorrect");
        }
    }
}
