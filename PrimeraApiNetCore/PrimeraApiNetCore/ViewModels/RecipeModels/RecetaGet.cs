using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PrimeraApiNetCore.ViewModels.RecipeModels
{
    public class RecetaGet
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Error en el tamaño del campo", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Range(0, 5)]
        public int Puntuacion { get; set; }
    }
}
