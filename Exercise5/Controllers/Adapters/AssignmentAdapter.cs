using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Exercise5.Models;

namespace Exercise5.Controllers.Adapters
{
    class AssignmentAdapter : RecyclerView.Adapter
    {
        private readonly List<Assignment> assignments;

        public AssignmentAdapter(List<Assignment> assignments)
        {
            this.assignments = assignments;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ((AssignmentHolder) holder).Assignment = assignments[position];
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var view = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.Sample_Assignment_View, parent, false);
            return new AssignmentHolder(view);
        }

        public override int ItemCount => assignments.Count;
    }
}