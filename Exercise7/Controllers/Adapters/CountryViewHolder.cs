using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise7.Models;

namespace Exercise7.Controllers.Adapters
{
    class CountryViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvCountryName)] private TextView tvCountryName;

        private Country country;

        public Country Country
        {
            get => country;
            set
            {
                country = value;
                tvCountryName.Text = value.Name;
            }
        }

        public CountryViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
            itemView.Click += (sender, e) =>
            {
                Toast.MakeText(itemView.Context, country.Name, ToastLength.Short).Show();
            };
        }
    }
}