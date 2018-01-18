using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise7.Controllers.Adapters;
using Exercise7.Models;
using Newtonsoft.Json;

namespace Exercise7.Views
{
    [Activity(Label = "Exercise7", MainLauncher = true, Theme = "@android:style/Theme.Holo.Light")]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.rvCountries)] private RecyclerView rvCountries;
        private Android.Widget.SearchView searchView;
        private List<Country> countries;
        private CountryAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);

            countries = GetJsonFromAsset<Country>("countries.json");
            adapter = new CountryAdapter(countries);
            rvCountries.SetLayoutManager(new LinearLayoutManager(this));
            rvCountries.SetAdapter(adapter);

            searchView = FindViewById<Android.Widget.SearchView>(Resource.Id.searchView);
            searchView.QueryTextChange += (sender, e) => 
            {
                adapter = new CountryAdapter(countries.FindAll(country => country.Name.ToLower().Contains(searchView.Query)));
                rvCountries.SetAdapter(adapter);
            };
        }

        public static List<T> GetJsonFromAsset<T>(string fileName)
        {
            using (var stream = Application.Context.Assets.Open(fileName))
            {
                var streamReader = new StreamReader(stream);
                var content = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<T>>(content);
            }
        }
    }
}

