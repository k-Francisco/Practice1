using System;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Practice1.Activities;
using Practice1.Adapters;
using Android.Util;

namespace Practice1.Fragments
{
    public class Fragment2 : Fragment
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        task2 mTask2;
        TaskAdapter mTaskAdapter;
        MainActivity main;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public  Fragment2 NewInstance()
        {
            //var frag2 = new Fragment2 { Arguments = new Bundle() };
            return this;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.fragment2, container, false);
            main = (Activity as MainActivity);
            mTask2 = new task2();
            mRecyclerView = view.FindViewById<RecyclerView>(Resource.Id.rvTasks);
            mLayoutManager = new LinearLayoutManager(view.Context);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            mTaskAdapter = new TaskAdapter(mTask2, main);
            mTaskAdapter.itemClick += MAdapter_ItemClick;
            mRecyclerView.SetAdapter(mTaskAdapter);

            return view;
        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            Log.Info("frag2","clicked");
        }
    }
}