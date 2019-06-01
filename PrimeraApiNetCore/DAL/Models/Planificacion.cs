using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Planificacion
    {
        DateTime _fecha;

        [Required]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Fecha {
            get { return _fecha; }
            set { _fecha = value; }
        }

        [Required]
        public TipoPlanificacion TipoPlanificacion { get; set; }

        [Required]
        public int CalendarioId { get; set; }

        public Calendario Calendario { get; set; }

        public List<PlanificacionReceta> PlanificacionesRecetas { get; set; }


    }

    public enum TipoPlanificacion
    {
        Desayuno,
        Comida,
        Cena
    }
}
