using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise7.Models;

namespace Exercise7.Controllers.Adapters
{
    class HeadCountryViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvHeadLetter)] private TextView tvHeadLetter;

        [InjectView(Resource.Id.tvCountryName)] private TextView tvCountryName;

        private Country country;

        public Country Country
        {
            set
            {
                country = value;
                tvCountryName.Text = value.Name;
                tvHeadLetter.Text = value.Name[0].ToString();
            }
        }

        public HeadCountryViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
            tvCountryName.Click += (sender, e) =>
            {
                Toast.MakeText(itemView.Context, country.Name, ToastLength.Short).Show();
            };
        }
    }
}