using System;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;

namespace Exercise3.Models.Adapters
{
    public class FileViewHolder : RecyclerView.ViewHolder
    {
        public FileViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public FileViewHolder(View itemView) : base(itemView)
        {
        }
    }
}