using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise2.Models;
using Exercise2.Models.Adapters.BillAdapter;

namespace Exercise2
{
    [Activity(Label = "Checkout")]
    public class Checkout : Activity
    {
        [InjectView(Resource.Id.tvBillMoney)] private TextView tvBillMoney;
        [InjectView(Resource.Id.rvProducts)] private RecyclerView rvProducts;
        private BillAdapter adapter;
        private List<Product> products;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Checkout_layout);
            Cheeseknife.Inject(this);
            products = Ultilities.GetData<Product>("data.json");
            adapter = new BillAdapter(products);
            rvProducts.SetLayoutManager(new LinearLayoutManager(this));
            rvProducts.SetAdapter(adapter);

            tvBillMoney.Text = products.Sum(p => p.Count * p.UnitPrice) + " vnd";
        }
    }
}