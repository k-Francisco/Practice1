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
using Android.Util;

namespace Practice1.Adapters
{

   
    public class projectModel
    {
        public string mProjectName { get; set; }
        public string mStartDate { get; set; }
        public string mEndDate { get; set; }
        public string mPercent { get; set; }
        public string mWork { get; set; }
        public string mDuration { get; set; }

    }


    public class project {

        

        List<projectModel> listProjects = new List<projectModel> {};

        public project() {}

        public void addProject(string projectName, string start, string end, string percent, string work, string duration) {

            listProjects.Add( new projectModel() { mProjectName = projectName, mStartDate = start, mEndDate = end, mPercent = percent, mWork = work, mDuration = duration});
        }

        public int numHome
        {
            get { return listProjects.Count; }
        }

        public projectModel this[int i]
        {
            get { return listProjects[i]; }
        }
    
    }

    public class ProjectViewHolder : RecyclerView.ViewHolder {

        public TextView projectName { get; set; }
        public TextView startDate { get; set; }
        public TextView endDate { get; set; }
        public TextView percent { get; set; }
        public TextView work { get; set; }
        public TextView duration { get; set; }
        public ImageView resource { get; set; }
        public ImageView edit { get; set; }
        public ImageView delete { get; set; }




        public ProjectViewHolder(View itemView, Action<int> listener) : base(itemView){

            projectName = itemView.FindViewById<TextView>(Resource.Id.tvProjectName);
            startDate = itemView.FindViewById<TextView>(Resource.Id.tvProjectStartDate);
            endDate = itemView.FindViewById<TextView>(Resource.Id.tvProjectEndDate);
            percent = itemView.FindViewById<TextView>(Resource.Id.tvProjectPercent);
            work = itemView.FindViewById<TextView>(Resource.Id.tvProjectWork);
            duration = itemView.FindViewById<TextView>(Resource.Id.tvProjectDuration);
            resource = itemView.FindViewById<ImageView>(Resource.Id.ivProjectResource);
            edit = itemView.FindViewById<ImageView>(Resource.Id.ivProjectEdit);
            delete = itemView.FindViewById<ImageView>(Resource.Id.ivProjectDelete);
            itemView.Click += (sender, e) => listener(Position);

        }

    }


    public class ProjectAdaper : RecyclerView.Adapter
    {

        public event EventHandler<int> itemClick;
        public project mProject;
        public MainActivity main;

        public ProjectAdaper(project project, MainActivity main) {
            mProject = project;
            this.main = main;
        }


        public override int ItemCount
        {
            get
            {
                return mProject.numHome;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ProjectViewHolder vh = holder as ProjectViewHolder;
            vh.projectName.Text = mProject[position].mProjectName;
            vh.startDate.Text = mProject[position].mStartDate;
            vh.endDate.Text = mProject[position].mEndDate;
            vh.percent.Text = mProject[position].mPercent;
            vh.work.Text = mProject[position].mWork;
            vh.duration.Text = mProject[position].mDuration;
            vh.resource.Click += delegate { main.bringDialogs(1); };
            vh.edit.Click += delegate { main.bringDialogs(2); };
            vh.delete.Click += delegate { main.bringDialogs(3); };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.project_recycler_grid, parent, false);
            ProjectViewHolder vh = new ProjectViewHolder(itemView, OnClick);
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