using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AllocationsForm;

namespace AllocationsFormUnitTests
{
    [TestClass]
    public class RamTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // Arrange.
            Ram ram = new Ram();
            Task task = new Task { Id = 0, ProcessorID = 0, RAM = "2" };
            Processor processor = new Processor { Type = "Intel i5", Frequency = "2.4", RAM = "8" };

            bool expectedRam = true;

            // Act.
            bool actualRam = ram.CheckRam(double.Parse(task.RAM), double.Parse(processor.RAM));

            Console.WriteLine(actualRam);

            // Assert.
            Assert.AreEqual(expectedRam, actualRam, "the amount of ram is incorrect");
        }

        [TestMethod]
        public void TestMethod2()
        {
            // Arrange.
            Ram ram = new Ram();
            Task task = new Task { Id = 0, ProcessorID = 0, RAM = "9" };
            Processor processor = new Processor { Type = "Intel i5", Frequency = "2.4", RAM = "8" };

            bool expectedRam = false;

            // Act.

            bool actualRam = ram.CheckRam(double.Parse(task.RAM), double.Parse(processor.RAM));

            Console.WriteLine(actualRam);

            // Assert.
            Assert.AreEqual(expectedRam, actualRam, "the amount of ram is incorrect");
        }
    }
}
