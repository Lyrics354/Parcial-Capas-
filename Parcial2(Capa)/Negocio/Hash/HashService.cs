using System;
using System.Security.Cryptography;
using System.Text;
using Negocio.Interfaces;

namespace Negocio
{
    /// <summary>
    /// Implementa los contratos de hash usando SHA-512, el mismo algoritmo
    /// con el que están guardadas las contraseñas en la tabla usuarios.
    /// </summary>
    public class HashService : IHashService, IVerificarHashService
    {
        /// <inheritdoc />
        public string GenerarHash(string textoPlano)
        {
            if (textoPlano == null)
            {
                throw new ArgumentNullException(nameof(textoPlano));
            }

            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] bytes = sha512.ComputeHash(Encoding.UTF8.GetBytes(textoPlano));
                return BitConverter.ToString(bytes).Replace("-", "");
            }
        }

        /// <inheritdoc />
        public bool Verificar(string textoPlano, string hashAlmacenado)
        {
            if (textoPlano == null || string.IsNullOrEmpty(hashAlmacenado))
            {
                return false;
            }

            return string.Equals(GenerarHash(textoPlano), hashAlmacenado,
                StringComparison.OrdinalIgnoreCase);
        }
    }
}
