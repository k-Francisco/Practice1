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
using Android.Net;
using System.Xml.Linq;

namespace Practice1.Activities
{
    [Activity(Label = "Home", Theme ="@style/MyTheme")]
    public class MainActivity : BaseActivity
    {
        //setting statics
        private static Fragment1 tasks = new Fragment1();
        private static Fragment2 tasks2 = new Fragment2();
        private static HomeFragment home = new HomeFragment();
        private static ProjectFragment projects = new ProjectFragment();
        private static string siteUrl = "https://sharepointevo.sharepoint.com/sites/mobility";
        private static string restUrl = "/_api/web/lists/getbytitle('MobilePractice')/items";
        private static string projectServerRestUrl = "/_api/ProjectServer/Projects";
        private static string projectDataRestUrl = "/_api/ProjectData/Projects";

        //setting fragment dialogs
        private static ResourceDialog resourceDialog = new ResourceDialog();
        private static DeleteDialog deleteDialog = new DeleteDialog();
        private static EditDialog editDialog = new EditDialog();


        //setting private views
        private TextView mFullName;
        private TextView mEmail;

        //setting idk
        RootObject myList;
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

            
            
            init();
            await login();
            await fetchItems();
            await addProjects();
            
            
        }

        private void init()
        {
   
            drawerLayout = this.FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            //Set hamburger items menu
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu);

            //setup navigation view
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.SetCheckedItem(Resource.Id.nav_home_1);
            mFullName = navigationView.GetHeaderView(0).FindViewById<TextView>(Resource.Id.tvHeaderFullName);
            mEmail = navigationView.GetHeaderView(0).FindViewById<TextView>(Resource.Id.tvHeaderEmail);
            


            //handle navigation
            navigationView.NavigationItemSelected += (sender, e) =>
            {
                e.MenuItem.SetChecked(true);

                switch (e.MenuItem.ItemId)
                {
                    case Resource.Id.nav_home_1:
                        switchFragment(0);
                        SupportActionBar.SetTitle(Resource.String.Home);
                        break;
                    case Resource.Id.nav_home_2:
                        switchFragment(1);
                        SupportActionBar.SetTitle(Resource.String.Projects);
                        break;
                    case Resource.Id.nav_home_3:
                        switchFragment(2);
                        SupportActionBar.SetTitle(Resource.String.Tasks);
                        break;
                    case Resource.Id.nav_home_4:
                        SupportActionBar.SetTitle(Resource.String.Approvals);
                        break;
                    case Resource.Id.nav_home_5:
                        SupportActionBar.SetTitle(Resource.String.Timesheet);
                        break;
                    case Resource.Id.nav_home_6:
                        SupportActionBar.SetTitle(Resource.String.Settings);
                        break;
                    case Resource.Id.nav_home_7:
                        
                        break;
                    
                    
                }

                drawerLayout.CloseDrawers();
            };

            addItems = FindViewById<FloatingActionButton>(Resource.Id.fab);
            addItems.SetVisibility(ViewStates.Gone);
            addItems.Click += async delegate
            {
                await addListItems();
                //dummy.addTasks();
            };

            //add parent activity to fragments
            projects.setParentActivity(this);
            resourceDialog.setParentActivity(this);
            editDialog.setParentActivity(this);
            deleteDialog.setParentActivity(this);
    
