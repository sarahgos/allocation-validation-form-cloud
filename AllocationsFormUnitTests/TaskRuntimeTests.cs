using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using AllocationsForm;
using System.Diagnostics;

namespace AllocationsFormUnitTests
{
    [TestClass]
    public class TaskRuntimeTests
    {
        const double Accuracy = 0.0001;

        [TestMethod]
        public void TaskRuntimeTest1()
        {
            // Arrange.
            Runtime runtime = new Runtime();
            Task task = new Task { Id = 0, Runtime = "1.0" };
            Processor processor = new Processor { Type = "Intel i5", Frequency = "1.8", RAM = "2" };
            ReferenceFrequency refFreq = new ReferenceFrequency { RefFreq = "2.0" };

            double expectedRuntime = 1.11111111111;

            // Act.
            double actualRuntime = runtime.GetTaskRuntime(double.Parse(task.Runtime), double.Parse(refFreq.RefFreq), double.Parse(processor.Frequency));

            Trace.WriteLine("ActualRuntime: " + actualRuntime);

            // Assert.
            Assert.AreEqual(expectedRuntime, actualRuntime, Accuracy, "the amount of runtime is incorrect");
        }

        [TestMethod]
        public void TaskRuntimeTest2()
        {
            // Arrange.
            Runtime runtime = new Runtime();
            Task task = new Task { Id = 0, Runtime = "2.0" };
            Processor processor = new Processor { Type = "Intel i5", Frequency = "2.4", RAM = "8" };
            ReferenceFrequency refFreq = new ReferenceFrequency { RefFreq = "2.0" };

            double expectedRuntime = 1.66666666667;

            // Act.
            double actualRuntime = runtime.GetTaskRuntime(double.Parse(task.Runtime), double.Parse(refFreq.RefFreq), double.Parse(processor.Frequency));

            Trace.WriteLine("ActualRuntime: " + actualRuntime);

            // Assert.
            Assert.AreEqual(expectedRuntime, actualRuntime, Accuracy, "the amount of runtime is incorrect");
        }
    }
}