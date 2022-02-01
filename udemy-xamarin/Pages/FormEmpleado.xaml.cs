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
public partial class FormEmpleado : ContentPage
{
    public EmpleadoModel oEmpleadoModel { get; set; } = new EmpleadoModel();
        public string tituloForm { get; set; }
        public string urlEmpleado;
        public string urlModalidadContrato;
        private List<ModalidadContratoCLS> lista;
    public FormEmpleado(string titulo)
    {
        InitializeComponent();
            urlModalidadContrato = GenericLH.getValueKey("GetModalidadContrato");
            urlEmpleado=  GenericLH.getValueKey("GetEmpleado");
            tituloForm = titulo;
        BindingContext = this;
            oEmpleadoModel.oEmpleadoCLS = new EmpleadoCLS();
            llenarCombos(titulo);
    }
        public async void llenarCombos(string titulo)
        {
           lista = await GenericLH.GetAll<ModalidadContratoCLS>(urlModalidadContrato);
            lista.Insert(0, new ModalidadContratoCLS { iidmodalidadcontrato = 0, nombre = "--Seleccione--" });
            oEmpleadoModel.listaTipoContrato = lista.Select(p=>p.nombre).ToList();
            oEmpleadoModel.oEmpleadoCLS= new EmpleadoCLS { nombretipocontrato = "--Seleccione--"};
        }

        private async void btnAceptar_Clicked(object sender, EventArgs e)
        {
            string opcion = await DisplayActionSheet("Desea guardar los datos?", "Cancelar", null, "Sí", "No");
            if (opcion == "No") return;
            string textoNombreContrato = oEmpleadoModel.oEmpleadoCLS.nombretipocontrato;
            oEmpleadoModel.oEmpleadoCLS.iidtipocontrato = lista.Where(p => p.nombre == textoNombreContrato).First().iidmodalidadcontrato;
           int rpta=  await GenericLH.Post<EmpleadoCLS>(urlEmpleado, oEmpleadoModel.oEmpleadoCLS);
            if (rpta == 1)
            {
                // await  DisplayAlert("Ok", "Se guardó correctamente", "Cancelar");
                Empleado.getInstance().listarEmpleado();
                await Navigation.PopAsync();

            }
            else
            {
                await DisplayAlert("Error", "Ocurrió un error", "Cancelar");
            }
        }
        

        private async void btnRegresar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}