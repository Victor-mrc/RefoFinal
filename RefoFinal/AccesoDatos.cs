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
using SQLite.Net;

namespace RefoFinal
{
    public class AccesoDatos : IDisposable
    {
        private SQLiteConnection connection;

    public AccesoDatos()
    {
        //DependencyService Donde lo estoy ejecutando? deendiendo de donde se ejecute se ira al archivo config
        var plataforma = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
        var directorioDB = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            connection = new SQLiteConnection(plataforma,
            System.IO.Path.Combine(directorioDB, "Articulo.db3"));
        connection.CreateTable<Articulo>();
    }

    public void InsertarArticulo(Articulo articulo)
    {
        connection.Insert(articulo);
    }

    public void ActualizaArticulo(Articulo articulo)
    {
        connection.Update(articulo);
    }

    public void BorrarArticulo(Articulo articulo)
    {
        connection.Delete(articulo);
    }

    public Articulo ObtenArticulo(string NombreArticulo)
    {
        return connection.Table<Articulo>().FirstOrDefault(e => e.Nombre == NombreArticulo);
    }

    public List<Articulo> ObtenArticulos()
    {
        return connection.Table<Articulo>().OrderBy(e => e.Nombre).ToList();
    }

    public void Dispose()
    {
        connection.Dispose();
    }
}
}
