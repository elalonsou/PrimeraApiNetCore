using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Calendario
    {
        [Required]
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "Error en el tamaño del campo", MinimumLength = 3)]
        [Required]
        public string Nombre { get; set; }

        public List<Planificacion> Planificaciones { get; set; }

        public List<CalendarioUsuario> CalendariosUsuarios { get; set; }
    }
}
