using MvvmCross;
using MvvmCross.Plugin;

namespace MvvX.Plugins.AssemblyFinder.Droid
{
    [MvxPlugin]
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.IoCProvider.RegisterSingleton<IAssemblyFinder>(new AssemblyFinder());
        }
    }
}
