using System.Collections.Generic;
using Android.Support.V7.Widget;
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
            ((AndroidViewHolder) holder).VersionInfo = versionInfos[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.RecyclerViewItem, parent, false);
            return new AndroidViewHolder(itemView);
        }

        public override int ItemCount => versionInfos.Count;
       
    }
}