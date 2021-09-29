using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MSTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [AssemblyInitialize]
        public static void AssemblySetUp(TestContext testcontext)
        {
            Console.WriteLine("Assembly Set Up");
        }

        [AssemblyCleanup]
        public static void AssemblyTearDown()
        {
            Console.WriteLine("Assembly Tear Down");
        }

        [ClassInitialize]
        public static void ClassSetUp(TestContext testcontext)
        {
            Console.WriteLine("Class Set Up");
        }
        [ClassCleanup]
        public static void ClassTearDown()
        {
            Console.WriteLine("Class Tear Down");
        }
        [TestMethod]
        public void TestMethod1()
        {
            Console.WriteLine("Test Method 1");
        }
        [TestMethod]
        public void TestMethod2()
        {
            Console.WriteLine("Test Method 2");
        }
        [TestInitialize]
        public void SetUp()
        {
            Console.WriteLine("This is set up");
        }
        [TestCleanup]
        public void TearDown()
        {
            Console.WriteLine("This is TearDown Method");
        }
    }
}
