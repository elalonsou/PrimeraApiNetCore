using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class CalendarioUsuario
    {
        [Required]
        public int CalendarioId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public Calendario Calendario { get; set; }

        [Required]
        public bool Propietario { get; set; }
    }
}
