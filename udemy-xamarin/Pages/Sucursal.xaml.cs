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
public partial class Sucursal : ContentPage
{

        public SucursalModel oSucursalModel { get; set; } = new SucursalModel();

        public static Sucursal instance;
        private List<SucursalCLS> lista;
        private List<SucursalCLS> elementosSeleccionados;
        private string urlSucursal;
        public static Sucursal getInstance()
        {
            if (instance == null) return new Sucursal();
            else return instance;
        }




        public Sucursal()
    {
            urlSucursal = GenericLH.getValueKey("GetSucursal");
            instance = this;
            oSucursalModel.listasucursal = new List<SucursalCLS>();
            InitializeComponent();
            BindingContext = this;
            listarSucursal();
            refreshSucursal.Command = new Command(() =>
            {
                listarSucursal();
            });
    }
        public async void listarSucursal()
        {
            oSucursalModel.cargando = true;
            oSucursalModel.listasucursal =
            await GenericLH.GetAll<SucursalCLS>(urlSucursal);
            oSucursalModel.cargando = false;
            lista = oSucursalModel.listasucursal;
            oSucursalModel.numeroregistro = lista.Count;
            oSucursalModel.filtroMensaje = "Se muestra todos los registros";
        }

        private void toolbarRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FormSucursal("Registrar Sucursal", new SucursalCLS()));
        }

        private void toolbarVer_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VerSucursal("Ver Sucursal", elementosSeleccionados));
        }

        private void swipeEditar_Clicked(object sender, EventArgs e)
        {
            SwipeItem oSwipeItem = sender as SwipeItem;
            SucursalCLS oSucursalCLS = oSwipeItem.BindingContext as SucursalCLS;
            Navigation.PushAsync(new FormSucursal("Editar Sucursal", oSucursalCLS));
        }

        private async void swipeEliminar_Clicked(object sender, EventArgs e)
        {
            SwipeItem oSwipeItem = sender as SwipeItem;
            SucursalCLS oSucursalCLS = oSwipeItem.BindingContext as SucursalCLS;
            int iidsucursal = oSucursalCLS.iidsucursal;
            string opcion = await DisplayActionSheet("Desea guardar los datos?", "Cancelar", null, "Sí", "No");
            if (opcion == "No") return;
           int rpta= await GenericLH.Delete(urlSucursal+"/" + iidsucursal);
            if (rpta == 1) listarSucursal();
            else await DisplayAlert("Error", "Ocurrió un error", "Cancelar");
        }



        private void collectionSucursal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            elementosSeleccionados  = e.CurrentSelection.Select(p => p as SucursalCLS).ToList();
        }

        private void searchSucursal_SearchButtonPressed(object sender, EventArgs e)
        {
            SearchBar oSearchBar = sender as SearchBar;
            string textoEscrito = oSearchBar.Text;
            List<SucursalCLS> listafiltrada = lista.Where(p => p.nombre.ToUpper().Contains(textoEscrito.ToUpper())).ToList();
            oSucursalModel.numeroregistro = listafiltrada.Count;
            oSucursalModel.listasucursal = listafiltrada;
            if (textoEscrito == "") oSucursalModel.filtroMensaje = "Se muestra todos los registros";
            else oSucursalModel.filtroMensaje = "Se muestra los registros filtrados por la columna Nombre " +
                    "de aquellos cuyo texto ' " + textoEscrito + "' está incluido en su valor";


            // DisplayAlert("Valor", textoEscrito, "Cancelar");
        }
    }
}