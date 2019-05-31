using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class PlanificacionReceta
    {
        [Required]
        public int PlanificacionId { get; set; }

        [Required]
        public int RecetaId { get; set; }

        public Receta Receta { get; set; }

        public Planificacion Planificacion { get; set; }
    }
}
