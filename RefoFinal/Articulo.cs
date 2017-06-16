using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite.Net.Attributes;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace RefoFinal
{
    public class Articulo
    {
        [PrimaryKey]
        public string Nombre { get; set; }
        public bool Estatus { get; set; }
        public double Peso { get; set; }
        public double Alto { get; set; }
        public double Ancho { get; set; }
    }
}