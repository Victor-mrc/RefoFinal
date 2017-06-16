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
    [Activity(Label = "MenuActivity")]
    public class MenuActivity : Activity
    {
        Button BtnNuevoArticulo;
        Button BtnArticulos;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.Menu);

            BtnNuevoArticulo = FindViewById<Button>(Resource.Id.BtnNuevoArticulo);
            BtnArticulos = FindViewById<Button>(Resource.Id.BtnArticulos);

            BtnNuevoArticulo.Click += BtnNuevoArticulo_Click;
            BtnArticulos.Click += BtnArticulos_Click;


        }

        private void BtnArticulos_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ListaArticulosActivity));
        }

        private void ListaArticulos_Click(object sender, EventArgs e)
        {
            //ir a activity para ver estatus
            var art = new Articulo();
            var activity2 = new Intent(this, typeof(ArticuloActivity));
            activity2.PutExtra("Nombre", art.Nombre);
            StartActivity(activity2);

        }

        private void BtnNuevoArticulo_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(ArticuloActivity));
        }

       
    }
}