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
using Android.Support.V7.App;
using Android.Content.PM;
using Android.Net;
using Android.Util;
using System.Threading;

namespace Practice1.Activities
{
    [Activity(Label = "SharePoint Mobile", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, Icon = "@drawable/Icon")]
    public class splash : AppCompatActivity
    {

        //setting privates
        private TextView mConnectionStatus;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your application here
            SetContentView(Resource.Layout.splash);


            mConnectionStatus = FindViewById<TextView>(Resource.Id.tvLoadingSplash);

            ThreadPool.QueueUserWorkItem(delegate (object state) {

                Thread.Sleep(3000);

                try
                {
                    ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
                    NetworkInfo networkInfo = connectivityManager.ActiveNetworkInfo;
                    if (networkInfo != null && networkInfo.IsConnected)
                    {
                        RunOnUiThread(() => {
                            mConnectionStatus.Text = "Loggin in...";
                        });
                        Thread.Sleep(2000);
                        Intent intent = new Intent(this, typeof(MainActivity));
                        StartActivity(intent);
                        this.Finish();
                    }
                    else
                    {
                        RunOnUiThread(()=> {
                            mConnectionStatus.Text = "Connection is unavailable. Please connect to the internet";
                        });
                       
                        Log.Info("internet", "connection failed if else");
                    }
                }
                catch (Exception ex)
                {
                    Log.Info("internet", "connection failed catched");
                }


            }, null);

            
        }
    }
}