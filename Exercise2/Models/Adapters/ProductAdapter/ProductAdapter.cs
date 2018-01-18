using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;

namespace Exercise2.Models.Adapters.ProductAdapter
{
    class ProductAdapter :RecyclerView.Adapter
    {
        private readonly List<Product> products;

        public ProductAdapter(List<Product> products)
        {
            this.products = products;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var vh = (ViewHolder)holder;
            vh.Product = products[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.Product, parent, false);
            return new ViewHolder(itemView);
        }

        public override int ItemCount => products.Count;
    }
}