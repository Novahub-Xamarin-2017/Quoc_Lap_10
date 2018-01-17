using System.Collections.Generic;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace Exercise4.Views
{
    public class BookFragment : Fragment
    {
        private readonly List<string> books = new List<string>
        {
            "Tony Buoi Sang",
            "Harry Potter",
            "If only you were true",
            "Tony Buoi Sang",
            "Harry Potter",
            "If only you were true","Tony Buoi Sang",
            "Harry Potter",
            "If only you were true",
            "Harry Potter",
            "If only you were true"
        };

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.Book_Frame, container, false);
            var adapter = new ArrayAdapter<string>(Activity, Android.Resource.Layout.SimpleListItem1, books);
            var lvBooks = (ListView)view.FindViewById(Resource.Id.lvBooks);
            lvBooks.Adapter = adapter;
            lvBooks.ItemClick += (sender, e) =>
            {
                var dialog = new AlertDialog.Builder(Activity);
                dialog.SetTitle(books[e.Position]);
                dialog.SetMessage("some detail information");
                dialog.Create().Show();
            };
            return view;
        }
    }
}