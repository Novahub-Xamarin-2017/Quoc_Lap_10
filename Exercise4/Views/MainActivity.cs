using Android.App;
using Android.OS;
using Android.Widget;

namespace Exercise4.Views
{
    [Activity(Label = "Exercise4", MainLauncher = true, Theme = "@android:style/Theme.Holo.Light")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            SetContentView(Resource.Layout.Main);
            CreateTabBar("Applications", new ApplicationFragment());
            CreateTabBar("Games", new GameFragment());
            CreateTabBar("Books", new BookFragment());
        }

        private void CreateTabBar(string title, Fragment fragment)
        {
            var tab = ActionBar.NewTab();
            tab.SetText(title);
            tab.TabSelected += (sender, args) =>
            {
                var ft = FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.fragment_container, fragment);
                ft.Commit();
                Toast.MakeText(this, title, ToastLength.Short).Show();
            };
            ActionBar.AddTab(tab);
        }
    }
}

