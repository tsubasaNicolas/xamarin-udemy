using System;
using System.Collections.Generic;
using System.Text;
using udemy_xamarin.Entidades;
using udemy_xamarin.Generic;

namespace udemy_xamarin.Models
{
   public class MenuModel : BaseBinding
    {

        private List<MenuCLS> _listamenu;
        public List<MenuCLS> listamenu
        {
            get { return _listamenu; }
            set { SetValue(ref _listamenu, value); }
        }





    }
}
