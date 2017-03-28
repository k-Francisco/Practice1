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
using Android.Util;


namespace Practice1.Fragments
{
    class EditDialog : DialogFragment
    {
        private MainActivity main;
        private EditText mStartDate, mEndDate;


        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View rootView = inflater.Inflate(Resource.Layout.dialog_edit, container, false);
            mStartDate = rootView.FindViewById<EditText>(Resource.Id.etStartDate);
            mEndDate = rootView.FindViewById<EditText>(Resource.Id.etEndDate);
            mStartDate.Click += (sender, e) => {
                Log.Info("DatePicker2", "" + sender);
                DateTime today = DateTime.Today;
                Android.App.DatePickerDialog dialog = new Android.App.DatePickerDialog(main, OnStartDateSet, today.Year, today.Month - 1, today.Day);
                dialog.DatePicker.MinDate = today.Millisecond;
                dialog.Show();

            };

            mEndDate.Click += (sender, e) => {
                Log.Info("DatePicker2", "" + sender);
                DateTime today = DateTime.Today;
                Android.App.DatePickerDialog dialog = new Android.App.DatePickerDialog(main, OnEndDateSet, today.Year, today.Month - 1, today.Day);
                dialog.DatePicker.MinDate = today.Millisecond;
                dialog.Show();
            };
            
            return rootView;
        }

        private void OnEndDateSet(object sender, Android.App.DatePickerDialog.DateSetEventArgs e)
        {
            string monthz = getNameOfMonth(e.Month+1);
            mEndDate.Text = monthz + " " + e.DayOfMonth + ", " + e.Year;

        }

        private string getNameOfMonth(int month)
        {
            string nameOfMonth = "";
            switch (month)
            {
                case 1: nameOfMonth = "January";
                    break;
                case 2: nameOfMonth = "February";
                    break;
                case 3: nameOfMonth = "March";
                    break;
                case 4: nameOfMonth = "April";
                    break;
                case 5: nameOfMonth = "May";
                    break;
                case 6: nameOfMonth = "June";
                    break;
                case 7: nameOfMonth = "July";
                    break;
                case 8: nameOfMonth = "August";
                    break;
                case 9: nameOfMonth = "September";
                    break;
                case 10: nameOfMonth = "October";
                    break;
                case 11: nameOfMonth = "November";
                    break;
                case 12: nameOfMonth = "December";
                    break;
            }

            return nameOfMonth;
        }

        private void OnStartDateSet(object sender, Android.App.DatePickerDialog.DateSetEventArgs e)
        {
            string monthz = getNameOfMonth(e.Month+1);
            mStartDate.Text = monthz + " " + e.DayOfMonth + ", " + e.Year;
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
        }

        internal void setParentActivity(MainActivity mainActivity)
        {
            this.main = mainActivity;
        }
    }
}