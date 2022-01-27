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
public partial class FormSucursal : ContentPage
{
        public string tituloForm { get; set; }

        public SucursalModel oSucursalModel { get; set; } = new SucursalModel();
    public FormSucursal(string titulo, SucursalCLS oSucursalCLS)
    {
            InitializeComponent();
            tituloForm = titulo;
            oSucursalModel.oSucursalCLS = oSucursalCLS;
            BindingContext = this;
    }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void btnAceptar_Clicked(object sender, EventArgs e)
        {
           string opcion = await DisplayActionSheet("Desea guardar los datos?", "Cancelar", null, "Sí", "No");
            if (opcion == "No") return;

            int rpta = await GenericLH.Post<SucursalCLS>("http://nicolascarrasco-001-site1.dtempurl.com/api/Sucursal", oSucursalModel.oSucursalCLS);
            if (rpta == 1)
            {
                // await  DisplayAlert("Ok", "Se guardó correctamente", "Cancelar");
                Sucursal.getInstance().listarSucursal();
                await Navigation.PopAsync();

            }
            else
            {
                await DisplayAlert("Error", "Ocurrió un error", "Cancelar");
            }

        }
    }
}