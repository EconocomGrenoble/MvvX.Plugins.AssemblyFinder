using System;
using System.Linq;
using System.Reflection;
using Client.SampleClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MvvX.Plugins.AssemblyFinder.Unit.Tests
{
    [TestClass]
    public class AssemblyFinderTests
    {
        [TestMethod]
        public void FindClassesOfType()
        {
            Assembly.Load(new AssemblyName("Client.SampleClasses"));

            var typeFinder = new MvvX.Plugins.AssemblyFinder.Wpf.AssemblyFinder();
            var myListOfClassesOrInterfaces = typeFinder.FindClassesOfType(typeof(IService)).ToList();
            Assert.IsTrue(myListOfClassesOrInterfaces.Count() == 3);
        }
    }
}
