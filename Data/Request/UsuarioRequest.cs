using System.ComponentModel.DataAnnotations;

namespace Alquilandome.Data.Request;
using System.ComponentModel.DataAnnotations.Schema;
    // Clase Usuario
    public class UsuarioRequest
    {
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "El nombre no puede superar las 20 letras"), 
        MinLength(3, ErrorMessage = "El nombre no puede tener menos de tres letras"), 
        Required(ErrorMessage = "El nombre del usuario es obligatorio")]
        public string Nombre { get; set; } = null!;
        [MaxLength(20, ErrorMessage = "El apellido no puede superar las 20 letras"), 
        MinLength(3, ErrorMessage = "El apellido no puede tener menos de tres letras"), 
        Required(ErrorMessage = "El apellido del usuario es obligatorio")]
        public string Nickname { get; set; } = null!;
        [MaxLength(12, ErrorMessage = "La clave no puede tener mas de 12 digitos"), 
        MinLength(8, ErrorMessage = "La clave no puede tener menos de 8 digitos"), 
        Required(ErrorMessage = "La clave del usuario es obligatoria")]
        public string Password { get; set; } = null!;
        [EmailAddress(ErrorMessage = "Esto no es un correo valido"), 
        Required(ErrorMessage = "El correo del usuario es obligatorio")]
        public string Email { get; set; } = null!;
        public string? Rol { get; set; }
    }


