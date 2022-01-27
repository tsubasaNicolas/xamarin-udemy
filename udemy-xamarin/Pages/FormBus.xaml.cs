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
public partial class FormBus : ContentPage
{
        private BusPickerCLS oBusPickerCLS;
        public BusModel oBusModel { get; set; } = new BusModel();
        public string tituloForm { get; set; }
      /* public List<string> listaSucursal { get; set; }
        public List<string> listaModelo { get; set; }
        public List<string> listaTipoBus { get; set; }
        public List<string> listaMarca { get; set; }
      */

        public FormBus(string titulo, BusPickerCLS oBusPickerCLS, int iidbus=0)
    {
            InitializeComponent();
            tituloForm = titulo;
            oBusModel.oBusCLS = new BusCLS();
          

            BindingContext = this;
           
                recuperarBus(iidbus);
            
           
    }
        public async void recuperarBus(int iidbus)
        {
            oBusPickerCLS = new BusPickerCLS();
            oBusPickerCLS.listaMarca = await GenericLH.GetAll<MarcaCLS>("http://nicolascarrasco-001-site1.dtempurl.com/api/Marca");
            oBusPickerCLS.listaModelo = await GenericLH.GetAll<ModeloCLS>("http://nicolascarrasco-001-site1.dtempurl.com/api/Modelo");
            oBusPickerCLS.listaTipoBus = await GenericLH.GetAll<TipoBusCLS>("http://nicolascarrasco-001-site1.dtempurl.com/api/TipoBus");
            oBusPickerCLS.listaSucursal = await GenericLH.GetAll<SucursalCLS>("http://nicolascarrasco-001-site1.dtempurl.com/api/Sucursal");
            oBusPickerCLS.listaMarca.Insert(0, new MarcaCLS { idmarca = 0, nombre = "--Seleccione--" });
            oBusPickerCLS.listaModelo.Insert(0, new ModeloCLS { iidmodelo = 0, nombre = "--Seleccione--" });
            oBusPickerCLS.listaTipoBus.Insert(0, new TipoBusCLS { iidtipobus = 0, nombre = "--Seleccione--" });
            oBusPickerCLS.listaSucursal.Insert(0, new SucursalCLS { iidsucursal = 0, nombre = "--Seleccione--" });
            oBusModel.listaSucursal = oBusPickerCLS.listaSucursal.Select(p => p.nombre).ToList();
            oBusModel.listaModelo = oBusPickerCLS.listaModelo.Select(p => p.nombre).ToList();
            oBusModel.listaTipoBus = oBusPickerCLS.listaTipoBus.Select(p => p.nombre).ToList();
            oBusModel.listaMarca = oBusPickerCLS.listaMarca.Select(p => p.nombre).ToList();
            if (iidbus != 0)
                oBusModel.oBusCLS = await GenericLH.Get<BusCLS>("http://nicolascarrasco-001-site1.dtempurl.com/api/bus/" + iidbus);
            else
            {
                BusCLS oBusCLS = new BusCLS();
                oBusCLS.nombremarca = "--Seleccione--";
                oBusCLS.nombremodelo = "--Seleccione--";
                oBusCLS.nombresucursal = "--Seleccione--";
                oBusCLS.nombretipobus = "--Seleccione--";
                oBusModel.oBusCLS = oBusCLS;

            }       
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void btnAceptar_Clicked(object sender, EventArgs e)
        {
            string opcion = await DisplayActionSheet("Desea guardar los datos?", "Cancelar", null, "Sí", "No");
            if (opcion == "No") return;

            oBusModel.oBusCLS.iidmarca = oBusPickerCLS.listaMarca.Where(p => p.nombre == oBusModel.oBusCLS.nombremarca).First().idmarca;
                oBusModel.oBusCLS.iidsucursal= oBusPickerCLS.listaSucursal.Where(p => p.nombre == oBusModel.oBusCLS.nombresucursal).First().iidsucursal;
            oBusModel.oBusCLS.iidmodelo= oBusPickerCLS.listaModelo.Where(p => p.nombre == oBusModel.oBusCLS.nombremodelo).First().iidmodelo;
            oBusModel.oBusCLS.iidtipobus= oBusPickerCLS.listaTipoBus.Where(p => p.nombre == oBusModel.oBusCLS.nombretipobus).First().iidtipobus;

            int rpta = await GenericLH.Post<BusCLS>
               ("http://nicolascarrasco-001-site1.dtempurl.com/api/bus", oBusModel.oBusCLS);
            if (rpta == 1)
            {
                // await  DisplayAlert("Ok", "Se guardó correctamente", "Cancelar");
                Bus.getInstance().listarBus();
                await Navigation.PopAsync();

            }
            else
            {
                await DisplayAlert("Error", "Ocurrió un error", "Cancelar");
            }
        }
    }
}