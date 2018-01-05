using System;
using System.Collections.Generic;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Exercise1.Models;

namespace Exercise1.Adapter
{
    class AndroidInfoAdapter : RecyclerView.Adapter
    {
        private List<VersionInfo> versionInfos;

        public AndroidInfoAdapter(List<VersionInfo> versionInfos)
        {
            this.versionInfos = versionInfos;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            if (!(holder is AndroidViewHolder vh)) return;
            vh.TvName.Text = versionInfos[position].Name;
            vh.TvVersion.Text = versionInfos[position].Version;
            vh.Img.SetImageBitmap(Base64ToBitmap(versionInfos[position].Image));
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.RecyclerViewItem, parent, false);
            return new AndroidViewHolder(itemView);
        }

        public override int ItemCount => versionInfos.Count;

        public Bitmap Base64ToBitmap(String base64String)
        {
            var imageAsBytes = Base64.Decode(base64String, Base64Flags.Default);
            return BitmapFactory.DecodeByteArray(imageAsBytes, 0, imageAsBytes.Length);
        }
    }
}