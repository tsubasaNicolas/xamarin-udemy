using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy_xamarin.Entidades;
using udemy_xamarin.Generic;
using udemy_xamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace udemy_xamarin.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class VerBus : ContentPage
{
        public BusModel oBusModel { get; set; } = new BusModel();
        public VerBus(List<int> idsARecuperar=null)
    {
            InitializeComponent();
            BindingContext = this;
            recuperarDatos(idsARecuperar);
    }

        private async void recuperarDatos(List<int>ids )
        {
            List<BusCLS> lista = new List<BusCLS>();
            oBusModel.cargando = true;
            foreach(int id in ids)
            {
                BusCLS oBusCLS = await GenericLH.Get<BusCLS>("http://nicolascarrasco-001-site1.dtempurl.com/api/bus/" + id);
                lista.Add(oBusCLS);
            }
            oBusModel.cargando = false;
            oBusModel.listabus = lista;
            oBusModel.numeroregistro = lista.Count;
        }
}
}