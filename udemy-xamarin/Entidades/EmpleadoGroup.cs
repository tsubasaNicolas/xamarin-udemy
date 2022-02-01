using System;
using System.Collections.Generic;
using System.Text;

namespace udemy_xamarin.Entidades
{
    public class EmpleadoGroup:List<EmpleadoCLS>
{
        public string nombreGrupo { get; set; }

        public EmpleadoGroup(string NombreGrupo, List<EmpleadoCLS>l):base(l)
        {
            nombreGrupo = NombreGrupo;
        }
}
}
