using MvvmCross;
using MvvmCross.Plugin;

namespace MvvX.Plugins.AssemblyFinder
{
    [MvxPlugin]
    [Preserve(AllMembers = true)]
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.IoCProvider.RegisterSingleton<IAssemblyFinder>(new AssemblyFinder());
        }
    }
}
