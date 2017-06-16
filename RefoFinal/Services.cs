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
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace RefoFinal
{
    public class Services
    {
        MobileServiceClient clienteServicio = new MobileServiceClient(@"https://refofinal.azurewebsites.net/");
        private IMobileServiceTable<Zonas> _ZonaItemTable;

        public async Task BuscarZonas()
        {
            _ZonaItemTable = clienteServicio.GetTable<Zonas>();
            System.Collections.Generic.List<Zonas> items = await _ZonaItemTable.ToListAsync();
        }

        
    }
}