using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy_xamarin.Generic;
using udemy_xamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace udemy_xamarin.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class Marca : ContentPage
{
		//  public List<MarcaCLS> listamarca { get; set; }
		public static Marca instance;
		private string urlMarca;
		public static Marca getInstance()
        {
			if (instance == null) return new Marca();
			else return instance;
        }


		public MarcaModel oMarcaModel { get; set; } = new MarcaModel();

		public string valor { get; set; }
		private List<MarcaCLS> lista;
		public Marca()
    {
			urlMarca = GenericLH.getValueKey("GetMarca");
			instance = this;

			oMarcaModel.listamarca = new List<MarcaCLS>();

			listarMarca();

			
			BindingContext = this;
			
			InitializeComponent();
			refreshMarca.Command = new Command(() =>
			{
				listarMarca();
			});
		}
		public async void listarMarca()
        {
			//string urlMarca = App.Current.Resources["GetMarca"].ToString();
			oMarcaModel.cargando = true;
			oMarcaModel.listamarca =
				await GenericLH.GetAll<MarcaCLS>(urlMarca);
			oMarcaModel.cargando = false;
			lista = oMarcaModel.listamarca;
			oMarcaModel.numeroregistro = lista.Count;
			oMarcaModel.filtroMensaje = "Se muestra todos los registros";
		}


		private void toolbarRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FormMarca("Registrar Marca", new MarcaCLS()));
        }

        private void collectionMarca_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
			MarcaCLS oMarcaCLS = e.CurrentSelection[0] as MarcaCLS;
			//DisplayAlert("Aviso", oMarcaCLS.nombre, "Cancelar");
			Navigation.PushAsync(new FormMarca("Editar Marca", oMarcaCLS));
		}

        private void searchNombre_TextChanged(object sender, TextChangedEventArgs e)
        {
			SearchBar oSearchBar = (SearchBar)sender;
			string textoEscrito = oSearchBar.Text;
			if (textoEscrito == "") oMarcaModel.filtroMensaje = "Se muestra todos los registros";
			else oMarcaModel.filtroMensaje = "Se muestra los registros filtrados por la columna Nombre " +
					"de aquellos cuyo texto ' " + textoEscrito + "' está incluido en su valor";

			oMarcaModel.listamarca = lista.Where(p => p.nombre.ToUpper().Contains(textoEscrito.ToUpper())).ToList();
			oMarcaModel.numeroregistro = oMarcaModel.listamarca.Count;
		//	DisplayAlert("Aviso", "se activo", "cancelar");


        }

        private async void swipeEliminar_Clicked(object sender, EventArgs e)
        {

			SwipeItem oSwipeItem = sender as SwipeItem;
			MarcaCLS oMarcaCLS = oSwipeItem.BindingContext as MarcaCLS;
			int iidmarca = oMarcaCLS.idmarca;
			int rpta =  await GenericLH.Delete(urlMarca+"/" + iidmarca);
			if(rpta ==0)
            {
				listarMarca();
            }
            else
            {
				await DisplayAlert("Error", "Ocurrió un error", "Cancelar");
            }
        }
    }
}