using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Exercise4.Views
{
    public class ApplicationFragment : Fragment
    {
        public const string Name = "Applications";

        private readonly List<string> list = new List<string>
        {
            "Word",
            "Excel",
            "PowerPoint",
            "Word",
            "Excel",
            "PowerPoint",
            "Excel",
            "Word",
            "Excel",
            "PowerPoint"
        };

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view =  inflater.Inflate(Resource.Layout.Applications_Frame, container, false);
            var adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, list);
            var lvApps = (ListView)view.FindViewById(Resource.Id.lvApplications);
            lvApps.Adapter = adapter;
            lvApps.ItemClick += LvApps_ItemClick;
            return view;
        }

        private void LvApps_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            var dialog = new AlertDialog.Builder(Activity);
            dialog.SetTitle(list[e.Position]);
            dialog.SetMessage("some detail information");
            dialog.Create().Show();
        }
    }
}