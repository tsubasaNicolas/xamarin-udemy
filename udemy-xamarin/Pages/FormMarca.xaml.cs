using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy_xamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using udemy_xamarin.Generic;

namespace udemy_xamarin.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class FormMarca : ContentPage
{
        public string tituloForm { get; set; }
        private string urlMarca;

        public MarcaModel oMarcaModel { get; set; } = new MarcaModel();

     //   public MarcaCLS oMarcaCLS { get; set; }

        public FormMarca(string titulo, MarcaCLS obj)
    {
        InitializeComponent();
            urlMarca = GenericLH.getValueKey("GetMarca");
            tituloForm = titulo;
           
            BindingContext = this;
            oMarcaModel.oMarcaCLS = obj;
        }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

        private async void btnAceptar_Clicked(object sender, EventArgs e)
        {
            string opcion = await DisplayActionSheet("Desea guardar los datos?", "Cancelar", null, "Sí", "No");
            if (opcion == "No") return;

            int rpta = await GenericLH.Post<MarcaCLS>
                (urlMarca, oMarcaModel.oMarcaCLS);
            if(rpta == 1)
            {
             // await  DisplayAlert("Ok", "Se guardó correctamente", "Cancelar");
                Marca.getInstance().listarMarca();
               await  Navigation.PopAsync();

            }
            else
            {
                await DisplayAlert("Error", "Ocurrió un error", "Cancelar");
            }

        }
    }
}