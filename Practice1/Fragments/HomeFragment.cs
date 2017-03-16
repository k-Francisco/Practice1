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

namespace Practice1.Fragments
{
    public class HomeFragment : Fragment
    {

        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        home mHome;
        HomeAdapter mHomeAdapter; 

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            View rootView = inflater.Inflate(Resource.Layout.fragment_home, container, false);

            mHome = new home();
            mRecyclerView = rootView.FindViewById<RecyclerView>(Resource.Id.rvHome);
            mLayoutManager = new LinearLayoutManager(rootView.Context);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            mHomeAdapter = new HomeAdapter(mHome);
            mHomeAdapter.itemClick += MAdapter_ItemClick;
            mRecyclerView.SetAdapter(mHomeAdapter);
            
            return rootView;
            


        }

        private void MAdapter_ItemClick(object sender, int e)
        {
            Log.Info("Home Notification", "item clicked at position " + e);
        }
    }
}