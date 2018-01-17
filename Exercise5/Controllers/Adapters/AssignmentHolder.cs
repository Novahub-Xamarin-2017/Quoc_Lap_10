using System;
using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Lilarcor.Cheeseknife;
using Exercise5.Models;

namespace Exercise5.Controllers.Adapters
{
    class AssignmentHolder : RecyclerView.ViewHolder
    {
        [InjectView(Resource.Id.tvCourse)] private TextView tvCourse;
        [InjectView(Resource.Id.tvExercise)] private TextView tvExercise;
        [InjectView(Resource.Id.tvLesson)] private TextView tvLesson;
        [InjectView(Resource.Id.tvDeadline)] private TextView tvDeadline;
        [InjectView(Resource.Id.tvDuration)] private TextView tvDuration;
        [InjectView(Resource.Id.btnAction)] private Button btnAction;
        [InjectView(Resource.Id.btnStatus)] private Button btnStatus;
        [InjectView(Resource.Id.statusLine)] private View statusLine;

        private Assignment assignment;

        public Assignment Assignment
        {
            get => assignment;
            set
            {
                assignment = value;
                tvCourse.Text = assignment.CourseName + ", ";
                tvExercise.Text = assignment.Exercise + ", ";
                tvLesson.Text = assignment.LessonName;
                tvDeadline.Text = assignment.Deadline.ToShortDateString();
                tvDuration.Text = assignment.Duration;
                var timeRemainder = (assignment.Deadline - DateTime.Now).Days;
                if (timeRemainder < 0)
                    SetButtonsAndStatusLine("  Completed", Resource.Drawable.ok, "  Report", Resource.Drawable.report,
                        Color.Aqua);
                else
                    SetButtonsAndStatusLine("  " + timeRemainder + (timeRemainder == 1 ? " Day left" : " Days left"),
                        Resource.Drawable.countdown, "  Resume", Resource.Drawable.circleplay,
                        Color.PaleVioletRed);
            }
        }
        
        private void SetButtonsAndStatusLine(string status, int statusDrawable, string action, int actionDrawable, Color color)
        {
            btnStatus.Text = status;
            btnStatus.SetCompoundDrawablesWithIntrinsicBounds(statusDrawable, 0, 0, 0);
            btnAction.Text = action;
            btnAction.SetCompoundDrawablesWithIntrinsicBounds(actionDrawable, 0, 0, 0);
            statusLine.Background = new ColorDrawable(color);
        }

        public AssignmentHolder(View itemView) : base(itemView)
        {
            Cheeseknife.Inject(this, itemView);
            itemView.Click += (sender, e) =>
            {
                var dialog = new AlertDialog.Builder(itemView.Context);
                dialog.SetTitle("Assignment detail infomations");
                dialog.SetMessage(assignment.DetailInfomation);
                dialog.Create().Show();
            };
        }
    }
}