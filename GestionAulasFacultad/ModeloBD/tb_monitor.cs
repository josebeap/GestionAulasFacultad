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
    
    public partial class tb_monitor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_monitor()
        {
            this.tb_asistencia = new HashSet<tb_asistencia>();
            this.tb_reserva = new HashSet<tb_reserva>();
        }
    
        public int id { get; set; }
        public int id_persona { get; set; }
        public int id_programa { get; set; }
        public int id_materia { get; set; }
        public string codigo_estudiante { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_asistencia> tb_asistencia { get; set; }
        public virtual tb_materia tb_materia { get; set; }
        public virtual tb_persona tb_persona { get; set; }
        public virtual tb_programa tb_programa { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_reserva> tb_reserva { get; set; }
    }
}
