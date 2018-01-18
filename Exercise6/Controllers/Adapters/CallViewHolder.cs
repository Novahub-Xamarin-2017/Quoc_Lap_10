using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise6.Models;

namespace Exercise6.Controllers.Adapters
{
    class CallViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvCallerName)] private TextView tvCallerName;

        [InjectView(Resource.Id.tvCallTime)] private TextView tvCallTime;

        public CallNotification CallNotification
        {
            set
            {
                tvCallerName.Text = value.CallerName;
                tvCallTime.Text = value.CallTime;
            }
        }

        public CallViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }

    }
}