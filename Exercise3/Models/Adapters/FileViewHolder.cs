using System;
using Android.Support.V7.Widget;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using Java.IO;

namespace Exercise3.Models.Adapters
{
    public class FileViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.imgIcon)] public ImageView ImgIcon;

        [InjectView(Resource.Id.tvName)] public TextView TvName;

        private ManagerItem fileItem;

        public ManagerItem FileItem
        {
            get => fileItem;

            set
            {
                ImgIcon.SetImageResource(value.Image);
                TvName.Text = new File(value.Name).Name;
                fileItem = value;
            }
        }

        public FileViewHolder(Android.Views.View itemView, Action<int> listener) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
            itemView.Click += (sender, e) =>
                listener(LayoutPosition);
        }
    }
}