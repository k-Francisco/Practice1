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
using Android.Util;

namespace Practice1.Adapters
{
    public class taskModel
    {
        public string mProjectName { get; set; }
      
    }

    public class taskCompilation {

        List<taskModel> listPhotos = new List<taskModel> {
            new taskModel() {mProjectName = "PROJECT NAME 1" },
            new taskModel() {mProjectName = "PROJECT NAME 2" },
            new taskModel() {mProjectName = "PROJECT NAME 3" }
        };
        Random random;

        public taskCompilation() {
            random = new Random();
        }

        public void addPhotos(string projectName)
        {
            listPhotos.Add(new taskModel() { mProjectName = projectName});
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

        public Button projectName { get; set; }
    

        public PhotoViewHolder(View itemView, Action<int> listener) : base(itemView)
        {

            projectName = itemView.FindViewById<Button>(Resource.Id.btnTaskHome);
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