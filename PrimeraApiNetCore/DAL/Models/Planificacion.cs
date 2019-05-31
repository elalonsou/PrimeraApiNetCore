using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Planificacion
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public TipoPlanificacion TipoPlanificacion { get; set; }

        [Required]
        public int CalendarioId { get; set; }

        public Calendario Calendario { get; set; }

        public List<Receta> Receta { get; set; }

    }

    public enum TipoPlanificacion
    {
        Desayuno,
        Comida,
        Cena
    }
}
