using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using AllocationsForm;
using System.Diagnostics;

namespace AllocationsFormUnitTests
{
    [TestClass]
    public class RemoteCommunicationsTests
    {
        const double Accuracy = 0.000000001;

        [TestMethod]
        public void RemoteCommunicationsTest1()
        {
            // Arrange.
            List<string> RemoteCommunicationsTask0 = new List<string> { "0", "0.1", "0.1", "0.1", "0.1" };
            List<string> RemoteCommunicationsTask1 = new List<string> { "0", "0", "0.05", "0", "0" };
            List<string> RemoteCommunicationsTask2 = new List<string> { "0", "0", "0", "0.05", "0" };
            List<string> RemoteCommunicationsTask3 = new List<string> { "0", "0", "0", "0", "0.05" };
            List<string> RemoteCommunicationsTask4 = new List<string> { "0.1", "0", "0", "0", "0" };

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

            Task task0 = new Task { Id = 0, ProcessorID = 0, RemoteCommunications = RemoteCommunicationsTask0 };
            Task task1 = new Task { Id = 1, ProcessorID = 0, RemoteCommunications = RemoteCommunicationsTask1 };
            Task task2 = new Task { Id = 2, ProcessorID = 1, RemoteCommunications = RemoteCommunicationsTask2 };
            Task task3 = new Task { Id = 3, ProcessorID = 1, RemoteCommunications = RemoteCommunicationsTask3 };
            Task task4 = new Task { Id = 4, ProcessorID = 2, RemoteCommunications = RemoteCommunicationsTask4 };

            TaskList tasks = new TaskList();

            tasks.AddTask(task0);
            tasks.AddTask(task1);
            tasks.AddTask(task2);
            tasks.AddTask(task3);
            tasks.AddTask(task4);

            double expectedRemoteComm = 0.3;

            // Act.
            Energy energy = new Energy();
            energy.RemoteCommunicationEnergy(tasks, taskProcessorList);
            double actualRemoteComm = taskProcessorList.List[0].RemoteCommunicationEnergy;

            Trace.WriteLine("ActualLocalComm: " + actualRemoteComm);

            // Assert.
            Assert.AreEqual(expectedRemoteComm, actualRemoteComm, Accuracy, "the amount of remote communications energy is incorrect");
        }

        [TestMethod]
        public void RemoteCommunicationsTest2()
        {
            // Arrange.
            List<string> RemoteCommunicationsTask0 = new List<string> { "0", "0.1", "0.1", "0.1", "0.1" };
            List<string> RemoteCommunicationsTask1 = new List<string> { "0", "0", "0.05", "0", "0" };
            List<string> RemoteCommunicationsTask2 = new List<string> { "0", "0", "0", "0.05", "0" };
            List<string> RemoteCommunicationsTask3 = new List<string> { "0", "0", "0", "0", "0.05" };
            List<string> RemoteCommunicationsTask4 = new List<string> { "0.1", "0", "0", "0", "0" };

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

            Task task0 = new Task { Id = 0, ProcessorID = 0, RemoteCommunications = RemoteCommunicationsTask0 };
            Task task1 = new Task { Id = 1, ProcessorID = 0, RemoteCommunications = RemoteCommunicationsTask1 };
            Task task2 = new Task { Id = 2, ProcessorID = 1, RemoteCommunications = RemoteCommunicationsTask2 };
            Task task3 = new Task { Id = 3, ProcessorID = 1, RemoteCommunications = RemoteCommunicationsTask3 };
            Task task4 = new Task { Id = 4, ProcessorID = 2, RemoteCommunications = RemoteCommunicationsTask4 };

            TaskList tasks = new TaskList();

            tasks.AddTask(task0);
            tasks.AddTask(task1);
            tasks.AddTask(task2);
            tasks.AddTask(task3);
            tasks.AddTask(task4);

            double expectedRemoteComm = 0.05;

            // Act.
            Energy energy = new Energy();
            energy.RemoteCommunicationEnergy(tasks, taskProcessorList);
            double actualRemoteComm = taskProcessorList.List[1].RemoteCommunicationEnergy;

            Trace.WriteLine("ActualLocalComm: " + actualRemoteComm);

            // Assert.
            Assert.AreEqual(expectedRemoteComm, actualRemoteComm, Accuracy, "the amount of remote communications energy is incorrect");
        }

