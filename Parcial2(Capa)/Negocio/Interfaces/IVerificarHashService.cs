namespace Negocio.Interfaces
{
    /// <summary>
    /// Contrato cuya ÚNICA responsabilidad es verificar si una contraseña en
    /// texto plano coincide con el hash almacenado en la base de datos.
    /// Se usa cuando el usuario intenta iniciar sesión.
    /// </summary>
    public interface IVerificarHashService
    {
        /// <summary>
        /// Compara una contraseña en texto plano contra el hash almacenado.
        /// </summary>
        /// <param name="textoPlano">Contraseña escrita por el usuario.</param>
        /// <param name="hashAlmacenado">Hash guardado en la base de datos (hexadecimal).</param>
        /// <returns>true si coinciden; false en caso contrario.</returns>
        bool Verificar(string textoPlano, string hashAlmacenado);
    }
}
