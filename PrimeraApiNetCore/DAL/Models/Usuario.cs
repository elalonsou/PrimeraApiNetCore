using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DAL.Models
{
    public class Usuario
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Error en el tamaño del campo" , MinimumLength = 3)]
        public string Nombre { get; set; }

        [StringLength(100, ErrorMessage = "Error en el tamaño del campo")]
        public string Apellidos { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Alias { get; set; }

        public List<RecetaUsuario> RecetasUsuarios { get; set; }

        public List<CalendarioUsuario> CalendariosUsuarios { get; set; }

    }
}