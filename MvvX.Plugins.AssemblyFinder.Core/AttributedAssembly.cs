using System;
using System.Reflection;

namespace MvvX.Plugins.AssemblyFinder
{
    public class AttributedAssembly
    {
        public Assembly Assembly { get; set; }

        public Type PluginAttributeType { get; set; }
    }
}
