using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Practice1.Activities;

namespace Practice1.Adapters
{
    public class task2Model
    {
        public string mProjectName { get; set; }
        public string mStartDate { get; set; }
        public string mEndDate { get; set; }
        public string mPercent { get; set; }
        public string mWork { get; set; }
        public string mDuration { get; set; }

    }

    public class task2
    {



        List<task2Model> listTasks = new List<task2Model> {

            new task2Model() { mProjectName = "SharepointApp", mStartDate = "March 23, 2017", mEndDate = "March 23, 3011", mPercent = "100%", mWork = "300 hours", mDuration = " 1 week" },
            new task2Model() { mProjectName = "SharepointApp", mStartDate = "March 23, 2017", mEndDate = "March 23, 3011", mPercent = "100%", mWork = "300 hours", mDuration = " 1 week" },
            new task2Model() { mProjectName = "SharepointApp", mStartDate = "March 23, 2017", mEndDate = "March 23, 3011", mPercent = "100%", mWork = "300 hours", mDuration = " 1 week" },
            new task2Model() { mProjectName = "SharepointApp", mStartDate = "March 23, 2017", mEndDate = "March 23, 3011", mPercent = "100%", mWork = "300 hours", mDuration = " 1 week" },
            new task2Model() { mProjectName = "SharepointApp", mStartDate = "March 23, 2017", mEndDate = "March 23, 3011", mPercent = "100%", mWork = "300 hours", mDuration = " 1 week" },

        };

        public task2() { }

        public void addProject()
        {


        }

        public int numHome
        {
            get { return listTasks.Count; }
        }

        public task2Model this[int i]
        {
            get { return listTasks[i]; }
        }

    }


    public class Task2ViewHolder : RecyclerView.ViewHolder
    {

        public TextView projectName { get; set; }
        public TextView startDate { get; set; }
        public TextView endDate { get; set; }
        public TextView percent { get; set; }
        public TextView work { get; set; }
        public TextView duration { get; set; }
        public ImageView resource { get; set; }
        public ImageView edit { get; set; }
        public ImageView delete { get; set; }




        public Task2ViewHolder(View itemView, Action<int> listener) : base(itemView)
        {

            projectName = itemView.FindViewById<TextView>(Resource.Id.tvTaskName);
            startDate = itemView.FindViewById<TextView>(Resource.Id.tvTaskStartDate);
            endDate = itemView.FindViewById<TextView>(Resource.Id.tvTaskEndDate);
            percent = itemView.FindViewById<TextView>(Resource.Id.tvTaskPercent);
            work = itemView.FindViewById<TextView>(Resource.Id.tvTaskWork);
            duration = itemView.FindViewById<TextView>(Resource.Id.tvTaskDuration);
            resource = itemView.FindViewById<ImageView>(Resource.Id.ivTaskResource);
            edit = itemView.FindViewById<ImageView>(Resource.Id.ivTaskEdit);
            delete = itemView.FindViewById<ImageView>(Resource.Id.ivTaskDelete);
            itemView.Click += (sender, e) => listener(Position);

        }

    }


    public class TaskAdapter : RecyclerView.Adapter
    {

        public event EventHandler<int> itemClick;
        public task2 mTask2;
        public MainActivity main;

        public TaskAdapter(task2 task2, MainActivity main)
        {
            mTask2 = task2;
            this.main = main;
        }


        public override int ItemCount
        {
            get
            {
                return mTask2.numHome;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            Task2ViewHolder vh = holder as Task2ViewHolder;
            vh.projectName.Text = mTask2[position].mProjectName;
            vh.startDate.Text = mTask2[position].mStartDate;
            vh.endDate.Text = mTask2[position].mEndDate;
            vh.percent.Text = mTask2[position].mPercent;
            vh.work.Text = mTask2[position].mWork;
            vh.duration.Text = mTask2[position].mDuration;
            vh.resource.Click += delegate { main.bringDialogs(1); };
            vh.edit.Click += delegate { main.bringDialogs(2); };
            vh.delete.Click += delegate { main.bringDialogs(3); };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.task_recycler, parent, false);
            Task2ViewHolder vh = new Task2ViewHolder(itemView, OnClick);
            return vh;
        }

        private void OnClick(int obj)
        {
            if (itemClick != null)
            {
                itemClick(this, obj);
            }
        }
    }



}