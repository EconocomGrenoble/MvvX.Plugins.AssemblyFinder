using MvvmCross.Platform;
using MvvmCross.Platform.Plugins;

namespace MvvX.Plugins.AssemblyFinder.WindowsUWP
{
    public class Plugin : IMvxPlugin
    {
        public void Load()
        {
            Mvx.RegisterSingleton<IAssemblyFinder>(new AssemblyFinder());
        }
    }
}
