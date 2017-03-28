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

namespace Practice1.Fragments
{
    class DeleteDialog : DialogFragment
    {
        private MainActivity main;
        private Button mCancel, mDelete;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.dialog_delete, container, false);
            mCancel = rootView.FindViewById<Button>(Resource.Id.btnCancel);
            mCancel.Click += delegate {
                this.Dismiss();
            };
            return rootView;
        }

        internal void setParentActivity(MainActivity mainActivity)
        {
            this.main = mainActivity;
        }
    }
}