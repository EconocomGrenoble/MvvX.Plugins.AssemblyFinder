using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MvvX.Plugins.AssemblyFinder
{
    public abstract class BaseAssemblyFinder
    {
        #region Fields

        protected readonly bool LoadAppDomainAssemblies = true;
        protected readonly string AssemblySkipLoadingPattern = "^System|^mscorlib|^Microsoft";
        protected readonly string AssemblyRestrictToLoadingPattern = ".*";

        /// <summary>
        /// Caches attributed assembly information so they don't have to be re-read
        /// </summary>
        protected readonly List<AttributedAssembly> AttributedAssemblies = new List<AttributedAssembly>();
        /// <summary>
        /// Caches the assembly attributes that have been searched for
        /// </summary>
        protected readonly List<Type> AssemblyAttributesSearched = new List<Type>();

        #endregion

        #region Properties

        /// <summary>Gets or sets assemblies loaded a startup in addition to those loaded in the AppDomain.</summary>
        public IList<string> AssemblyNames { get; set; } = new List<string>();

        #endregion

        #region Public methods

        /// <summary>
        /// Check if a dll is one of the shipped dlls that we know don't need to be investigated.
        /// </summary>
        /// <param name="assemblyFullName">
        /// The name of the assembly to check.
        /// </param>
        /// <returns>
        /// True if the assembly should be loaded into Nop.
        /// </returns>
        public virtual bool Matches(string assemblyFullName)
        {
            return !Matches(assemblyFullName, AssemblySkipLoadingPattern)
                   && Matches(assemblyFullName, AssemblyRestrictToLoadingPattern);
        }

        /// <summary>
        /// Check if a dll is one of the shipped dlls that we know don't need to be investigated.
        /// </summary>
        /// <param name="assemblyFullName">
        /// The assembly name to match.
        /// </param>
        /// <param name="pattern">
        /// The regular expression pattern to match against the assembly name.
        /// </param>
        /// <returns>
        /// True if the pattern matches the assembly name.
        /// </returns>
        protected virtual bool Matches(string assemblyFullName, string pattern)
        {
            return Regex.IsMatch(assemblyFullName, pattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);
        }

        #endregion
    }
}