            SupportFragmentManager.BeginTransaction()
                .Add(Resource.Id.content_frame, home)
                .Commit();

        }

        public async Task<Boolean> login()
        {
            authResult = await AuthenticationHelper.GetAccessToken(AuthenticationHelper.SharePointURL, new PlatformParameters(this));
            mFullName.Text = authResult.UserInfo.GivenName + " " + authResult.UserInfo.FamilyName;
            mEmail.Text = authResult.UserInfo.DisplayableId;
            return true;

        }

        protected async Task<string> GetFormDigest() {

            HttpClient client = new HttpClient();
            HttpRequestMessage request = new HttpRequestMessage(
                  HttpMethod.Post, siteUrl + "/_api/contextinfo");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
            HttpResponseMessage response = await client.SendAsync(request);

            string responseString = await response.Content.ReadAsStringAsync();

            XNamespace d = "http://schemas.microsoft.com/ado/2007/08/dataservices";
            var root = XElement.Parse(responseString);
            var formDigestValue = root.Element(d + "FormDigestValue").Value;

            return formDigestValue;
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
                var postResult = await client.PostAsync(siteUrl + restUrl, contents);
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


        protected async Task<Boolean> addProjects() {

            var formDigest = await GetFormDigest();

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authResult.AccessToken);
            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            mediaType.Parameters.Add(new NameValueHeaderValue("odata", "verbose"));
            //mediaType.Parameters.Add(new NameValueHeaderValue("X-RequestDigest",formDigest));
            client.DefaultRequestHeaders.Accept.Add(mediaType);
            

            


            var body = "{'parameters': {'Name': 'kristian test', 'Description': 'ftwftwftw', 'EnterpriseProjectTypeId': '1d17f2a6-94ba-e611-80d4-00155d085606'} }";
            var contents = new StringContent(body);
            contents.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");

            try {

                var postResult = await client.PostAsync(siteUrl+projectServerRestUrl+"/Add", contents);
                var result = postResult.EnsureSuccessStatusCode();
                if(result.IsSuccessStatusCode)
                    Toast.MakeText(this, "Project created succesfully", ToastLength.Long).Show();

                Log.Info("add Project","naka create na");
            }
            catch (Exception ex) {

                var msg = "Unable to create project. " + ex.Message;
                Toast.MakeText(this, msg, ToastLength.Long).Show();

                Log.Info("add Project", "wa ka create kay " + msg);
            }

            return true;
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
                var result = await client.GetStringAsync(siteUrl+projectDataRestUrl);
                Log.Info("Project JSON",result);
                //var data = JsonConvert.DeserializeObject<Practice1.Models.RootObject>(result);
                //myList = data;
               
            }
            catch(Exception ex) {
                var msg = "Unable to fetch list items. " + ex.Message;
                Toast.MakeText(this, msg, ToastLength.Long).Show();
                Log.Info("resource id", msg);
            }

            //for (int i = 0; i < myList.Feed.Entry.Count; i++)
            //{
            //    Log.Info("Project Lists", myList.Feed.Title.Text);
            //}

            return true;
        }

        


        public void switchFragment(int position) {

            switch (position) {
                case 0:
                     SupportFragmentManager.BeginTransaction()
                    .Replace(Resource.Id.content_frame, home)
                    .AddToBackStack(null)
                    .Commit();
                    break;
                case 1:
                     SupportFragmentManager.BeginTransaction()
                    .Replace(Resource.Id.content_frame, projects)
                    .AddToBackStack(null)
                    .Commit();
                    break;
                case 2:
                    SupportFragmentManager.BeginTransaction()
                        .Replace(Resource.Id.content_frame, tasks)
                        .AddToBackStack(null)
                        .Commit();
                    break;

                case 3:
                    SupportFragmentManager.BeginTransaction()
                       .Replace(Resource.Id.content_frame, tasks2)
                       .AddToBackStack(null)
                       .Commit();
                    break;
                    

                
            }

        }

        public void bringDialogs(int identifier)
        {
           //legend
           //1 - Resource dialog
           //2 = Edit dialog
           //3 - DeleteD dialog

            switch (identifier) {

                case 1:resourceDialog.Show(SupportFragmentManager.BeginTransaction(), "resource dialog");
                    break;

                case 2:editDialog.Show(SupportFragmentManager.BeginTransaction(), "edit dialog");
                    break;

                case 3:deleteDialog.Show(SupportFragmentManager.BeginTransaction(), "delete dialog");
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

