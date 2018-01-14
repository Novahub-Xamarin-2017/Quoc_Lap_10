using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;

namespace Exercise1.Models
{
    class AndroidViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.img)] public ImageView Img;
        [InjectView(Resource.Id.tvName)] public TextView TvName;
        [InjectView(Resource.Id.tvVersion)] public TextView TvVersion;

        public VersionInfo VersionInfo
        {
            set
            {
                TvName.Text = value.Name;
                TvVersion.Text = value.Version;
                Img.SetImageBitmap(Ultilites.Base64ToBitmap(value.Image));
            }
        }

        public AndroidViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this,itemView);
        }
    }
}