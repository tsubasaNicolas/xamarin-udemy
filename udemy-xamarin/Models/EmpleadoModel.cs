using System;
using System.Collections.Generic;
using System.Text;
using udemy_xamarin.Entidades;
using udemy_xamarin.Generic;

namespace udemy_xamarin.Models
{
    public class EmpleadoModel : BaseBinding
    {
        private List<EmpleadoCLS> _listaempleado;
        public List<EmpleadoCLS> listaempleado
        {
            get { return _listaempleado; }
            set { SetValue(ref _listaempleado, value); }
        }

        private List<string> _listaTipoContrato;
        public List<string> listaTipoContrato
        {
            get { return _listaTipoContrato; }
            set { SetValue(ref _listaTipoContrato, value); }
        }


        private EmpleadoCLS _oEmpleadoCLS;
        public EmpleadoCLS oEmpleadoCLS
        {
            get { return _oEmpleadoCLS; }
            set { SetValue(ref _oEmpleadoCLS, value); }
        }

        private List<EmpleadoGroup> _listaempleadoagrupada;
        public List<EmpleadoGroup> listaempleadoagrupada
        {
            get { return _listaempleadoagrupada; }
            set { SetValue(ref _listaempleadoagrupada, value); }
        }

        private string _texto;
        public string texto
        {
            get { return _texto; }
            set { SetValue(ref _texto, value); }
        }

        private bool _cargando;
        public bool cargando
        {
            get { return _cargando; }
            set { SetValue(ref _cargando, value); }
        }


    }
}
