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
public partial class Modelo : ContentPage
{

        public ModeloModel oModeloModel { get; set; } = new ModeloModel();

        private string urlModelo;
        public Modelo()
    {
            urlModelo = GenericLH.getValueKey("GetModelo");
            InitializeComponent();
            BindingContext = this;
            oModeloModel.oModeloRecuperarCLS = new ModeloCLS();
            oModeloModel.oModeloCLS= new ModeloCLS();
            oModeloModel.titulo = "Agregar nuevo modelo";
            listarModelo();
            refreshModelo.Command = new Command(() =>
             {
                 listarModelo();
             });
    }
        private async void listarModelo()
        {
            oModeloModel.cargando = true;
            oModeloModel.listamodelo = await GenericLH.GetAll<ModeloCLS>(urlModelo);
            oModeloModel.cargando = false;
        }
        private void toolbarRegistrar_Clicked(object sender, EventArgs e)
        {
            oModeloModel.oModeloRecuperarCLS = new ModeloCLS();
            oModeloModel.titulo = "Agregar nuevo modelo";

            // Navigation.PushAsync(new FormModelo("Registrar Modelo"));

        }

        private void toolbarVer_Clicked(object sender, EventArgs e)
        {
            if (oModeloModel.oModeloCLS.iidmodelo == 0)
            {
                DisplayAlert("Aviso", "Debe seleccionar una fila", "Cancelar");
                return;
            }

            oModeloModel.oModeloRecuperarCLS =oModeloModel.oModeloCLS;
            oModeloModel.titulo = "Editar modelo "+ oModeloModel.oModeloRecuperarCLS.nombre;
            // Navigation.PushAsync(new FormModelo("Ver Modelo"));
            //DisplayAlert("Exito", oModeloModel.oModeloCLS.nombre, "Cancelar");
        }

        private async void btnGuardar_Clicked(object sender, EventArgs e)
        {
            string opcion = await DisplayActionSheet("Desea guardar los datos?", "Cancelar", null, "Sí", "No");
            if (opcion == "No") return;
            int rpta = await GenericLH.Post<ModeloCLS>(urlModelo,
                 oModeloModel.oModeloRecuperarCLS);
            if(rpta == 1)
            {
                await DisplayAlert("Ok", "Se guardó correctamente", "Cancelar");
                oModeloModel.oModeloRecuperarCLS = new ModeloCLS();
                oModeloModel.titulo = "Agregar nuevo modelo";
                listarModelo();
                //no quiero que esté seleccionado ninguno
                oModeloModel.oModeloCLS = new ModeloCLS();
            }
            else
            {
                await DisplayAlert("Error", "Ocurrió un error", "Cancelar");
             
            }


        }

        private void btnCancelar_Clicked(object sender, EventArgs e)
        {
            oModeloModel.oModeloCLS = new ModeloCLS();
            oModeloModel.oModeloRecuperarCLS = new ModeloCLS();
            oModeloModel.titulo = "Agregar nuevo modelo";

        }

        private  async void toolbarEliminar_Clicked(object sender, EventArgs e)
        {
            string opcion = await DisplayActionSheet("Desea eliminar los datos?", "Cancelar", null, "Sí", "No");
            if (opcion == "No") return;

            int id = oModeloModel.oModeloCLS.iidmodelo;
            if (id == 0)
            {
               await  DisplayAlert("Aviso", "Debe seleccionar una fila", "OK");
                return;
            }
            int rpta = await GenericLH.Delete(urlModelo+"/" + id);
                if(rpta==1)
            {
                await DisplayAlert("Ok", "Se eliminó correctamente", "OK");
                oModeloModel.oModeloRecuperarCLS = new ModeloCLS();
                oModeloModel.titulo = "Agregar nuevo modelo";
                listarModelo();
                //no quiero que esté seleccionado ninguno
                oModeloModel.oModeloCLS = new ModeloCLS();
            }
            else
            {
                await DisplayAlert("Error", "Ocurrió un error", "Cancelar");

            }
        }
    }
}