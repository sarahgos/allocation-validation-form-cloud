using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using AllocationsForm;
using System.Diagnostics;

namespace AllocationsFormUnitTests
{
    [TestClass]
    public class LocalCommunicationsTests
    {
      //  const double Accuracy = 0.0001;

        [TestMethod]
        public void LocalCommunicationsTest1()
        {
            // Arrange.
            List<string> LocalCommunicationsTask0 = new List<string> { "0", "0.0001", "0.0001", "0.0001", "0.0001" };
            List<string> LocalCommunicationsTask1 = new List<string> { "0", "0", "0.00005", "0", "0" };
            List<string> LocalCommunicationsTask2 = new List<string> { "0", "0", "0", "0.00005", "0" };
            List<string> LocalCommunicationsTask3 = new List<string> { "0", "0", "0", "0", "0.00005" };
            List<string> LocalCommunicationsTask4 = new List<string> { "0.0001", "0", "0", "0", "0" };

            TaskProcessor task0Processor = new TaskProcessor { Id = 0, ProcessorId = 0 };
            TaskProcessor task1Processor = new TaskProcessor { Id = 1, ProcessorId = 0 };
            TaskProcessor task2Processor = new TaskProcessor { Id = 2, ProcessorId = 1 };
            TaskProcessor task3Processor = new TaskProcessor { Id = 3, ProcessorId = 1 };
            TaskProcessor task4Processor = new TaskProcessor { Id = 4, ProcessorId = 2 };

            TaskProcessorList taskProcessorList = new TaskProcessorList();

            taskProcessorList.AddTask(task0Processor);
            taskProcessorList.AddTask(task1Processor);
            taskProcessorList.AddTask(task2Processor);
            taskProcessorList.AddTask(task3Processor);
            taskProcessorList.AddTask(task4Processor);

            Task task0 = new Task { Id = 0, ProcessorID = 0, LocalCommunications = LocalCommunicationsTask0 };
            Task task1 = new Task { Id = 1, ProcessorID = 0, LocalCommunications = LocalCommunicationsTask1 };
            Task task2 = new Task { Id = 2, ProcessorID = 1, LocalCommunications = LocalCommunicationsTask2 };
            Task task3 = new Task { Id = 3, ProcessorID = 1, LocalCommunications = LocalCommunicationsTask3 };
            Task task4 = new Task { Id = 4, ProcessorID = 2, LocalCommunications = LocalCommunicationsTask4 };

            TaskList tasks = new TaskList();

            tasks.AddTask(task0);
            tasks.AddTask(task1);
            tasks.AddTask(task2);
            tasks.AddTask(task3);
            tasks.AddTask(task4);

            double expectedLocalComm = 0.0001;

            // Act.
            Energy energy = new Energy();
            energy.LocalCommunicationEnergy(tasks, taskProcessorList);
            double actualLocalComm = taskProcessorList.List[0].LocalCommunicationEnergy;

            // Assert.
            Assert.AreEqual(expectedLocalComm, actualLocalComm, "the amount of local communications energy is incorrect");
        }