        [TestMethod]
        public void RemoteCommunicationsTest3()
        {
            // Arrange.
            List<string> RemoteCommunicationsTask0 = new List<string> { "0", "0.1", "0.1", "0.1", "0.1" };
            List<string> RemoteCommunicationsTask1 = new List<string> { "0", "0", "0.05", "0", "0" };
            List<string> RemoteCommunicationsTask2 = new List<string> { "0", "0", "0", "0.05", "0" };
            List<string> RemoteCommunicationsTask3 = new List<string> { "0", "0", "0", "0", "0.05" };
            List<string> RemoteCommunicationsTask4 = new List<string> { "0.1", "0", "0", "0", "0" };

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

            Task task0 = new Task { Id = 0, ProcessorID = 0, RemoteCommunications = RemoteCommunicationsTask0 };
            Task task1 = new Task { Id = 1, ProcessorID = 0, RemoteCommunications = RemoteCommunicationsTask1 };
            Task task2 = new Task { Id = 2, ProcessorID = 1, RemoteCommunications = RemoteCommunicationsTask2 };
            Task task3 = new Task { Id = 3, ProcessorID = 1, RemoteCommunications = RemoteCommunicationsTask3 };
            Task task4 = new Task { Id = 4, ProcessorID = 2, RemoteCommunications = RemoteCommunicationsTask4 };

            TaskList tasks = new TaskList();

            tasks.AddTask(task0);
            tasks.AddTask(task1);
            tasks.AddTask(task2);
            tasks.AddTask(task3);
            tasks.AddTask(task4);

            double expectedRemoteComm = 0;

            // Act.
            Energy energy = new Energy();
            energy.RemoteCommunicationEnergy(tasks, taskProcessorList);
            double actualRemoteComm = taskProcessorList.List[2].RemoteCommunicationEnergy;

            Trace.WriteLine("ActualLocalComm: " + actualRemoteComm);

            // Assert.
            Assert.AreEqual(expectedRemoteComm, actualRemoteComm, Accuracy, "the amount of remote communications energy is incorrect");
        }

        [TestMethod]
        public void RemoteCommunicationsTest4()
        {
            // Arrange.
            List<string> RemoteCommunicationsTask0 = new List<string> { "0", "0.1", "0.1", "0.1", "0.1" };
            List<string> RemoteCommunicationsTask1 = new List<string> { "0", "0", "0.05", "0", "0" };
            List<string> RemoteCommunicationsTask2 = new List<string> { "0", "0", "0", "0.05", "0" };
            List<string> RemoteCommunicationsTask3 = new List<string> { "0", "0", "0", "0", "0.05" };
            List<string> RemoteCommunicationsTask4 = new List<string> { "0.1", "0", "0", "0", "0" };

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

            Task task0 = new Task { Id = 0, ProcessorID = 0, RemoteCommunications = RemoteCommunicationsTask0 };
            Task task1 = new Task { Id = 1, ProcessorID = 0, RemoteCommunications = RemoteCommunicationsTask1 };
            Task task2 = new Task { Id = 2, ProcessorID = 1, RemoteCommunications = RemoteCommunicationsTask2 };
            Task task3 = new Task { Id = 3, ProcessorID = 1, RemoteCommunications = RemoteCommunicationsTask3 };
            Task task4 = new Task { Id = 4, ProcessorID = 2, RemoteCommunications = RemoteCommunicationsTask4 };

            TaskList tasks = new TaskList();

            tasks.AddTask(task0);
            tasks.AddTask(task1);
            tasks.AddTask(task2);
            tasks.AddTask(task3);
            tasks.AddTask(task4);

            double expectedRemoteComm = 0.05;

            // Act.
            Energy energy = new Energy();
            energy.RemoteCommunicationEnergy(tasks, taskProcessorList);
            double actualRemoteComm = taskProcessorList.List[3].RemoteCommunicationEnergy;

            Trace.WriteLine("ActualLocalComm: " + actualRemoteComm);

            // Assert.
            Assert.AreEqual(expectedRemoteComm, actualRemoteComm, Accuracy, "the amount of remote communications energy is incorrect");
        }

        [TestMethod]
        public void RemoteCommunicationsTest5()
        {
            // Arrange.
            List<string> RemoteCommunicationsTask0 = new List<string> { "0", "0.1", "0.1", "0.1", "0.1" };
            List<string> RemoteCommunicationsTask1 = new List<string> { "0", "0", "0.05", "0", "0" };
            List<string> RemoteCommunicationsTask2 = new List<string> { "0", "0", "0", "0.05", "0" };
            List<string> RemoteCommunicationsTask3 = new List<string> { "0", "0", "0", "0", "0.05" };
            List<string> RemoteCommunicationsTask4 = new List<string> { "0.1", "0", "0", "0", "0" };

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

            Task task0 = new Task { Id = 0, ProcessorID = 0, RemoteCommunications = RemoteCommunicationsTask0 };
            Task task1 = new Task { Id = 1, ProcessorID = 0, RemoteCommunications = RemoteCommunicationsTask1 };
            Task task2 = new Task { Id = 2, ProcessorID = 1, RemoteCommunications = RemoteCommunicationsTask2 };
            Task task3 = new Task { Id = 3, ProcessorID = 1, RemoteCommunications = RemoteCommunicationsTask3 };
            Task task4 = new Task { Id = 4, ProcessorID = 2, RemoteCommunications = RemoteCommunicationsTask4 };

            TaskList tasks = new TaskList();

            tasks.AddTask(task0);
            tasks.AddTask(task1);
            tasks.AddTask(task2);
            tasks.AddTask(task3);
            tasks.AddTask(task4);

            double expectedRemoteComm = 0.1;

            // Act.
            Energy energy = new Energy();
            energy.RemoteCommunicationEnergy(tasks, taskProcessorList);
            double actualRemoteComm = taskProcessorList.List[4].RemoteCommunicationEnergy;

            Trace.WriteLine("ActualLocalComm: " + actualRemoteComm);

            // Assert.
            Assert.AreEqual(expectedRemoteComm, actualRemoteComm, Accuracy, "the amount of remote communications energy is incorrect");
        }
    }
}
