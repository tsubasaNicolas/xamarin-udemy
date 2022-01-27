using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using udemy_xamarin.Entidades;
using udemy_xamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace udemy_xamarin.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class Menu : ContentPage
{
        public MenuModel oMenuModel { get; set; } = new MenuModel();
    public Menu()
    {
            oMenuModel.listamenu = new List<MenuCLS>();
            oMenuModel.listamenu.Add(new MenuCLS 
            { iidpagina = 1, 
                nombrepagina = "Marca", 
                nombreicono = "ic_marca", 
                nombreformulario = "Marca" });
            oMenuModel.listamenu.Add(new MenuCLS
            { iidpagina = 2, 
                nombrepagina = "Sucursal", 
                nombreicono = "ic_sucursal", 
                nombreformulario = "Sucursal" });
            oMenuModel.listamenu.Add(new MenuCLS
            { iidpagina = 3, 
                nombrepagina = "Bus", 
                nombreicono = "ic_bus", 
                nombreformulario = "Bus" });
            oMenuModel.listamenu.Add(new MenuCLS
            { iidpagina = 4, 
                nombrepagina = "Modelo", 
                nombreicono = "ic_modelo", 
                nombreformulario = "Modelo" });

            BindingContext = this;
            InitializeComponent();
    }

        private void collectionMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MenuCLS oMenuCLS = e.CurrentSelection[0] as MenuCLS;
            string nomform = oMenuCLS.nombreformulario;
            Page oPage = (Page)Activator.CreateInstance(Type.GetType("udemy_xamarin.Pages."+nomform));
            App.Navigate.PushAsync(oPage);
            App.Menu.IsPresented = false;
        }

        private void stackSalir_Tapped(object sender, EventArgs e)
        {
            App.Current.MainPage = new MainPage();
        }
    }
}