using System;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V7.Widget;
using Android.Views;
using Practice1.Adapters;
using Android.Support.Design.Widget;
using Android.Util;
using Practice1.Helper;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Practice1.Activities;
using Practice1.Models;

namespace Practice1.Fragments
{
    public class Fragment1 : Fragment
    {
        RecyclerView mRecyclerView;
        RecyclerView.LayoutManager mLayoutManager;
        taskCompilation mPhotoAlbum;
        PhotoAlbumAdapter mAdapter;
        ListItemModels myLists;
       

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.fragment1, container, false);

            //var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            mPhotoAlbum = new taskCompilation();
            mRecyclerView = rootView.FindViewById<RecyclerView>(Resource.Id.recyclerView);
            mLayoutManager = new LinearLayoutManager(rootView.Context);
            mRecyclerView.SetLayoutManager(mLayoutManager);
            mAdapter = new PhotoAlbumAdapter(mPhotoAlbum);
            mAdapter.itemClick += MAdapter_ItemClick;

            for (int i = 0; i<myLists.D.Results.Length;i++) {
                mPhotoAlbum.addPhotos(myLists.D.Results[i].Title, myLists.D.Results[i].TaskName, myLists.D.Results[i].Date, myLists.D.Results[i].HoursRendered);
            }

            mRecyclerView.SetAdapter(mAdapter);
            
            return rootView;
        }

        internal void setParentActivity(ListItemModels list)
        {
            myLists = list;
        }

        private void MAdapter_ItemClick(object sender, int position)
        {
            int photoNum = position + 1;
            Log.Info("adapter function","item clicked");
        }

        internal void addTasks()
        {
            mPhotoAlbum.addPhotos("HelloWorld", "asdasd", "2017-03-23T07:00:00Z", "7");
            mAdapter.NotifyDataSetChanged();
        }
    }
}