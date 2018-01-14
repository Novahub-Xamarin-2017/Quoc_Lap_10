using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise1.Adapter;
using Exercise1.Models;

namespace Exercise1
{
    [Activity(Label = "Exercise1", MainLauncher = true, Theme = "@android:style/Theme.Material.Light.DarkActionBar")]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.rvSample)] private RecyclerView rvSample;
        private AndroidInfoAdapter adapter;
        private List<VersionInfo> versionInfos;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            rvSample.SetLayoutManager(new LinearLayoutManager(this));
            versionInfos = Ultilites.ReadJson<VersionInfo>("data.json");
            adapter = new AndroidInfoAdapter(versionInfos);
            rvSample.SetAdapter(adapter);
        }
    }
}

