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
    public class resourceModel {

        public int mResourcePic { get; set; }
        public string mResourceName { get; set; }
        public string mResourceRoler { get; set; }

    }

    public class resource {

        List<resourceModel> listResource = new List<resourceModel> {

            new resourceModel() { mResourcePic = Resource.Drawable.sample, mResourceName = "Kristian Francisco", mResourceRoler = "Project Manager" },
            new resourceModel() { mResourcePic = Resource.Drawable.sample, mResourceName = "Kristian Francisco", mResourceRoler = "Designer" },
            new resourceModel() { mResourcePic = Resource.Drawable.sample, mResourceName = "Kristian Francisco", mResourceRoler = "Analyst" },
            new resourceModel() { mResourcePic = Resource.Drawable.sample, mResourceName = "Kristian Francisco", mResourceRoler = "Designer" },
            new resourceModel() { mResourcePic = Resource.Drawable.sample, mResourceName = "Kristian Francisco", mResourceRoler = "Analyst" },
            new resourceModel() { mResourcePic = Resource.Drawable.sample, mResourceName = "Kristian Francisco", mResourceRoler = "Designer" },
            new resourceModel() { mResourcePic = Resource.Drawable.sample, mResourceName = "Kristian Francisco", mResourceRoler = "Analyst" },
        };

        public resource(){}

        public int numResource
        {
            get { return listResource.Count; }
        }

        public resourceModel this[int i]
        {
            get { return listResource[i]; }
        }

    }

    public class ResourceViewHolder : RecyclerView.ViewHolder {

        public TextView resourceName { get; set; }
        public ImageView resourcePic { get; set; }
        public TextView resourceRole { get; set; }


        public ResourceViewHolder(View itemView, Action<int> listener) : base(itemView) {

            resourceName = itemView.FindViewById<TextView>(Resource.Id.tvResourceName);
            resourcePic = itemView.FindViewById<ImageView>(Resource.Id.civResourcePic);
            resourceRole = itemView.FindViewById<TextView>(Resource.Id.tvResourceRole);
            itemView.Click += (sender, e) => listener(Position);

        }

    }


    public class ResourceAdapter : RecyclerView.Adapter
    {


        public event EventHandler<int> itemClick;
        public resource mResource;
        public MainActivity main;

        public ResourceAdapter(resource resource, MainActivity main)
        {
            mResource = resource;
            this.main = main;
        }

        public override int ItemCount
        {
            get
            {
                return mResource.numResource;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            ResourceViewHolder vh = holder as ResourceViewHolder;
            vh.resourceName.Text = mResource[position].mResourceName;
            vh.resourceRole.Text = mResource[position].mResourceRoler;
            vh.resourcePic.SetImageResource(mResource[position].mResourcePic);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.resource_recycler, parent, false);
            ResourceViewHolder vh = new ResourceViewHolder(itemView, OnClick);
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