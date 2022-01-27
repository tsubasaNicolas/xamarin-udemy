using System;
using System.Collections.Generic;
using System.Text;
using udemy_xamarin.Entidades;
using udemy_xamarin.Generic;

namespace udemy_xamarin.Models
{
  public class SucursalModel:BaseBinding
{
        private SucursalCLS _oSucursalCLS;

        public SucursalCLS oSucursalCLS
        {
            get { return _oSucursalCLS; }
            set { SetValue(ref _oSucursalCLS, value); }
        }

        private List<SucursalCLS> _listasucursal;
        public List<SucursalCLS> listasucursal
        {
            get { return _listasucursal; }
            set { SetValue(ref _listasucursal, value); }
        }

        private int _numeroregistro;
        public int numeroregistro
        {
            get { return _numeroregistro; }
            set { SetValue(ref _numeroregistro, value); }
        }

        private string _filtroMensaje;
        public string filtroMensaje
        {
            get { return _filtroMensaje; }
            set { SetValue(ref _filtroMensaje, value); }
        }

        private bool _cargando;
        public bool cargando
        {
            get { return _cargando; }
            set { SetValue(ref _cargando, value); }
        }


    }
}
