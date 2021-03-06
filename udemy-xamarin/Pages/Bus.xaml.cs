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
public partial class Bus : ContentPage
{
        public static Bus instance;
        private string urlBus;
        private string urlTipoBus;
        private List<BusCLS> lista;
        public static Bus getInstance()
        {
            if (instance == null) return new Bus();
            else return instance;
        }

        public BusModel oBusModel { get; set; } = new BusModel();
        public Bus()
    {
            urlBus = GenericLH.getValueKey("GetBus");
            urlTipoBus = GenericLH.getValueKey("GetTipoBus");
            instance = this;
            InitializeComponent();
            oBusModel.listabus = new List<BusCLS>();
            BindingContext = this;
            listarListas();
           // listarFiltro();
    }
      //  private async void listarFiltro()
      //{
      // List<TipoBusCLS> listatipobus=   await GenericLH.GetAll<TipoBusCLS>("http://nicolascarrasco-001-site1.dtempurl.com/api/TipoBus");
      //    listatipobus.Insert(0, new TipoBusCLS { iidtipobus = 0, nombre = "--Todos--" });
         // oBusModel.listaTipoBus = listatipobus.Select(p => p.nombre).ToList();
         // oBusModel.itemSeleccionado = "--Todos--";
     // }
        public async void listarListas()
        {
            oBusModel.cargando = true;
            oBusModel.listabus = await GenericLH.GetAll<BusCLS>(urlBus);
            oBusModel.cargando = false;
            lista = oBusModel.listabus;
            oBusModel.numeroregistro = lista.Count;
            oBusModel.filtroMensaje = "Se muestra todos los registros";
            List<TipoBusCLS> listatipobus = await GenericLH.GetAll<TipoBusCLS>(urlTipoBus);
            listatipobus.Insert(0, new TipoBusCLS { iidtipobus = 0, nombre = "--Todos--" });
            oBusModel.listaTipoBus = listatipobus.Select(p => p.nombre).ToList();
            oBusModel.itemSeleccionado = "--Todos--";
        }

        private void toolbarVer_Clicked(object sender, EventArgs e)
        {
            List<int> listaEnteros = oBusModel.listabus.Where(p => p.isMarcado == true).Select(p => p.iidbus).ToList();
            if(listaEnteros.Count==0)
            {
                DisplayAlert("Error", "Debe marcar una opción", "Cancelar");
                return;
            }
           Navigation.PushAsync(new VerBus(listaEnteros));
        }

        private async  void toolbarNuevo_Clicked(object sender, EventArgs e)
        {
         //   BusPickerCLS oBusPickerCLS = new BusPickerCLS();
           // oBusPickerCLS.listaMarca = await GenericLH.GetAll<MarcaCLS>("http://nicolascarrasco-001-site1.dtempurl.com/api/Marca");
            //oBusPickerCLS.listaModelo = await GenericLH.GetAll<ModeloCLS>("http://nicolascarrasco-001-site1.dtempurl.com/api/Modelo");
            //oBusPickerCLS.listaTipoBus = await GenericLH.GetAll<TipoBusCLS>("http://nicolascarrasco-001-site1.dtempurl.com/api/TipoBus");
            //oBusPickerCLS.listaSucursal = await GenericLH.GetAll<SucursalCLS>("http://nicolascarrasco-001-site1.dtempurl.com/api/Sucursal");
          
            await Navigation.PushAsync(new FormBus("Nuevo Bus", null));
        }

        private void chkMarcado_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CheckBox oCheckBox = sender as CheckBox;
            Frame oFrame = (Frame)oCheckBox.Parent.Parent;
           // oFrame.BackgroundColor = Color.Orange;

            if (oFrame.BackgroundColor == Color.White)
            {

            oFrame.BackgroundColor = Color.Orange;
            }
            else
            {
                oFrame.BackgroundColor = Color.White;
            }

        }

        private async void btnEditar_Clicked(object sender, EventArgs e)
        {
            Button oButton = sender as Button;
            BusCLS oBusCLS = oButton.BindingContext as BusCLS;
            int iidbus = oBusCLS.iidbus;
          
            await Navigation.PushAsync(new FormBus("Editar Bus", null, iidbus));

        }

        private async void btnEliminar_Clicked(object sender, EventArgs e)
        {
            string opcion = await DisplayActionSheet("Desea guardar los datos?", "Cancelar", null, "Sí", "No");
            if (opcion == "No") return;
            Button oButton = sender as Button;
            BusCLS oBusCLS = oButton.BindingContext as BusCLS;
            int iidbus = oBusCLS.iidbus;
            int rpta = await GenericLH.Delete(urlBus+"/" + iidbus);
            if (rpta == 1)
            {
                await  DisplayAlert("Exito", "Se eliminó correctamente", "Cancelar");
                Bus.getInstance().listarListas();
                //await Navigation.PopAsync();

            }
            else
            {
                await DisplayAlert("Error", "Ocurrió un error", "Cancelar");
            }

        }

        private void pickerTipoBus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcionSeleccionado = oBusModel.itemSeleccionado;
            // DisplayAlert("Exito", opcionSeleccionado, "Cancelar");
            if (opcionSeleccionado != "--Todos--")
            {
                List<BusCLS> listaFiltrada = lista.Where(p => p.nombretipobus == opcionSeleccionado).ToList();
                oBusModel.listabus = listaFiltrada;

            }
            else
            {
                oBusModel.listabus = lista;
                oBusModel.filtroMensaje = "Se realizó el filtro por el campo nombre tipo bus que sea igual a "+opcionSeleccionado;
            }
            oBusModel.numeroregistro = oBusModel.listabus.Count;
            oBusModel.filtroMensaje = "Se muestra todos los registros";

        }
    }
}