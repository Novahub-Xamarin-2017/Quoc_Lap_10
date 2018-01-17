using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise6.Models;

namespace Exercise6.Controllers.Adapters
{
    class MessageViewHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvSenderName)] private TextView tvSenderName;

        [InjectView(Resource.Id.tvMessageContent)] private TextView tvMessageContent;

        [InjectView(Resource.Id.tvMessageTime)] private TextView tvMessageTime;

        public MessageNotification MessageNotification
        {
            set
            {
                tvSenderName.Text = value.SenderName;
                tvMessageContent.Text = value.MessageContent;
                tvMessageTime.Text = value.MessageTime;
            }
        }

        public MessageViewHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
        }
    }
}