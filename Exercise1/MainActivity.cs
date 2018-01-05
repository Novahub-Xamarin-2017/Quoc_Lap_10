using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise1.Adapter;
using Exercise1.Models;
using Newtonsoft.Json;

namespace Exercise1
{
    [Activity(Label = "Exercise1", MainLauncher = true, Theme = "@android:style/Theme.Material.Light.DarkActionBar")]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.rvSample)] private RecyclerView rvSample;
        private RecyclerView.LayoutManager layoutManager;
        private AndroidInfoAdapter adapter;
        private List<VersionInfo> versionInfos;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            layoutManager = new LinearLayoutManager(this);
            rvSample.SetLayoutManager(layoutManager);
            versionInfos = ReadJson<VersionInfo>("data.json");
            adapter = new AndroidInfoAdapter(versionInfos);
            rvSample.SetAdapter(adapter);
        }

        public List<T> ReadJson<T>(string fileName)
        {
            var stream = Application.Context.Assets.Open(fileName);
            var streamReader = new StreamReader(stream);
            var content = streamReader.ReadToEnd();
            return JsonConvert.DeserializeObject<List<T>>(content);
        }
    }
}

