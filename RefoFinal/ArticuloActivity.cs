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

namespace RefoFinal
{
    [Activity(Label = "ArticuloActivity")]
    public class ArticuloActivity : Activity
    {
        bool Nuevo = true;
        EditText TxtNombre;
        EditText TxtPeso;
        EditText TxtAncho;
        EditText TxtAlto;
        Switch SwitchEstatus;
        ImageView ImgFoto;
        Button BtnCargarImagen;
        Button BtnSincronizar;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Articulo);
            TxtNombre = FindViewById<EditText>(Resource.Id.TxtNombre);
            TxtPeso = FindViewById<EditText>(Resource.Id.TxtPeso);
            TxtAncho = FindViewById<EditText>(Resource.Id.TxtAncho);
            TxtAlto = FindViewById<EditText>(Resource.Id.TxtAlto);
            SwitchEstatus = FindViewById<Switch>(Resource.Id.SwitchEstatus);
            ImgFoto = FindViewById<ImageView>(Resource.Id.ImgFoto);
            BtnCargarImagen = FindViewById<Button>(Resource.Id.BtnCargarImagen);
            BtnSincronizar = FindViewById<Button>(Resource.Id.BtnSincronizar);

            string Nombre = Intent.GetStringExtra("Nombre") ?? "";

            if (!string.IsNullOrEmpty(Nombre))
                Nuevo = false;

            BtnSincronizar.Click += BtnSincronizar_Click;

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

        private void BtnSincronizar_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo
            {
                Nombre = TxtNombre.Text,
                Peso = double.Parse(TxtPeso.Text),
                Ancho = double.Parse(TxtAncho.Text),
                Alto = double.Parse(TxtAlto.Text),
                Estatus = SwitchEstatus.Checked
            };

            
            var datos = new AccesoDatos();
            datos.InsertarArticulo(articulo);
                       
            Toast.MakeText(this, "Articulo Insertado Con exito", ToastLength.Long).Show();
            StartActivity(typeof(MenuActivity));
        }
    }
}