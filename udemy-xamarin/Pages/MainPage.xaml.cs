using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy_xamarin;
using Xamarin.Forms;

namespace udemy_xamarin
{
    public partial class MainPage : ContentPage
    {

        public string nombreusuario { get; set; }
        public string contra { get; set; }

        public MainPage()
        {
            InitializeComponent();
            nombreusuario = "nicolas";
            contra = "1234";
            BindingContext = this;
        }

        private void btnIniciar_Clicked(object sender, EventArgs e)
        {
            if (nombreusuario == "nicolas" && contra == "1234")
                //Navigation.PushAsync(new PaginaPrincipal());
                Application.Current.MainPage = new PaginaPrincipal();
            else
                DisplayAlert("Error", "Usuario o clave incorrecta", "Cancelar");
        }

        private void btnRegistrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PaginaRegistro());
        }
    }
}
