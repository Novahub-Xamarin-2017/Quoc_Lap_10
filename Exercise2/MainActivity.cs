using System.Collections.Generic;
using System.Linq;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Com.Lilarcor.Cheeseknife;
using Exercise2.Models;
using Exercise2.Models.Adapters.ProductAdapter;

namespace Exercise2
{
    [Activity(Label = "Exercise2", MainLauncher = true)]
    public class MainActivity : Activity
    {

        [InjectView(Resource.Id.rvProducts)] private RecyclerView rvProducts;
        private ProductAdapter adapter;
        private List<Product> products;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Cheeseknife.Inject(this);

            rvProducts.SetLayoutManager(new LinearLayoutManager(this));
            products = Ultilities.GetDefaultData<Product>("data.json");
            adapter = new ProductAdapter(products);
            rvProducts.SetAdapter(adapter);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu, menu);
            return OnPrepareOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.checkout:
                    MoveToCheckout();
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void MoveToCheckout()
        {
            Ultilities.SaveJson(products.Where(p => p.Count > 0).ToList(), "data.json");
            var intent = new Intent(this, typeof(Checkout));
            StartActivity(intent);
        }
    }
}

