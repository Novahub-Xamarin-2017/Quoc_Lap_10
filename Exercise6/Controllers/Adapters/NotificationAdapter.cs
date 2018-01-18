using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Exercise6.Models;

namespace Exercise6.Controllers.Adapters
{
    class NotificationAdapter : RecyclerView.Adapter
    {
        private const int TypeCall = 1, TypeMessage = 2;
        private readonly List<object> notifications;

        public NotificationAdapter(List<object> notifications)
        {
            this.notifications = notifications;
        }

        public override int GetItemViewType(int position)
        {
            if (notifications[position] is CallNotification)
            {
                return TypeCall;
            }
            if (notifications[position] is MessageNotification)
            {
                return TypeMessage;
            }
            return -1;
        }

        public override int ItemCount => notifications.Count;


        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            switch (holder.ItemViewType)
            {
                case TypeCall:
                    ((CallViewHolder) holder).CallNotification = (CallNotification) notifications[position];
                    break;
                case TypeMessage:
                    ((MessageViewHolder)holder).MessageNotification = (MessageNotification)notifications[position];
                    break;
            }
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var layoutInflater = LayoutInflater.From(parent.Context);
            switch (viewType)
            {
                case TypeCall:
                    return new CallViewHolder(layoutInflater.Inflate(Resource.Layout.Call_Notification_Layout, parent, false));
                case TypeMessage:
                    return new MessageViewHolder(layoutInflater.Inflate(Resource.Layout.SMS_Notification_layout, parent, false));
            }
            return null;
        }
    }
}