using System;
using Android.Runtime;
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

        public AndroidViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public AndroidViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this,itemView);
        }
    }
}