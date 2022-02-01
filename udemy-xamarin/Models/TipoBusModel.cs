using udemy_xamarin.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using udemy_xamarin.Generic;

namespace udemy_xamarin.Models
{
    public class TipoBusModel: BaseBinding
{

        private List<TipoBusCLS> _listatipobus;
        public List<TipoBusCLS> listatipobus
        {
            get { return _listatipobus; }
            set { SetValue(ref _listatipobus, value); }
        }


        private TipoBusCLS _oTipoBusCLS;
        public TipoBusCLS oTipoBusCLS
        {
            get { return _oTipoBusCLS; }
            set { SetValue(ref _oTipoBusCLS, value); }
        }

        private TipoBusCLS _oTipoBusRecuperarCLS;
        public TipoBusCLS oTipoBusRecuperarCLS
        {
            get { return _oTipoBusRecuperarCLS; }
            set { SetValue(ref _oTipoBusRecuperarCLS, value); }
        }

        private string _titulo;

        public string titulo
        {
            get { return _titulo; }
            set { SetValue(ref _titulo, value); }
        }
        public bool _cargando;
        public bool cargando
        {
            get { return _cargando; }
            set { SetValue(ref _cargando, value); }
        }

        private int _numeroregistro;
        public int numeroregistro
        {
            get { return _numeroregistro; }
            set { SetValue(ref _numeroregistro, value); }
        }

    }
}
