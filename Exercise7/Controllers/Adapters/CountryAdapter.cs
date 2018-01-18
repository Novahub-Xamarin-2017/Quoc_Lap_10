using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Exercise7.Models;

namespace Exercise7.Controllers.Adapters
{
    class CountryAdapter : RecyclerView.Adapter
    {
        private const int TypeNormal = 1, TypeHead = 2;

        private List<Country> countries;

        public CountryAdapter(List<Country> countries)
        {
            this.countries = countries;
        }

        public override int ItemCount => countries.Count;

        public override int GetItemViewType(int position)
        {
            if (position == 0 || countries[position-1].Name[0] != countries[position].Name[0])
            {
                return TypeHead;
            }
            return TypeNormal;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            switch (holder.ItemViewType)
            {
                case TypeHead:
                    ((HeadCountryViewHolder) holder).Country = countries[position];
                    break;
                case TypeNormal:
                    ((CountryViewHolder) holder).Country = countries[position];
                    break;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            switch (viewType)
            {
                case TypeHead:
                    return new HeadCountryViewHolder(LayoutInflater.From(parent.Context)
                        .Inflate(Resource.Layout.Header_Country_Layout, parent, false));
                case TypeNormal:
                    return new CountryViewHolder(LayoutInflater.From(parent.Context)
                        .Inflate(Resource.Layout.Normal_Country_Layout, parent, false));
            }
            return null;
        }
    }
}