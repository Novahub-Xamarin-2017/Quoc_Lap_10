using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise5.Controllers;
using Exercise5.Controllers.Adapters;

namespace Exercise5
{
    [Activity(Label = "Exercise5", MainLauncher = true, Theme = "@android:style/Theme.Holo.Light")]
    public class MainActivity : Activity
    {
        private DataProvider provider;
        private AssignmentAdapter adapter;
        [InjectView(Resource.Id.rvAssignments)] private RecyclerView rvAssignments;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            Cheeseknife.Inject(this);
            provider = DataProvider.Instance;
            adapter = new AssignmentAdapter(provider.Assignments);
            rvAssignments.SetLayoutManager(new LinearLayoutManager(this));
            rvAssignments.SetAdapter(adapter);
        }
    }
}

