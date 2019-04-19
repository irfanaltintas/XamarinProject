using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using App2.Resources;
using App2.Resources.DataHelper;
using App2.Resources.Model;
using SQLite;

namespace App2
{
    [Activity(Label = "GvOrderActivity")]
    public class GvOrderActivity : Activity
    {
        ListView lstData;
        List<FoodDb> lstSource = new List<FoodDb>();
        DataBase db;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.GvOrderMain);

            db = new DataBase();
            db.createDatabase();

            string foodName = Intent.GetStringExtra("foodname" ?? "Not Recv");

            var edtFoodName = FindViewById<EditText>(Resource.Id.edtFoodName);
            var btnCreate = FindViewById<Button>(Resource.Id.btnCreate);
            var btnTake = FindViewById<Button>(Resource.Id.btnTake);
            edtFoodName.Text = foodName;

            lstData = FindViewById<ListView>(Resource.Id.listView1);
            var edtNum = FindViewById<EditText>(Resource.Id.edtNofPerson);
            var edtDet = FindViewById<EditText>(Resource.Id.edtDetails);
            var edtAddr = FindViewById<EditText>(Resource.Id.edtAddress);

            LoadData();

            btnCreate.Click += delegate
            {
                FoodDb food = new FoodDb()
                {                 
                    Foodname = edtFoodName.Text,
                    NofPerson = edtNum.Text,
                    MoreDetail = edtDet.Text,
                     Address = edtAddr.Text
                };
                db.insertIntoTableFoodDb(food);
                LoadData();
                Toast.MakeText(this, "Succeed", ToastLength.Short).Show();
            };
            btnTake.Click += delegate
            {
                FoodDb food = new FoodDb()
                {
                    id = int.Parse(edtFoodName.Tag.ToString()),               
                    Foodname = edtFoodName.Text,
                    NofPerson = edtNum.Text,
                    MoreDetail = edtDet.Text,
                    Address = edtAddr.Text
                };
                db.deleteTableFoodDb(food);
                LoadData();
                
                Toast.MakeText(this, "Succeed", ToastLength.Short).Show();
            };
            lstData.ItemClick += (s,e) =>
            {
                for (int i = 0; i < lstData.Count; i++)
                {
                    if (e.Position == i)
                        lstData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.DarkGray);
                    else
                        lstData.GetChildAt(i).SetBackgroundColor(Android.Graphics.Color.Transparent);
                }
                var txtName = e.View.FindViewById<TextView>(Resource.Id.textView1);
                var txtNumber = e.View.FindViewById<TextView>(Resource.Id.textView2);
                var txtDet = e.View.FindViewById<TextView>(Resource.Id.textView3);
                var txtAddr = e.View.FindViewById<TextView>(Resource.Id.textView4);

                
                edtFoodName.Text = txtName.Text;
                edtFoodName.Tag = e.Id;                
                edtNum.Text = txtNumber.Text;
                edtDet.Text = txtDet.Text;
                edtAddr.Text = txtAddr.Text;

            };
        }

        private void LoadData()
        {
            lstSource = db.selectTableFoodDb();
            var adapter = new ListViewAdapter(this, lstSource);
            lstData.Adapter = adapter;
        }
    }
}