        [TestMethod]
        public void LocalCommunicationsTest2()
        {
            // Arrange.
            List<string> LocalCommunicationsTask0 = new List<string> { "0", "0.0001", "0.0001", "0.0001", "0.0001" };
            List<string> LocalCommunicationsTask1 = new List<string> { "0", "0", "0.00005", "0", "0" };
            List<string> LocalCommunicationsTask2 = new List<string> { "0", "0", "0", "0.00005", "0" };
            List<string> LocalCommunicationsTask3 = new List<string> { "0", "0", "0", "0", "0.00005" };
            List<string> LocalCommunicationsTask4 = new List<string> { "0.0001", "0", "0", "0", "0" };

            TaskProcessor task0Processor = new TaskProcessor { Id = 0, ProcessorId = 0 };
            TaskProcessor task1Processor = new TaskProcessor { Id = 1, ProcessorId = 0 };
            TaskProcessor task2Processor = new TaskProcessor { Id = 2, ProcessorId = 1 };
            TaskProcessor task3Processor = new TaskProcessor { Id = 3, ProcessorId = 1 };
            TaskProcessor task4Processor = new TaskProcessor { Id = 4, ProcessorId = 2 };

            TaskProcessorList taskProcessorList = new TaskProcessorList();

            taskProcessorList.AddTask(task0Processor);
            taskProcessorList.AddTask(task1Processor);
            taskProcessorList.AddTask(task2Processor);
            taskProcessorList.AddTask(task3Processor);
            taskProcessorList.AddTask(task4Processor);

            Task task0 = new Task { Id = 0, ProcessorID = 0, LocalCommunications = LocalCommunicationsTask0 };
            Task task1 = new Task { Id = 1, ProcessorID = 0, LocalCommunications = LocalCommunicationsTask1 };
            Task task2 = new Task { Id = 2, ProcessorID = 1, LocalCommunications = LocalCommunicationsTask2 };
            Task task3 = new Task { Id = 3, ProcessorID = 1, LocalCommunications = LocalCommunicationsTask3 };
            Task task4 = new Task { Id = 4, ProcessorID = 2, LocalCommunications = LocalCommunicationsTask4 };

            TaskList tasks = new TaskList();

            tasks.AddTask(task0);
            tasks.AddTask(task1);
            tasks.AddTask(task2);
            tasks.AddTask(task3);
            tasks.AddTask(task4);

            double expectedLocalComm = 0;

            // Act.
            Energy energy = new Energy();
            energy.LocalCommunicationEnergy(tasks, taskProcessorList);
            double actualLocalComm = taskProcessorList.List[1].LocalCommunicationEnergy;

            // Assert.
            Assert.AreEqual(expectedLocalComm, actualLocalComm,"the amount of local communications energy is incorrect");
        }

        [TestMethod]
        public void LocalCommunicationsTest3()
        {
            // Arrange.
            List<string> LocalCommunicationsTask0 = new List<string> { "0", "0.0001", "0.0001", "0.0001", "0.0001" };
            List<string> LocalCommunicationsTask1 = new List<string> { "0", "0", "0.00005", "0", "0" };
            List<string> LocalCommunicationsTask2 = new List<string> { "0", "0", "0", "0.00005", "0" };
            List<string> LocalCommunicationsTask3 = new List<string> { "0", "0", "0", "0", "0.00005" };
            List<string> LocalCommunicationsTask4 = new List<string> { "0.0001", "0", "0", "0", "0" };

            TaskProcessor task0Processor = new TaskProcessor { Id = 0, ProcessorId = 0 };
            TaskProcessor task1Processor = new TaskProcessor { Id = 1, ProcessorId = 0 };
            TaskProcessor task2Processor = new TaskProcessor { Id = 2, ProcessorId = 1 };
            TaskProcessor task3Processor = new TaskProcessor { Id = 3, ProcessorId = 1 };
            TaskProcessor task4Processor = new TaskProcessor { Id = 4, ProcessorId = 2 };

            TaskProcessorList taskProcessorList = new TaskProcessorList();

            taskProcessorList.AddTask(task0Processor);
            taskProcessorList.AddTask(task1Processor);
            taskProcessorList.AddTask(task2Processor);
            taskProcessorList.AddTask(task3Processor);
            taskProcessorList.AddTask(task4Processor);

            Task task0 = new Task { Id = 0, ProcessorID = 0, LocalCommunications = LocalCommunicationsTask0 };
            Task task1 = new Task { Id = 1, ProcessorID = 0, LocalCommunications = LocalCommunicationsTask1 };
            Task task2 = new Task { Id = 2, ProcessorID = 1, LocalCommunications = LocalCommunicationsTask2 };
            Task task3 = new Task { Id = 3, ProcessorID = 1, LocalCommunications = LocalCommunicationsTask3 };
            Task task4 = new Task { Id = 4, ProcessorID = 2, LocalCommunications = LocalCommunicationsTask4 };

            TaskList tasks = new TaskList();

            tasks.AddTask(task0);
            tasks.AddTask(task1);
            tasks.AddTask(task2);
            tasks.AddTask(task3);
            tasks.AddTask(task4);

            double expectedLocalComm = 0.00005;

            // Act.
            Energy energy = new Energy();
            energy.LocalCommunicationEnergy(tasks, taskProcessorList);
            double actualLocalComm = taskProcessorList.List[2].LocalCommunicationEnergy;

            // Assert.
            Assert.AreEqual(expectedLocalComm, actualLocalComm, "the amount of local communications energy is incorrect");
        }

