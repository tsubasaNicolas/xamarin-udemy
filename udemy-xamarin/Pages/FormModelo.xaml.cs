using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace udemy_xamarin.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class FormModelo : ContentPage
{
        public string tituloForm { get; set; }
    public FormModelo(string titulo)
    {
        InitializeComponent();
            tituloForm = titulo;
            BindingContext = this;
    }

        private void btnRegresar_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}