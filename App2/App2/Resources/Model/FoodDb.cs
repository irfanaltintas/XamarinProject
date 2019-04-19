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
using SQLite;

namespace App2.Resources.Model
{
    public class FoodDb
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }   
        public string Foodname { get; set; }
        public string NofPerson { get; set; }
        public string MoreDetail { get; set; }
        public string Address { get; set; }
    }
}