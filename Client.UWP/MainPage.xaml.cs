using Client.SampleClasses;
using MvvX.Plugins.AssemblyFinder;
using System.Linq;
using System.Reflection;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Client.UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void btnFindClasses_Click(object sender, RoutedEventArgs e)
        {
            Assembly.Load(new AssemblyName("Client.SampleClasses"));

            var typeFinder = new AssemblyFinder();
            var myListOfClassesOrInterfaces = typeFinder.FindClassesOfType(typeof(IService)).ToList();
            btnFindClasses.Content = myListOfClassesOrInterfaces.Count + " classes finded." + string.Join("/", myListOfClassesOrInterfaces.Select(f => f.Name));
        }
    }
}
