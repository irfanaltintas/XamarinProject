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

namespace App2
{
    [Activity(Label = "GiveOrderDialog")]
    public class GiveOrderDialog : DialogFragment
    {
        private ListView list;
        private String[] menu = { "Main Dish", "Dessert", "Cake", "Cookie", "Pastry" };
        ArrayAdapter adapter;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            View view = inflater.Inflate(Resource.Layout.GiveOrderView, container, false);
            this.Dialog.SetTitle("Menu");
            list = view.FindViewById<ListView>(Resource.Id.listGiveOrder);
            adapter = new ArrayAdapter(this.Activity, Android.Resource.Layout.SimpleListItem1, menu);
            list.Adapter = adapter;

            list.ItemClick += (s, e) =>
            {
                Intent nextActivity = new Intent(Context, typeof(GvOrderActivity));
                nextActivity.PutExtra("foodname", menu[e.Position]);
                StartActivity(nextActivity);
            };
            return view;
            
        }
    }
}