//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HMandiola2.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Actividad
    {
        public Actividad()
        {
            this.Actividad_Compra = new HashSet<Actividad_Compra>();
        }
    
        public int ID_Actividad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Cupo { get; set; }
        public int EspaciosDisponibles { get; set; }
        public string Imagen { get; set; }
    
        public virtual ICollection<Actividad_Compra> Actividad_Compra { get; set; }
    }
}