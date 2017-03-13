using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;

using Practice1.Fragments;
using Android.Support.V7.App;
using Android.Support.V4.View;
using Android.Support.Design.Widget;
using Android.Content;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Practice1.Helper;
using System;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.Collections.Generic;
using Practice1.Adapters;
using Practice1.Models;
using Android.Util;

namespace Practice1.Activities
{
    [Activity(Label = "Home", MainLauncher = true, LaunchMode = LaunchMode.SingleTop, Icon = "@drawable/Icon")]
    public class MainActivity : BaseActivity
    {
        private static Fragment1 projects;
        private static Fragment2 tasks;
        private static string siteUrl = "https://sharepointevo.sharepoint.com/sites/mobility";
        private static string restUrl = "/_api/web/lists/getbytitle('MobilePractice')/items";
        ListItemModels myList;
        AuthenticationResult authResult;
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        FloatingActionButton addItems;

        protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            AuthenticationAgentContinuationHelper.SetAuthenticationAgentContinuationEventArgs(requestCode, resultCode, data);
        }

        protected override int LayoutResource
        {
            get
            {
                return Resource.Layout.main;
            }
        }

        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            await login();
            await fetchItems();

            projects = new Fragment1();
            tasks = new Fragment2();
            projects.setParentActivity(myList);
     
            drawerLayout = this.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            //Set hamburger items menu
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);

            //setup navigation view
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);

            //handle navigation
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);

                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_home_1:
                        switchFragment(0);
                        break;
                    case Resource.Id.nav_home_2:
                        switchFragment(1);
                        break;
                }

                Snackbar.Make(drawerLayout, "You selected: " + e.MenuItem.TitleFormatted, Snackbar.LengthLong)
                    .Show();

                drawerLayout.CloseDrawers();
            };

            addItems = FindViewById<FloatingActionButton>(Resource.Id.fab);
            addItems.Click += async delegate
            {
                await addListItems();
                projects.addTasks();
            };


            //if first time you will want to go ahead and click first item.
            if (savedInstanceState == null)
            {
                SupportFragmentManager.BeginTransaction()
               .Add(Resource.Id.content_frame, projects)
               .AddToBackStack(null)
               .Commit();
            }
        }



        public async Task<Boolean> login()
        {
            authResult = await AuthenticationHelper.GetAccessToken(AuthenticationHelper.SharePointURL, new PlatformParameters(this));
            return true;
        }

        protected async Task<Boolean> addListItems()
        {

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", authResult.AccessToken);
            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            mediaType.Parameters.Add(new NameValueHeaderValue("odata", "verbose"));
            client.DefaultRequestHeaders.Accept.Add(mediaType);

            var projectName = "HelloWorld";
            var taskName = "asdasd";
            var date = "2017-03-23T07:00:00Z";
            var hoursRendered = 7;
            var body = "{\"__metadata\":{\"type\":\"SP.Data.MobilePracticeListItem\"},\"Title\":\"" + projectName + "\",\"TaskName\": \"" + taskName + "\",\"Date\": \"" + date + "\",\"HoursRendered\": \"" + hoursRendered + "\"}";
            var contents = new StringContent(body);
            contents.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");


            try
            {
                var postResult = await client.PostAsync(siteUrl+restUrl, contents);
                var result = postResult.EnsureSuccessStatusCode();
                if (result.IsSuccessStatusCode)
                    Toast.MakeText(this, "List item created succesfully", ToastLength.Long).Show();

                return true;
            }
            catch (Exception ex)
            {
                var msg = "Unable to create list item. " + ex.Message;
                Toast.MakeText(this, msg, ToastLength.Long).Show();
                return false;
            }



            
        }

        protected async Task<Boolean> fetchItems()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authResult.AccessToken);
            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            mediaType.Parameters.Add(new NameValueHeaderValue("odata", "verbose"));
            client.DefaultRequestHeaders.Accept.Add(mediaType);

            try
            {
                var result = await client.GetStringAsync(siteUrl+restUrl);
                var data = JsonConvert.DeserializeObject<Practice1.Models.ListItemModels>(result);
                myList = data;
                
            }
            catch(Exception ex) {
                var msg = "Unable to fetch list items. " + ex.Message;
                Toast.MakeText(this, msg, ToastLength.Long).Show();
                Log.Info("resource id", msg);
            }

            return true;
        }

        public void switchFragment(int position) {

            switch (position) {
                case 0:
                     SupportFragmentManager.BeginTransaction()
                    .Replace(Resource.Id.content_frame, projects)
                    .AddToBackStack(null)
                    .Commit();
                    break;
                case 1:
                     SupportFragmentManager.BeginTransaction()
                    .Replace(Resource.Id.content_frame, tasks)
                    .AddToBackStack(null)
                    .Commit();
                    break;
            }

        }

        

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;
            }
            return base.OnOptionsItemSelected(item);
        }


        public override void OnBackPressed()
        {
            base.OnBackPressed();
        }

    }
}