        [TestMethod]
        public void LocalCommunicationsTest4()
        {
            // Arrange.
            List<string> LocalCommunicationsTask0 = new List<string> { "0", "0.0001", "0.0001", "0", "0" };
            List<string> LocalCommunicationsTask1 = new List<string> { "0", "0", "0", "0.0002", "0" };
            List<string> LocalCommunicationsTask2 = new List<string> { "0", "0", "0", "0", "0.0003" };
            List<string> LocalCommunicationsTask3 = new List<string> { "0.0001", "0", "0", "0", "0" };
            List<string> LocalCommunicationsTask4 = new List<string> { "0.0001", "0", "0", "0", "0" };

            TaskProcessor task0Processor = new TaskProcessor { Id = 0, ProcessorId = 1 };
            TaskProcessor task1Processor = new TaskProcessor { Id = 1, ProcessorId = 0 };
            TaskProcessor task2Processor = new TaskProcessor { Id = 2, ProcessorId = 1 };
            TaskProcessor task3Processor = new TaskProcessor { Id = 3, ProcessorId = 0 };
            TaskProcessor task4Processor = new TaskProcessor { Id = 4, ProcessorId = 2 };

            TaskProcessorList taskProcessorList = new TaskProcessorList();

            taskProcessorList.AddTask(task0Processor);
            taskProcessorList.AddTask(task1Processor);
            taskProcessorList.AddTask(task2Processor);
            taskProcessorList.AddTask(task3Processor);
            taskProcessorList.AddTask(task4Processor);

            Task task0 = new Task { Id = 0, ProcessorID = 1, LocalCommunications = LocalCommunicationsTask0 };
            Task task1 = new Task { Id = 1, ProcessorID = 0, LocalCommunications = LocalCommunicationsTask1 };
            Task task2 = new Task { Id = 2, ProcessorID = 1, LocalCommunications = LocalCommunicationsTask2 };
            Task task3 = new Task { Id = 3, ProcessorID = 0, LocalCommunications = LocalCommunicationsTask3 };
            Task task4 = new Task { Id = 4, ProcessorID = 2, LocalCommunications = LocalCommunicationsTask4 };

            TaskList tasks = new TaskList();

            tasks.AddTask(task0);
            tasks.AddTask(task1);
            tasks.AddTask(task2);
            tasks.AddTask(task3);
            tasks.AddTask(task4);

            double expectedLocalComm = 0.0001;

            // Act.
            Energy energy = new Energy();
            energy.LocalCommunicationEnergy(tasks, taskProcessorList);
            double actualLocalComm = taskProcessorList.List[0].LocalCommunicationEnergy;

            // Assert.
            Assert.AreEqual(expectedLocalComm, actualLocalComm, "the amount of local communications energy is incorrect");
        }

