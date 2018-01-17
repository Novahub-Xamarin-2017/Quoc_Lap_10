using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise6.Controllers;
using Exercise6.Controllers.Adapters;

namespace Exercise6.Views
{
    [Activity(Label = "Exercise6", MainLauncher = true, Theme = "@android:style/Theme.Holo.Light")]
    public class MainActivity : Activity
    {
        [InjectView(Resource.Id.rvNotifications)] private RecyclerView rvNotifications;

        private DataProvider data;
        private NotificationAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            
            data = DataProvider.Instance;
            adapter = new NotificationAdapter(data.Notifications);
            rvNotifications.SetLayoutManager(new LinearLayoutManager(this));
            rvNotifications.SetAdapter(adapter);
        }
    }
}

