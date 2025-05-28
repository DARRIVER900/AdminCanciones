using System.ComponentModel.DataAnnotations;

namespace AdminCanciones.Components.Data
{
    public class Playlist

    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El titulo es obligatorio")]
        [StringLength(20, ErrorMessage = "El titulo no puede exceder los 20 caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La descripcion es obligatoria")]
        [StringLength(100, ErrorMessage = "La descripcion no puede exceder los 100 caracteres")]
        public string? Descripcion { get; set; }

        public ICollection<Cancion>? Canciones { get; set; }
    }
}

