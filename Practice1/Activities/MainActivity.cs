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
    [Activity(Label = "Home", Theme = "@style/MyTheme")]
    public class MainActivity : BaseActivity
    {
        //setting statics
        private static Fragment1 tasks = new Fragment1();
        private static Fragment2 tasks2 = new Fragment2();
        private static HomeFragment home = new HomeFragment();
        private static ProjectFragment projects = new ProjectFragment();
        private static string siteUrl = "https://sharepointevo.sharepoint.com/sites/mobility";
        private static string restUrl = "/_api/web/lists/getbytitle('Projects')/items";
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
        ListItemModels projectsList;
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
            //await fetchPractice();
            //await addProjects();
            //await checkInProject();
            //await checkOutProject();


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
                        addItems.SetVisibility(ViewStates.Visible);
                        FabFunctions(1);
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
           

            //add parent activity to fragments
            resourceDialog.setParentActivity(this);
            editDialog.setParentActivity(this);
            deleteDialog.setParentActivity(this);

            SupportFragmentManager.BeginTransaction()
                .Add(Resource.Id.content_frame, home)
                .Commit();

        }

        private void FabFunctions(int v)
        {
            string projectName = "", start = "", end = "", percent = "", work = "", duration = "";
            EditText mProjectName, mStart, mEnd, mPercent, mWork, mDuration;
            DatePicker mDatePicker;
            DateTime today;
            
            

            switch (v) {

                case 1:
                    addItems.Click += delegate {
                        View view = LayoutInflater.Inflate(Resource.Layout.builder_add_project, null);
                        Android.App.AlertDialog builder = new Android.App.AlertDialog.Builder(this).Create();
                        builder.SetView(view);
                  

                        mProjectName = view.FindViewById<EditText>(Resource.Id.builderProjectName);
                        mStart = view.FindViewById<EditText>(Resource.Id.builderStart);
                        mEnd = view.FindViewById<EditText>(Resource.Id.builderEnd);
                        mPercent = view.FindViewById<EditText>(Resource.Id.builderProgress);
                        mWork = view.FindViewById<EditText>(Resource.Id.builderWork);
                        mDuration = view.FindViewById<EditText>(Resource.Id.builderDuration);


                        builder.SetCanceledOnTouchOutside(false);
                        builder.SetButton2("Submit", async delegate
                        {
                            projectName = mProjectName.Text;
                            start = mStart.Text;
                            end = mEnd.Text;
                            percent = mPercent.Text + " %";
                            work = mWork.Text + " hrs";
                            duration = mDuration.Text + " day(s)";
                            await addListItems(projectName, start, end, percent, work, duration);
                            
                        }); 
                        builder.SetButton3("Cancel", delegate { builder.Dismiss(); });


                        mStart.Click += (sender, e) =>{

                           Android.Support.V7.App.AlertDialog builder2 = new Android.Support.V7.App.AlertDialog.Builder(this).Create();
                            View view2 = LayoutInflater.Inflate(Resource.Layout.date_picker, null);
                            builder2.SetView(view2);

                            mDatePicker = FindViewById<DatePicker>(Resource.Id.datePicker);

                            builder2.SetButton(-1,"OK", delegate {
                                //mStart.Text = mDatePicker.Month + "/" + mDatePicker.DayOfMonth + "/" + mDatePicker.Year;
                            });
                            builder2.SetButton(-2, "Cancel", delegate { });
                            builder2.Show();
                        };



                        builder.Show();
                    };

                    

                    //addItems.Click += async delegate { await addListItems(projectName, start, end, percent, work, duration); };
                    break;

            }
         
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


        protected async Task<Boolean> addListItems(string projectName, string start, string end, string percent, string work, string duration)
        {

            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("bearer", authResult.AccessToken);
            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            mediaType.Parameters.Add(new NameValueHeaderValue("odata", "verbose"));
            client.DefaultRequestHeaders.Accept.Add(mediaType);


            //var body = "{\"__metadata\":{\"type\":\"SP.Data.ProjectsListItem\"},\"Title\":\"" + projectName + "\",\"_x0025_Complete\": \"" + percent + "\",\"Work\": \"" + work + "\",\"Duration\": \"" + duration + "\"}";
            //var body = "{\"__metadata\":{\"type\":\"SP.Data.ProjectsListItem\"},\"Title\":\"" + projectName +
            //    "\",\"Start\": \"" + start +
            //    "\",\"Finish\": \"" + end +
            //    "\",\"percentComplete\": \"" + percent +
            //    "\",\"Work\": \"" + work +
            //    "\",\"Duration\": \"" + duration +
            //    "\"}";

            var body = "{\"__metadata\":{\"type\":\"SP.Data.ProjectsListItem\"},\"Title\":\"" + projectName +
                "\",\"percentComplete\": \"" + percent +
                "\",\"Work\": \"" + work +
                "\",\"Duration\": \"" + duration +
                "\"}";


            var contents = new StringContent(body);
            contents.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json;odata=verbose");


            try
            {
                var postResult = await client.PostAsync(siteUrl + restUrl, contents);
                var result = postResult.EnsureSuccessStatusCode();
                if (result.IsSuccessStatusCode)
                    Toast.MakeText(this, "List item created succesfully", ToastLength.Long).Show();
                projects.addProject(projectName, start, end, percent, work, duration);
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

                var postResult = await client.PostAsync(siteUrl + projectServerRestUrl + "/Add", contents);
                var result = postResult.EnsureSuccessStatusCode();
                if (result.IsSuccessStatusCode)
                    Toast.MakeText(this, "Project created succesfully", ToastLength.Long).Show();

                Log.Info("add Project", "naka create na");
            }
            catch (Exception ex) {

                var msg = "Unable to create project. " + ex.Message;
                Toast.MakeText(this, msg, ToastLength.Long).Show();

                Log.Info("add Project", "wa ka create kay " + msg);
            }

            return true;
        }


        protected async Task<Boolean> checkInProject() {
            var rest = "/_api/ProjectServer/Projects/('10003')/Draft/CheckIn()";
            var formDigest = await GetFormDigest();

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");


            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, siteUrl + rest);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);
            

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Toast.MakeText(this, "success siya", ToastLength.Short);
                Log.Info("check in", "success");
            }
            else
            {
                Toast.MakeText(this, "wa jd ka", ToastLength.Short);
                
                Log.Info("check in", "failed kay " + response.StatusCode.ToString());
            }


            return true;
        }

        public async Task<Boolean> checkOutProject() {

            var rest = "/_api/ProjectServer/Projects/('10003')/CheckOut()";

            var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json;odata=verbose");


            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, siteUrl + rest);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

            HttpResponseMessage response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Toast.MakeText(this, "success siya", ToastLength.Short);
                Log.Info("check out", "success");
            }
            else
            {
                Toast.MakeText(this, "wa jd ka", ToastLength.Short);
                Log.Info("check out", "failed kay "+ response.StatusCode.ToString());
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
                var result = await client.GetStringAsync(siteUrl+restUrl);
                Log.Info("Project JSON",result);
                var data = JsonConvert.DeserializeObject<Practice1.Models.ListItemModels>(result);
                projectsList = data;

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

        public ListItemModels getList() {
            return projectsList;
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

