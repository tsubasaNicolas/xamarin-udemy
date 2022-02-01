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
public partial class TipoBus : ContentPage
{
    public TipoBusModel oTipoBusModel { get; set; } = new TipoBusModel();
        private string urlTipoBus;
        public TipoBus()
    {
            urlTipoBus = GenericLH.getValueKey("GetTipoBus");
            InitializeComponent();
            oTipoBusModel.titulo = "Agregar Tipo Bus";
            oTipoBusModel.oTipoBusCLS = new TipoBusCLS();
            BindingContext = this;
            listarTipoBus();
            
    }
        private  async void listarTipoBus()
        {
            oTipoBusModel.cargando = true;
            oTipoBusModel.listatipobus = await GenericLH.GetAll<TipoBusCLS>(urlTipoBus);
            oTipoBusModel.cargando = false;
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {

            string opcion = await DisplayActionSheet("Desea guardar los datos?", "Cancelar", null, "Sí", "No");
            if (opcion == "No") return;
            int rpta = await GenericLH.Post<TipoBusCLS>(urlTipoBus,
                oTipoBusModel.oTipoBusCLS);
            if(rpta==1)
            {
                await DisplayAlert("Ok", "Se guardó correctamente", "Cancelar");
                listarTipoBus();
                oTipoBusModel.oTipoBusCLS = new TipoBusCLS();
            }
            else
            {
                await DisplayAlert("Error", "Ocurrió un error", "Cancelar");
            }

        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            oTipoBusModel.oTipoBusCLS = new TipoBusCLS();
            oTipoBusModel.titulo = "Agregar Tipo Bus";
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (oTipoBusModel.oTipoBusCLS.nombre == "" || oTipoBusModel.oTipoBusCLS.nombre == null) oTipoBusModel.titulo = "Agregar Tipo Bus";
            else oTipoBusModel.titulo = "Editar Tipo Bus " + oTipoBusModel.oTipoBusCLS.nombre;
        }

        private void toolbarRegistrar_Clicked(object sender, EventArgs e)
        {
            oTipoBusModel.oTipoBusCLS = new TipoBusCLS();
            oTipoBusModel.titulo = "Agregar Tipo Bus";


        }

        private async void toolbarEliminar_Clicked(object sender, EventArgs e)
        {
            int iidtipobus = oTipoBusModel.oTipoBusCLS.iidtipobus;
            if(iidtipobus==0)
            {
                await DisplayAlert("Error", "Seleccione el elemento a eliminar", "Cancelar");
                return;
            }

            string opcion = await DisplayActionSheet("Desea eliminar el registro?", "Cancelar", null, "Si", "No");
            if (opcion == "No") return;
           int rpta=  await GenericLH.Delete(urlTipoBus+"/" + iidtipobus);
            if (rpta == 1)
            {
                await DisplayAlert("Ok", "Se eliminó correctamente", "Cancelar");
                listarTipoBus();
                oTipoBusModel.oTipoBusCLS = new TipoBusCLS();
            }
            else
            {
                await DisplayAlert("Error", "Ocurrió un error", "Cancelar");
            }
        }
    }
}