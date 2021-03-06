﻿using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;

namespace Exercise2.Models.Adapters.ProductAdapter
{
    class ViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.imgProduct)] public ImageView ImgProduct;

        [InjectView(Resource.Id.tvName)] public TextView TvName;

        [InjectView(Resource.Id.tvRs)] public TextView TvRs;

        [InjectView(Resource.Id.tvUnit)] public TextView TvUnit;

        [InjectView(Resource.Id.tvCount)] public TextView TvCount;

        [InjectView(Resource.Id.btnSub)] public ImageButton BtnSub;

        [InjectView(Resource.Id.btnAdd)] public ImageButton BtnAdd;

        private Product product;

        public Product Product
        {
            set
            {
                TvName.Text = value.Name;
                TvRs.Text = "Rs. " + value.UnitPrice;
                TvUnit.Text = value.UnitType;
                TvCount.Text = value.Count+"";
                ImgProduct.SetImageBitmap(Ultilities.Base64ToBitmap(value.Image));
                product = value;
            }
        }

        public ViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
            BtnSub.Click += (sender, e) =>
            {
                if (product.Count > 0)
                {
                    TvCount.Text = --product.Count + "";
                }
            };
            BtnAdd.Click += (sender, e) =>
            {
                TvCount.Text = ++product.Count + "";
            };
        }
    }
}
