﻿using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;

namespace Exercise2.Models.Adapters.BillAdapter
{
    class BillAdapter :RecyclerView.Adapter
    {
        private List<Product> products;

        public BillAdapter(List<Product> products)
        {
            this.products = products;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            
            ((ViewHolder) holder).Product = products[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Checkout_bill_item, parent, false);
            return new ViewHolder(itemView);
        }

        public override int ItemCount => products.Count;
    }
}