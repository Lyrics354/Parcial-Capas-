namespace Negocio.Interfaces
{
    /// <summary>
    /// Contrato cuya ÚNICA responsabilidad es generar el hash de una contraseña.
    /// Se usa cuando un usuario se registra o cambia su contraseña.
    /// </summary>
    public interface IHashService
    {
        /// <summary>
        /// Genera el hash de una contraseña en texto plano.
        /// </summary>
        /// <param name="textoPlano">Contraseña tal como la escribió el usuario.</param>
        /// <returns>Hash en formato hexadecimal (mayúsculas).</returns>
        string GenerarHash(string textoPlano);
    }
}
