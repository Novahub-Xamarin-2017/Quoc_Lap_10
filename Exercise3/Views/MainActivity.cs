using System.Collections.Generic;
using System.IO;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise3.Models;
using Exercise3.Models.Adapters;
using Environment = Android.OS.Environment;

namespace Exercise3.Views
{
    [Activity(Label = "Exercise3", MainLauncher = true, Theme = "@android:style/Theme.Holo.Light.NoActionBar")]
    public class MainActivity : Activity
    {
        public const string FileType = "File Type";
        public const string FileName = "File Name";
        [InjectView(Resource.Id.tvTitle)] private TextView tvTitle;
        [InjectView(Resource.Id.rvFileManager)] private RecyclerView rvFileManager;
        private FileAdapter adapter;
        private List<ManagerItem> list;
        private string path = Environment.ExternalStorageDirectory.AbsolutePath;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // init values
            list = Ultilities.GetFileAndFolderNames(path);
            adapter = new FileAdapter(list);

            // set widgets 
            Cheeseknife.Inject(this);
            rvFileManager.SetLayoutManager(new LinearLayoutManager(this));
            rvFileManager.SetAdapter(adapter);
            tvTitle.Text = path;

            // add widget's listeners
            adapter.ItemClick += (sender, i) =>
            {
                var managerItem = (ManagerItem) sender;
                path = managerItem.Name;
                switch (managerItem.Image)
                {
                    case Resource.Drawable.folder32:
                        tvTitle.Text = path;
                        adapter.UpdateAdapter(Ultilities.GetFileAndFolderNames(path));
                        break;
                    case Resource.Drawable.file32:
                        Toast.MakeText(this, path, ToastLength.Short).Show();
                        break;
                    default:
                        OpenFileFromPath(managerItem);
                        break;
                }

            };
        }

        private void OpenFileFromPath(ManagerItem managerItem)
        {
            var intent = new Intent(this, typeof(OpenFile));
            intent.PutExtra(FileType, managerItem.Image);
            intent.PutExtra(FileName, managerItem.Name);
            StartActivity(intent);
        }

        public override void OnBackPressed()
        {
            if (path == Environment.ExternalStorageDirectory.AbsolutePath)
            {
                Finish();
            }
            else
            {
                path = Directory.GetParent(path).ToString();
                tvTitle.Text = path;
                adapter.UpdateAdapter(Ultilities.GetFileAndFolderNames(path));
            }
        }
    }
}

