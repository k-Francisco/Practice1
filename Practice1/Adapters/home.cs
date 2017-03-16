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
    public class homeModel
    {
        public string notificationCaption { get; set; }
        public string notificationTime { get; set; }
        public int notificationIcon { get; set; }
    }

    public class home {

        List<homeModel> listHome = new List<homeModel> {
            //Context context = this;
            //Android.Content.Res.Resources res = context.Resources
        new homeModel() { notificationCaption = "@string/HomeProject", notificationTime = "10 hours ago", notificationIcon = Resource.Drawable.sample},
        new homeModel() { notificationCaption = "@string/HomeTask", notificationTime = "5 mintues ago", notificationIcon = Resource.Drawable.sample},
        new homeModel() { notificationCaption = "@string/HomeApprovedTimesheet", notificationTime = "just now", notificationIcon = Resource.Drawable.sample},
        new homeModel() { notificationCaption = "@string/HomeRejectedTimesheet", notificationTime = "2 hours ago", notificationIcon = Resource.Drawable.sample}
        };
        Random random;


        public home(){
            random = new Random();
        }

        public void addHome(string notificationCaptionv, string notificationTimev, int notificationIconv) {
            listHome.Add(new homeModel() { notificationCaption = notificationCaptionv, notificationTime = notificationTimev, notificationIcon = notificationIconv });
        }

        public int numHome {
            get { return listHome.Count; }
        }

        public homeModel this[int i]{
            get { return listHome[i]; }
        }

    }


    public class HomeViewHolder : RecyclerView.ViewHolder
    {

        public TextView notificationCaption { get; set; }
        public TextView notificationTime { get; set; }
        public ImageView notificationIcon { get; set; }

        public HomeViewHolder(View itemView, Action<int> listener) : base(itemView)
        {
            notificationCaption = itemView.FindViewById<TextView>(Resource.Id.homeNotificationCaption);
            notificationTime = itemView.FindViewById<TextView>(Resource.Id.homeNotificationTime);
            notificationIcon = itemView.FindViewById<ImageView>(Resource.Id.civHomePic);
            itemView.Click += (sender, e) => listener(Position);

        }
    }



    public class HomeAdapter : RecyclerView.Adapter
    {

        public event EventHandler<int> itemClick;
        public home mHome;

        public HomeAdapter(home home)
        {

            mHome = home;
        }

        public override int ItemCount
        {
            get
            {
                return mHome.numHome;
            }
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            HomeViewHolder vh = holder as HomeViewHolder;
            vh.notificationCaption.Text = mHome[position].notificationCaption;
            vh.notificationTime.Text = mHome[position].notificationTime;
            vh.notificationIcon.SetImageResource(mHome[position].notificationIcon);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.home_recycler, parent, false);
            HomeViewHolder vh = new HomeViewHolder(itemView, Onclick);
            return vh;
        }

        private void Onclick(int obj)
        {
            if (itemClick != null)
            {
                itemClick(this, obj);
            }
        }
    }


    


}