        [TestMethod]
        public void LocalCommunicationsTest5()
        {
            // Arrange.
            List<string> LocalCommunicationsTask0 = new List<string> { "0", "0.0001", "0.0001", "0", "0" };
            List<string> LocalCommunicationsTask1 = new List<string> { "0", "0", "0", "0.0002", "0" };
            List<string> LocalCommunicationsTask2 = new List<string> { "0", "0", "0", "0", "0.0003" };
            List<string> LocalCommunicationsTask3 = new List<string> { "0.0001", "0", "0", "0", "0" };
            List<string> LocalCommunicationsTask4 = new List<string> { "0.0001", "0", "0", "0", "0" };

            TaskProcessor task0Processor = new TaskProcessor { Id = 0, ProcessorId = 1 };
            TaskProcessor task1Processor = new TaskProcessor { Id = 1, ProcessorId = 0 };
            TaskProcessor task2Processor = new TaskProcessor { Id = 2, ProcessorId = 1 };
            TaskProcessor task3Processor = new TaskProcessor { Id = 3, ProcessorId = 0 };
            TaskProcessor task4Processor = new TaskProcessor { Id = 4, ProcessorId = 2 };

            TaskProcessorList taskProcessorList = new TaskProcessorList();

            taskProcessorList.AddTask(task0Processor);
            taskProcessorList.AddTask(task1Processor);
            taskProcessorList.AddTask(task2Processor);
            taskProcessorList.AddTask(task3Processor);
            taskProcessorList.AddTask(task4Processor);

            Task task0 = new Task { Id = 0, ProcessorID = 1, LocalCommunications = LocalCommunicationsTask0 };
            Task task1 = new Task { Id = 1, ProcessorID = 0, LocalCommunications = LocalCommunicationsTask1 };
            Task task2 = new Task { Id = 2, ProcessorID = 1, LocalCommunications = LocalCommunicationsTask2 };
            Task task3 = new Task { Id = 3, ProcessorID = 0, LocalCommunications = LocalCommunicationsTask3 };
            Task task4 = new Task { Id = 4, ProcessorID = 2, LocalCommunications = LocalCommunicationsTask4 };

            TaskList tasks = new TaskList();

            tasks.AddTask(task0);
            tasks.AddTask(task1);
            tasks.AddTask(task2);
            tasks.AddTask(task3);
            tasks.AddTask(task4);

            double expectedLocalComm = 0.0002;

            // Act.
            Energy energy = new Energy();
            energy.LocalCommunicationEnergy(tasks, taskProcessorList);
            double actualLocalComm = taskProcessorList.List[1].LocalCommunicationEnergy;

            // Assert.
            Assert.AreEqual(expectedLocalComm, actualLocalComm, "the amount of local communications energy is incorrect");
        }

        [TestMethod]
        public void LocalCommunicationsTest6()
        {
            // Arrange.
            List<string> LocalCommunicationsTask0 = new List<string> { "0", "0", "0.0001", "0.0001", "0" };
            List<string> LocalCommunicationsTask1 = new List<string> { "0", "0", "0", "0.0002", "0" };
            List<string> LocalCommunicationsTask2 = new List<string> { "0", "0", "0", "0", "0.0003" };
            List<string> LocalCommunicationsTask3 = new List<string> { "0.0001", "0", "0", "0", "0" };
            List<string> LocalCommunicationsTask4 = new List<string> { "0.0001", "0", "0", "0", "0" };

            TaskProcessor task0Processor = new TaskProcessor { Id = 0, ProcessorId = 1 };
            TaskProcessor task1Processor = new TaskProcessor { Id = 1, ProcessorId = 0 };
            TaskProcessor task2Processor = new TaskProcessor { Id = 2, ProcessorId = 2 };
            TaskProcessor task3Processor = new TaskProcessor { Id = 3, ProcessorId = 0 };
            TaskProcessor task4Processor = new TaskProcessor { Id = 4, ProcessorId = 0 };

            TaskProcessorList taskProcessorList = new TaskProcessorList();

            taskProcessorList.AddTask(task0Processor);
            taskProcessorList.AddTask(task1Processor);
            taskProcessorList.AddTask(task2Processor);
            taskProcessorList.AddTask(task3Processor);
            taskProcessorList.AddTask(task4Processor);

            Task task0 = new Task { Id = 0, ProcessorID = 1, LocalCommunications = LocalCommunicationsTask0 };
            Task task1 = new Task { Id = 1, ProcessorID = 0, LocalCommunications = LocalCommunicationsTask1 };
            Task task2 = new Task { Id = 2, ProcessorID = 2, LocalCommunications = LocalCommunicationsTask2 };
            Task task3 = new Task { Id = 3, ProcessorID = 0, LocalCommunications = LocalCommunicationsTask3 };
            Task task4 = new Task { Id = 4, ProcessorID = 0, LocalCommunications = LocalCommunicationsTask4 };

            TaskList tasks = new TaskList();

            tasks.AddTask(task0);
            tasks.AddTask(task1);
            tasks.AddTask(task2);
            tasks.AddTask(task3);
            tasks.AddTask(task4);

            double expectedLocalComm = 0.0002;

            // Act.
            Energy energy = new Energy();
            energy.LocalCommunicationEnergy(tasks, taskProcessorList);
            double actualLocalComm = taskProcessorList.List[1].LocalCommunicationEnergy;

            // Assert.
            Assert.AreEqual(expectedLocalComm, actualLocalComm, "the amount of local communications energy is incorrect");
        }
    }
}
