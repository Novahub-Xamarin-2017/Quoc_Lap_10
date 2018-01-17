using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;

namespace Exercise3.Models.Adapters
{
    public class FileAdapter:RecyclerView.Adapter
    {
        private List<ManagerItem> mList;

        public event EventHandler ItemClick;

        public FileAdapter(List<ManagerItem> mList)
        {
            this.mList = mList;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ((FileViewHolder) holder).FileItem = mList[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Simple_Item, parent, false);
            return  new FileViewHolder(itemView, OnClick);
        }

        private void OnClick(int position)
        {
            ItemClick?.Invoke(mList[position], null);
        }

        public override int ItemCount => mList.Count;

        public void UpdateAdapter(List<ManagerItem> list)
        {
            mList.Clear();
            mList = list;
            NotifyDataSetChanged();
        }
        
    }
}