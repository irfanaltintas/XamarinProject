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
using App2.Resources.Model;
using Java.Lang;

namespace App2.Resources
{
    public class ViewHolder : Java.Lang.Object
    {
        public TextView txtName;
        public TextView txtNumber;

        public TextView txtDet;


    }
   public class ListViewAdapter:BaseAdapter
    {
        private Activity activity;
        private List<FoodDb> foodDbs;

        public ListViewAdapter(Activity activity, List<FoodDb> foodDbs)
        {
            this.activity = activity;
            this.foodDbs = foodDbs;
        }

        public override int Count
        {
            get
            {
                return foodDbs.Count;
            }
        }

        public override Java.Lang.Object GetItem(int position)
        {
            return null;
        }

        public override long GetItemId(int position)
        {
            return foodDbs[position].id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.listViewDataTemplate, parent, false);
            var txtName = view.FindViewById<TextView>(Resource.Id.textView1);
            var txtNumber = view.FindViewById<TextView>(Resource.Id.textView2);
            var txtDet = view.FindViewById<TextView>(Resource.Id.textView3);
            var txtAddress = view.FindViewById<TextView>(Resource.Id.textView4);
           

            txtName.Text = foodDbs[position].Foodname;
            txtNumber.Text = foodDbs[position].NofPerson;
            txtDet.Text = foodDbs[position].MoreDetail;
            txtAddress.Text = foodDbs[position].Address;

            return view;
        }
    }
}