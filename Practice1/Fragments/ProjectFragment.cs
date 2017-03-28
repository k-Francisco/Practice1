using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Support.V4.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Support.V7.Widget;
using Practice1.Adapters;
using Practice1.Activities;

namespace Practice1.Fragments
{
    public class ProjectFragment : Fragment
    {

        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        project mProject;
        ProjectAdaper mProjectAdapter;
        MainActivity main;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View rootView = inflater.Inflate(Resource.Layout.fragment_project, container, false);

            mProject = new project();
            mRecyclerView = rootView.FindViewById<RecyclerView>(Resource.Id.rvProject);
            mLayoutManager = new LinearLayoutManager(rootView.Context);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            mProjectAdapter = new ProjectAdaper(mProject, main);
            mProjectAdapter.itemClick += MAdapter_ItemClick;
            mRecyclerView.SetAdapter(mProjectAdapter);

            return rootView;

            
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            Log.Info("Project Notification", "item clicked at position " + e);
        }

        internal void setParentActivity(MainActivity mainActivity)
        {
            this.main = mainActivity;
        }
    }
}