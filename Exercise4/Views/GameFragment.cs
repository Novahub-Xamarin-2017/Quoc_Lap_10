using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Exercise4.Views
{
    public class GameFragment : Fragment
    {
        private readonly List<string> games = new List<string>
        {
            "Dota",
            "LOL",
            "AOE",
            "CS",
            "Dota",
            "LOL",
            "AOE",
            "CS",
            "Dota",
            "LOL"
        };

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Game_Frame, container, false);
            var adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, games);
            var lvGames = (ListView)view.FindViewById(Resource.Id.lvGames);
            lvGames.Adapter = adapter;
            lvGames.ItemClick += (sender, e) =>
            {
                var dialog = new AlertDialog.Builder(Activity);
                dialog.SetTitle(games[e.Position]);
                dialog.SetMessage("some detail information");
                dialog.Create().Show();
            };
            return view;
        }
    }
}