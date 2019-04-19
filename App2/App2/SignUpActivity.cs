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
    [Activity(Label = "SignUpActivity")]
    public class SignUpActivity : DialogFragment
    {
        EditText txtNewUsername;
        EditText txtNewPassword;
        EditText txtEmail;
        Button btnRegister;
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = inflater.Inflate(Resource.Layout.SignUpPage, container, false);

            // Create your application here
            txtNewUsername = view.FindViewById<EditText>(Resource.Id.txtNewUsername);
            txtNewPassword = view.FindViewById<EditText>(Resource.Id.txtNewPassword);
            txtEmail = view.FindViewById<EditText>(Resource.Id.txtNewEmail);
            btnRegister = view.FindViewById<Button>(Resource.Id.btnRegister);


            btnRegister.Click += BtnRegister_Click;
            return view;
        }
        private void BtnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "User.db");
                var db = new SQLiteConnection(dbPath);

                db.CreateTable<User>();
                User user = new User();
                user.Username = txtNewUsername.Text;
                user.Password = txtNewPassword.Text;
                user.Email = txtEmail.Text;

                db.Insert(user);
                Toast.MakeText(Context, "success", ToastLength.Short).Show();

            }
            catch (Exception ex)
            {
                Toast.MakeText(Context, "fail", ToastLength.Short).Show();

            }
        }
    }
}