using System;
using System.Collections.Generic;

namespace secondParcial.Model
{
    public partial class Usuario
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = null!;
        public string Legajo { get; set; } = null!;
        public bool Activo { get; set; }
        public byte[] PasswordHash { get; set; } = null!;
        public byte[] PasswordSalt { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public string? Apellido { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string? UrlImagen { get; set; }
        public Guid IdRol { get; set; }
        public string? Telefono { get; set; }
        public string? Calle { get; set; }
        public string? Numero { get; set; }
        public string? CodPost { get; set; }
        public string? Provincia { get; set; }
        public string? Ciudad { get; set; }
        public string? Dni { get; set; }
        public string? DatosVarios { get; set; }
        public DateTime? FechaNacimiento { get; set; }

        public virtual Role IdRolNavigation { get; set; } = null!;
    }
}
