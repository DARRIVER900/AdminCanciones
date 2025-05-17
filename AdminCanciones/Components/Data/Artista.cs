using System.ComponentModel.DataAnnotations;

namespace AdminCanciones.Components.Data
{
    public class Artista
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(20, ErrorMessage = "El nombre no puede exceder los 20 caracteres")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La nacionalidad es obligatoria")]
        [StringLength(20, ErrorMessage = "La nacionalidad no puede exceder los 20 caracteres")]
        public string? Nacionalidad { get; set; }

        virtual public ICollection<Album>? Albumes { get; set; }
    }
}
