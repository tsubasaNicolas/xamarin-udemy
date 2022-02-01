using System;
using System.Collections.Generic;
using System.Text;
using udemy_xamarin.Entidades;
using udemy_xamarin.Generic;

namespace udemy_xamarin.Models
{
  public class BusModel : BaseBinding
    {

        private BusCLS _oBusCLS;

        public BusCLS oBusCLS
        {
            get { return _oBusCLS; }
            set { SetValue(ref _oBusCLS, value); }
        }

        private List<BusCLS> _listabus;
        public List<BusCLS> listabus
        {
            get { return _listabus; }
            set { SetValue(ref _listabus, value); }
        }

        private List<string> _listaSucursal;
        public List<string> listaSucursal
        {
            get { return _listaSucursal; }
            set { SetValue(ref _listaSucursal, value); }
        }

        private List<string> _listaModelo;
        public List<string> listaModelo
        {
            get { return _listaModelo; }
            set { SetValue(ref _listaModelo, value); }
        }


        private List<string> _listaTipoBus;
        public List<string> listaTipoBus
        {
            get { return _listaTipoBus; }
            set { SetValue(ref _listaTipoBus, value); }
        }

        private List<string> _listaMarca;
        public List<string> listaMarca
        {
            get { return _listaMarca; }
            set { SetValue(ref _listaMarca, value); }
        }





        private List<string> _listasucursal;
        public List<string> listasucursal
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

        private string _itemSeleccionado;
        public string itemSeleccionado
        {
            get { return _itemSeleccionado; }
            set { SetValue(ref _itemSeleccionado, value); }
        }

        private bool _cargando;
        public bool cargando
        {
            get { return _cargando; }
            set { SetValue(ref _cargando, value); }
        }

    }
}
