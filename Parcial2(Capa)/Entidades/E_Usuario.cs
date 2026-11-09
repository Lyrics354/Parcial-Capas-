using System;

namespace Entidades
{
    /// <summary>
    /// Representa un registro de la tabla usuarios.
    /// </summary>
    public class E_Usuario
    {
        /// <summary>Identificador numérico del usuario.</summary>
        public int id { get; set; }

        /// <summary>Identificador alterno del usuario.</summary>
        public string dsId { get; set; }

        /// <summary>Nombre con el que inicia sesión.</summary>
        public string dsUsuario { get; set; }

        /// <summary>Hash de la contraseña en hexadecimal. Nunca contiene el texto plano.</summary>
        public string dsPassword { get; set; }

        /// <summary>Estado del usuario: '1' significa activo.</summary>
        public char dsEstado { get; set; }

        /// <summary>Usuario que creó el registro.</summary>
        public string dsUsuarioCreacion { get; set; }

        /// <summary>Fecha de creación del registro.</summary>
        public DateTime dtFechaCreacion { get; set; }

        /// <summary>Usuario que modificó el registro por última vez.</summary>
        public string idUsuarioModificacion { get; set; }

        /// <summary>Fecha de la última modificación.</summary>
        public DateTime dtFechaModificacion { get; set; }
    }
}
