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

namespace App2
{
    [Activity(Label = "LoginActivity")]
    public class LoginActivity : Activity
    {
        private FragmentManager manager;
        private GiveOrderDialog dialog;
        TextView txtMainPage;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_main);
            // Create your application here
            txtMainPage = FindViewById<TextView>(Resource.Id.txtContent);

            FindViewById<TextView>(Resource.Id.txtContent).Text = txtMainPage.Text + " : " + Intent.GetStringExtra("name") ?? "Receiving Data";

            var btnGiveOrder = FindViewById<Button>(Resource.Id.btnGiveOrder);
            var btnTakeOrder = FindViewById<Button>(Resource.Id.btnTakeOrder);
            var btnSeeNeighbour = FindViewById<Button>(Resource.Id.btnSeeNeighbours);

            btnGiveOrder.Click += BtnGiveOrder_Click;
            btnTakeOrder.Click += BtnTakeOrder_Click;
            btnSeeNeighbour.Click += BtnSeeNeighbour_Click;
            manager = this.FragmentManager;
            dialog = new GiveOrderDialog();
        }

        private void BtnSeeNeighbour_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(SeeNeighboursActivity));
        }

        private void BtnTakeOrder_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(GvOrderActivity));
        }

        private void BtnGiveOrder_Click(object sender, EventArgs e)
        {
            dialog.Show(manager, "Menu");
        }
    }
}