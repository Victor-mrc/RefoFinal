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
    [Activity(Label = "ListaArticulosActivity")]
    public class ListaArticulosActivity : ListActivity
    {
      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.ListaArticulos);

            List<Articulo> LstArticulos = new AccesoDatos().ObtenArticulos();
            List<string> items = new List<string>();
            foreach (var item in LstArticulos)
            {
                items.Add(item.Nombre);
            }

            ListAdapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, items);
        }
    }
}