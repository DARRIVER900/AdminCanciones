using System.ComponentModel.DataAnnotations;

namespace AdminCanciones.Components.Data
{
    public class Cancion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El titulo es obligatorio")]
        [StringLength(20, ErrorMessage = "El titulo no puede exceder los 20 caracteres")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "La duracion es obligatoria")]
        [StringLength(10, ErrorMessage = "La duracion no puede exceder los 10 caracteres")]
        public string? Duracion { get; set; }

        public int AlbumId { get; set; }
        virtual public Album? Album { get; set; }
    }
}
