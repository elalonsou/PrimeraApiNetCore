using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class RecetaUsuario
    {
        [Required]
        public int RecetaId { get; set; }

        [Required]
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public Receta Receta { get; set; }

        [Required]
        public bool Propietario { get; set; }
    }
}
