//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GestionAulasFacultad.ModeloBD
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_clase
    {
        public int id { get; set; }
        public Nullable<int> id_profesor { get; set; }
        public Nullable<int> id_aula { get; set; }
        public int id_materia { get; set; }
        public int cantidad_horas { get; set; }
        public System.DateTime fecha_hora_inicio { get; set; }
    
        public virtual tb_aula tb_aula { get; set; }
        public virtual tb_profesor tb_profesor { get; set; }
    }
}
