using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace DAL.Models
{
    public class Receta
    {
        public Receta()
        {
            Puntuacion = 0;
        }

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Error en el tamaño del campo", MinimumLength = 3)]
        public string Nombre { get; set; }

        [Range(0,5)]
        public int Puntuacion { get; set; }

        public List<RecetaUsuario> RecetasUsuarios { get; set; }

        public List<PlanificacionReceta> PlanificacionesRecetas { get; set; }
    }
}