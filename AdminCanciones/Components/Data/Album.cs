using System.ComponentModel.DataAnnotations;
namespace AdminCanciones.Components.Data
{
    public class Album
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El titulo es obligatorio")]
        [StringLength(20, ErrorMessage = "El titulo no puede exceder los 20 caracteres")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "El año es obligatorio")]
        [StringLength(20, ErrorMessage = "El año no puede exceder los 20 caracteres")]
        public string? Año { get; set; }

        public int ArtistaId { get; set; }
        virtual public Artista? Artista { get; set; }
        virtual public ICollection<Cancion>? Canciones { get; set; }
    }
}