using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using SQLite;
using System;
using Android.Content;
using App2.Resources.Model;
using System.IO;

namespace App2
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        EditText txtUsername;
        EditText txtPassword;
        Button btnLogin;
        Button btnSignup;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.LoginPage);

            btnLogin = FindViewById<Button>(Resource.Id.btnSignIn);
            btnSignup = FindViewById<Button>(Resource.Id.btnSignUp);
            txtUsername = FindViewById<EditText>(Resource.Id.txtUsername);
            txtPassword = FindViewById<EditText>(Resource.Id.txtPassword);

            btnLogin.Click += BtnLogin_Click;
            btnSignup.Click += BtnSignup_Click;
            CreateDatabase();
        }

        private void BtnSignup_Click(object sender, System.EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            SignUpActivity signUpActivity = new SignUpActivity();
            signUpActivity.Show(transaction, "dialog fragments");
        }

        private void BtnLogin_Click(object sender, System.EventArgs e)
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "User.db");
                var db = new SQLiteConnection(dbPath);
                var data = db.Table<User>();

                var login = data.Where(x => x.Username == txtUsername.Text && x.Password == txtPassword.Text).FirstOrDefault();

                if (login != null)
                {
                    Toast.MakeText(this, "Login Success", ToastLength.Short).Show();
                    var activity2 = new Intent(this, typeof(LoginActivity));
                    activity2.PutExtra("name", FindViewById<EditText>(Resource.Id.txtUsername).Text);
                    StartActivity(activity2);
                }
                else
                {
                    Toast.MakeText(this, "Login Failed", ToastLength.Short).Show();
                }
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
        private void CreateDatabase()
        {
            try
            {
                string dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "User.db");
                var db = new SQLiteConnection(dbPath);
            }
            catch (Exception ex)
            {
                Toast.MakeText(this, ex.ToString(), ToastLength.Short).Show();
            }
        }
    }
}