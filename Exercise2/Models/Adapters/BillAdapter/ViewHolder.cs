using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;

namespace Exercise2.Models.Adapters.BillAdapter
{
    public class ViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.imgProduct)] public ImageView ImgProduct;

        [InjectView(Resource.Id.tvName)] public TextView TvName;

        [InjectView(Resource.Id.tvRs)] public TextView TvRs;

        [InjectView(Resource.Id.tvUnit)] public TextView TvUnit;

        [InjectView(Resource.Id.tvCount)] public TextView TvCount;

        [InjectView(Resource.Id.tvMoney)] public TextView TvMoney;

        public Product Product
        {
            set
            {
                TvName.Text = value.Name;
                TvRs.Text = "Rs. " + value.UnitPrice;
                TvUnit.Text = value.UnitType;
                TvCount.Text = value.Count +"";
                TvMoney.Text = value.UnitPrice * value.Count + " vnd";
                ImgProduct.SetImageBitmap(Ultilities.Base64ToBitmap(value.Image));
            }
        }

        public ViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }
    }
}