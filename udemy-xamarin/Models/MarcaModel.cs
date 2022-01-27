using System;
using System.Collections.Generic;
using System.Text;
using udemy_xamarin.Generic;

namespace udemy_xamarin.Models
{
   public class MarcaModel :BaseBinding
{
        private MarcaCLS _oMarcaCLS;

        public MarcaCLS oMarcaCLS
        {
            get { return _oMarcaCLS; }
            set { SetValue(ref _oMarcaCLS, value); }
        }

        private List<MarcaCLS> _listamarca;
        public List<MarcaCLS> listamarca
        {
            get { return _listamarca; }
            set { SetValue(ref _listamarca, value); }
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
