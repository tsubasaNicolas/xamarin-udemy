using udemy_xamarin.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using udemy_xamarin.Generic;

namespace udemy_xamarin.Models
{
    public class ModeloModel: BaseBinding
{
        private List<ModeloCLS> _listamodelo;
        public List<ModeloCLS> listamodelo
        {
            get { return _listamodelo; }
            set { SetValue(ref _listamodelo, value); }
        }


        private ModeloCLS _oModeloCLS;
        public ModeloCLS oModeloCLS
        {
            get { return _oModeloCLS; }
            set { SetValue(ref _oModeloCLS, value); }
        }

        private ModeloCLS _oModeloRecuperarCLS;
        public ModeloCLS oModeloRecuperarCLS
        {
            get { return _oModeloRecuperarCLS; }
            set { SetValue(ref _oModeloRecuperarCLS, value); }
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
