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

namespace Practice1.Adapters
{
    public class taskModel
    {
        public string mProjectName { get; set; }
        public string mTaskName { get; set; }
        public string mHoursRendered { get; set; }
        public string mDate { get; set; }
    }

    public class taskCompilation {

        List<taskModel> listPhotos = new List<taskModel> { };
        Random random;

        public taskCompilation() {
            random = new Random();
        }

        public void addPhotos(string projectName, string taskName, string hoursRendered, string date)
        {
            listPhotos.Add(new taskModel() { mProjectName = projectName, mTaskName = taskName, mHoursRendered = hoursRendered, mDate = date });
        }

        public int numPhotos
        {

            get { return listPhotos.Count; }
        }

        public taskModel this[int i]
        {

            get { return listPhotos[i]; }
        }
    }

    public class PhotoViewHolder : RecyclerView.ViewHolder
    {

        public TextView projectName { get; set; }
        public TextView taskName { get; set; }
        public TextView hoursRendered { get; set; }
        public TextView rate { get; set; }

        public PhotoViewHolder(View itemView, Action<int> listener) : base(itemView)
        {

            projectName = itemView.FindViewById<TextView>(Resource.Id.projectName);
            taskName = itemView.FindViewById<TextView>(Resource.Id.taskName);
            hoursRendered = itemView.FindViewById<TextView>(Resource.Id.hoursRendered);
            rate = itemView.FindViewById<TextView>(Resource.Id.rate);
            itemView.Click += (sender, e) => listener(Position);
        }
    }


    public class PhotoAlbumAdapter : RecyclerView.Adapter
    {
        public event EventHandler<int> itemClick;
        public taskCompilation mTaskCompilation;

        public PhotoAlbumAdapter(taskCompilation taskCompilation)
        {

            mTaskCompilation = taskCompilation;
        }

        public override int ItemCount
        {
            get
            {
                return mTaskCompilation.numPhotos;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PhotoViewHolder vh = holder as PhotoViewHolder;
            vh.projectName.Text = mTaskCompilation[position].mProjectName;
            vh.taskName.Text = mTaskCompilation[position].mTaskName;
            vh.hoursRendered.Text = mTaskCompilation[position].mHoursRendered;
            vh.rate.Text = mTaskCompilation[position].mDate;
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.task_card, parent, false);
            PhotoViewHolder vh = new PhotoViewHolder(itemView, OnClick);
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