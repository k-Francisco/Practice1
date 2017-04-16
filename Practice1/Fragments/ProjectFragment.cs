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
using Practice1.Models;

namespace Practice1.Fragments
{
    public class ProjectFragment : Fragment
    {

        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        project mProject;
        ProjectAdaper mProjectAdapter;
        ListItemModels projectList;
        


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


            projectList = (Activity as MainActivity).getList();
            for (int i = 0; i < projectList.D.Results.Length; i++) {
                mProject.addProject(
                    projectList.D.Results[i].Title,
                    projectList.D.Results[i].Start,
                    projectList.D.Results[i].Finish,
                    projectList.D.Results[i].percentComplete,
                    projectList.D.Results[i].Work,
                    projectList.D.Results[i].Duration);
            }

            mProjectAdapter = new ProjectAdaper(mProject, (Activity as MainActivity));
            mProjectAdapter.itemClick += MAdapter_ItemClick;
            mRecyclerView.SetAdapter(mProjectAdapter);

            return rootView;

            
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            Log.Info("Project Notification", "item clicked at position " + e);
        }

        public void addProject(string projectName, string start, string end, string percent, string work, string duration) {

            mProject.addProject(projectName, start, end, percent, work, duration);
            mProjectAdapter.NotifyDataSetChanged();
        }

        
    }
}