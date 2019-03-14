using System.Linq;
using Test.Library;
using Test.Library.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvvX.Plugins.AssemblyFinder.UnitTests
{
    [TestClass]
    public class AssemblyFinderTests
    {
        [TestMethod]
        public void FindClassesOfType_Generic_IService()
        {
            var assemblyFinder = new AssemblyFinder();
            var services = assemblyFinder.FindClassesOfType<IService>();
            Assert.AreEqual(3, services.Count());
        }

        [TestMethod]
        public void FindClassesOfType_Generic_MyFirstClass()
        {
            var assemblyFinder = new AssemblyFinder();
            var services = assemblyFinder.FindClassesOfType<MyFirstClass>();
            Assert.AreEqual(2, services.Count());
        }

        [TestMethod]
        public void FindClassesOfType()
        {
            var assemblyFinder = new AssemblyFinder();
            var services = assemblyFinder.FindClassesOfType(typeof(IService));
            Assert.AreEqual(3, services.Count());
        }
    }
}
