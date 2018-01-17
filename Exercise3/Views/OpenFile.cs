using Android.App;
using Android.OS;
using Android.Widget;
using Java.IO;
using Uri = Android.Net.Uri;

namespace Exercise3.Views
{
    [Activity(Label = "DisplayImage", Theme = "@android:style/Theme.Holo.Light.NoActionBar.Fullscreen")]
    public class OpenFile : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            var fileType = Intent.GetIntExtra(MainActivity.FileType, 0);
            var filePath = Intent.GetStringExtra(MainActivity.FileName);
            var file = new File(filePath);
            switch (fileType)
            {
                case Resource.Drawable.image32:
                    OpenImage(file);
                    break;
                case Resource.Drawable.videofile32:
                    OpenMediaFile(file);
                    break;
            }
        }

        private void OpenMediaFile(File file)
        {
            SetContentView(Resource.Layout.Play_Video_Layout);
            var videoView = FindViewById<VideoView>(Resource.Id.videoView);
            videoView.SetVideoURI(Uri.FromFile(file));
            videoView.Start();
        }

        private void OpenImage(File file)
        {
            SetContentView(Resource.Layout.Display_Image_layout);
            var image = FindViewById<ImageView>(Resource.Id.imageView);
            image.SetImageURI(Uri.FromFile(file));
        }
    }
}