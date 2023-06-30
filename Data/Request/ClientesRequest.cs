using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Alquilandome.Data.Request;
    public class ClienteRequest
    {
        public int Id { get; set; }
        [MaxLength(20, ErrorMessage = "El nombre no puede superar las 20 letras"), 
        MinLength(3, ErrorMessage = "El nombre no puede tener menos de tres letras"), 
        Required(ErrorMessage = "El nombre del usuario es obligatorio")]
        public string Nombre { get; set; } = null!;
        [Required(ErrorMessage = "La cedula del cliente es obligatoria")]
        public string Cedula { get; set; } = null!;
        [Required(ErrorMessage = "El Telefono del cliente es obligatoria")]
        public string Telefono { get; set; } = null!;
        [Required(ErrorMessage = "La direccion del cliente es obligatoria")]
        public string Direccion { get; set; } = null!;
        public string? Correo { get; set; }
        public string Sexo { get; set; } = null!;
    }
