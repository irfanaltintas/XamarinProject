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
using App2.Resources.Model;
using SQLite;

namespace App2
{
    [Activity(Label = "SeeNeighboursActivity")]
    public class SeeNeighboursActivity : Activity
    {
        string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "Foods.db");

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.NeighboursView);

            TextView txtNeighbour = FindViewById<TextView>(Resource.Id.txtSeeNeighbours);

            var db = new SQLiteConnection(dbPath);
            var table = db.Table<FoodDb>();
            foreach (var item in table)
            {
                FoodDb food = new FoodDb();
                item.Address = food.Address;
                txtNeighbour.Text = food + "\n";
            }
        }
    }
}