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
                if (timeRemainder >= 0)
                {
                    btnStatus.Text = "  " + timeRemainder + (timeRemainder == 1 ? " Day left" : " Days left");
                    btnStatus.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.countdown, 0, 0, 0);
                    btnAction.Text = "  Resume";
                    btnAction.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.circleplay, 0, 0, 0);
                    statusLine.Background = new ColorDrawable(Color.PaleVioletRed);
                }
                else
                {
                    btnStatus.Text = "  Completed";
                    btnStatus.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.ok, 0, 0, 0);
                    btnAction.Text = "  Report";
                    btnAction.SetCompoundDrawablesWithIntrinsicBounds(Resource.Drawable.report, 0, 0, 0);
                    statusLine.Background = new ColorDrawable(Color.Aqua);
                }
            }
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