using Android.App;
using Android.Widget;
using Android.OS;
using System;
using Android.Views;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace RefoFinal
{
    [Activity(Label = "RefoFinal", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        Button BtnLogin;
        const string applicationURL = @"https://refofinal.azurewebsites.net";
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            BtnLogin = FindViewById<Button>(Resource.Id.BtnLogin);

            client = new MobileServiceClient(applicationURL);
            BtnLogin.Click += BtnLogin_Click;

            Plugin.Connectivity.CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;
        }

        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            if (Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                Toast.MakeText(this, "Conectado a Internet", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "No hay una conexión disponible", ToastLength.Long).Show();
            }

        }

        private async void BtnLogin_Click(object sender, System.EventArgs e)
        {
            if (!Plugin.Connectivity.CrossConnectivity.Current.IsConnected)
            {
                Toast.MakeText(this, "No hay una conexión disponible, verifica la conexión a internet", ToastLength.Long).Show();
                return;
            }
            
            if (await Authenticate())
            {
                StartActivity(typeof(MenuActivity));
            }
            else
            {
                Toast.MakeText(this, "Datos incorrectos!", ToastLength.Long).Show();
            }
        }


        private MobileServiceUser user;
        private MobileServiceClient client;

        private async Task<bool> Authenticate()
        {
            var success = false;
            try
            {
                // Sign in with Facebook login using a server-managed flow.
                user = await client.LoginAsync(this,
                    MobileServiceAuthenticationProvider.Facebook);
                CreateAndShowDialog(string.Format("you are now logged in - {0}",
                    user.UserId), "Logged in!");

                success = true;
            }
            catch (Exception ex)
            {
                CreateAndShowDialog(ex, "Authentication failed");
            }
            return success;
        }

        private void CreateAndShowDialog(Exception exception, String title)
        {
            CreateAndShowDialog(exception.Message, title);
        }

        private void CreateAndShowDialog(string message, string title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();
        }


    }
}

