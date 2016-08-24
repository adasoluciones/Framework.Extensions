using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ada.Framework.Extensions.IO.Encoding
{
    /// <summary>
    /// Clase con métodos de extensión para la conversión de Encodings o cadenas codificadas.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public static class EncodingExt
    {
        /// <summary>
        /// Convierte la instancia actual de arreglo de bytes en su representación como cadena, mediante la codificación UTF-8.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="array">Instancia actual codificada en bytes.</param>
        /// <returns>Representación como cadena en UTF-8.</returns>
        public static string ToStr(this byte[] array)
        {
            return System.Text.Encoding.UTF8.GetString(array);
        }

        /// <summary>
        /// Convierte la instancia actual de cadena en su representación como arreglo de bytes, mediante la codificación UTF-8.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="texto">Cadena original.</param>
        /// <returns>Representación codificada en bytes.</returns>
        public static byte[] ToByteArray(this string texto)
        {
            return System.Text.Encoding.UTF8.GetBytes(texto);
        }
    }
}
