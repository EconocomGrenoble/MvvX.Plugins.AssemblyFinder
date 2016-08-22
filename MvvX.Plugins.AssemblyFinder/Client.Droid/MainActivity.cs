using Android.App;
using Android.Widget;
using Android.OS;
using MvvX.Plugins.AssemblyFinder.Droid;
using System.Linq;
using Client.SampleClasses;

namespace Client.Droid
{
    [Activity(Label = "Client.Droid", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.MyButton);

            button.Click += delegate {
            var typeFinder = new AssemblyFinder();
            var myListOfClassesOrInterfaces = typeFinder.FindClassesOfType(typeof(IService)).ToList();
            button.Text = myListOfClassesOrInterfaces.Count() + " classes finded." + string.Join("/", myListOfClassesOrInterfaces.Select(e => e.Name)); };
        }
    }
}

