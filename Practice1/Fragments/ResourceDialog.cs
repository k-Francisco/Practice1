using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Practice1.Activities;
using Android.Support.V7.Widget;
using Practice1.Adapters;
using Android.Util;

namespace Practice1.Fragments
{

    class ResourceDialog : DialogFragment
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        resource mResource;
        ResourceAdapter mResourceAdapter;
        MainActivity main;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.resource_dialog, container, false);
            mResource = new resource();
            mRecyclerView = rootView.FindViewById<RecyclerView>(Resource.Id.rvResources);
            mLayoutManager = new LinearLayoutManager(rootView.Context);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            mResourceAdapter = new ResourceAdapter(mResource, main);
            mResourceAdapter.itemClick += MAdapter_ItemClick;
            mRecyclerView.SetAdapter(mResourceAdapter);

            return rootView;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            Log.Info("Resource Notification", "item clicked at position " + e);
        }

        internal void setParentActivity(MainActivity mainActivity)
        {
            this.main = mainActivity;
        }
    }
}