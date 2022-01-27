using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace udemy_xamarin
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
public partial class PaginaPrincipal : FlyoutPage
{
    public PaginaPrincipal()
    {
        InitializeComponent();
            App.Menu = this;
            App.Navigate = Navigate;

    }
}
}