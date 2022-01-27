using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy_xamarin.Entidades;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace udemy_xamarin.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class VerSucursal : ContentPage
{

        public List<SucursalCLS> listasucursal { get; set; }

        public string titulobarra { get; set; }

        public int numeroregistro { get; set; }
    public VerSucursal(string titulo, List<SucursalCLS> lista)
    {
            InitializeComponent();
            listasucursal = lista;
            titulobarra = titulo;
            numeroregistro = lista.Count;
            BindingContext = this;
    }
}
}