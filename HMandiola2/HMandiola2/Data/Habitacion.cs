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
    
    public partial class Habitacion
    {
        public Habitacion()
        {
            this.Reserva_Habitacion = new HashSet<Reserva_Habitacion>();
        }
    
        public int ID_Habitacion { get; set; }
        public int NumeroHabitacion { get; set; }
        public string Estado { get; set; }
        public int CantidadPersonas { get; set; }
        public Nullable<int> CamasIndividuales { get; set; }
        public Nullable<int> CamasMatrimoniales { get; set; }
        public string Observaciones { get; set; }
        public string Imagen { get; set; }
        public string Tipo_Habitacion { get; set; }
    
        public virtual ICollection<Reserva_Habitacion> Reserva_Habitacion { get; set; }
    }
}