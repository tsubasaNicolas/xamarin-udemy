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
public partial class Empleado : ContentPage
{
        public static Empleado instance;
    public EmpleadoModel oEmpleadoModel { get; set; } = new EmpleadoModel();
        private List<EmpleadoCLS> listaTotal;
        private string urlEmpleado;

        public static Empleado getInstance()
        {
            if (instance == null) return new Empleado();
            else return instance;
        }

        public Empleado()
    {
            instance = this;
            urlEmpleado = GenericLH.getValueKey("GetEmpleado");
            InitializeComponent();
            listarEmpleado();
            //oEmpleadoModel.texto = "";
            oEmpleadoModel.oEmpleadoCLS = new EmpleadoCLS();
            BindingContext = this;
    }
        public async void listarEmpleado()
        {
            oEmpleadoModel.cargando = true;
            oEmpleadoModel.listaempleado = await GenericLH.GetAll<EmpleadoCLS>
                (urlEmpleado);
            oEmpleadoModel.cargando = false;
            listaTotal = oEmpleadoModel.listaempleado;
         agrupar(oEmpleadoModel.listaempleado);

        }

        private void agrupar(List<EmpleadoCLS>l)
        {
            oEmpleadoModel.listaempleadoagrupada = (from emp in l
                                                    group emp by emp.nombretipocontrato into grupo
                                                    select new EmpleadoGroup(grupo.Key, grupo.ToList())).ToList();
        }

        private void searchBusqueda_TextChanged(object sender, TextChangedEventArgs e)
        {
            string texto = oEmpleadoModel.texto;
            List<EmpleadoCLS> listafiltrada = listaTotal.Where(p => p.nombrecompleto.ToUpper().Contains(texto.ToUpper())).ToList();
            agrupar(listafiltrada);
           // DisplayAlert("Valor", oEmpleadoModel.texto, "Cancelar");

        }

        private void collectionEmpleado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int iidempleado = oEmpleadoModel.oEmpleadoCLS.iidempleado;
            if(iidempleado!=0)
                Navigation.PushAsync(new FormEmpleado("Editar Empleado"));

        }

        private void imagenNuevo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FormEmpleado("Agregar Empleado"));
        }
    }
}