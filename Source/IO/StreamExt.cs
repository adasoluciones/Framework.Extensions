using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Ada.Framework.Extensions.IO.Encoding;

namespace Ada.Framework.Extensions.IO
{
    /// <summary>
    /// Clase con métodos de extensión para instancias de <see cref="System.IO.Stream"/>.
    /// Estas implementaciones se encuentran integradas en versiones posteriores del framework .NET.
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public static class StreamExt
    {
        /// <summary>
        /// Escribe una linea de texto en el <see cref="System.IO.Stream"/> actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="stream">Instancia de referencia (implícita).</param>
        /// <param name="texto">Cadena de caracteres a escribir.</param>
        public static void WriteLine(this Stream stream, string texto)
        {
            stream.Write(texto + "\n");
        }

        /// <summary>
        /// Escribe texto (sin auto-incorporar salto de linea) en el <see cref="System.IO.Stream"/> actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="stream">Instancia de referencia (implícita).</param>
        /// <param name="texto">Cadena de caracteres a escribir.</param>
        public static void Write(this Stream stream, string texto)
        {
            byte[] array = texto.ToByteArray();
            stream.Write(array, 0, array.Length);
        }

        /// <summary>
        /// Lee una linea a partir de una posicion a partir del inicio de una secuencia <see cref="System.IO.Stream"/>.
        /// Al finalizar la lectura el valor de "posicionInicial" será actualizado hasta donde quedo la lectura.
        /// Útil para leer de arriba hacia abajo por bloques.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="stream">Instancia de referencia (implícita).</param>
        /// <param name="posicionInicial">Posicion a saltarse desde el inicio de la secuencia.</param>
        /// <returns>Cadena de caracteres leída.</returns>
        public static string ReadLine(this Stream stream, ref long posicionInicial)
        {
            byte[] bytes = new byte[stream.Length];
            long bytesLeidos = posicionInicial;
            string texto = string.Empty;

            byte saltoLinea = "\n".ToByteArray()[0];
            while (bytes[0] != saltoLinea && bytesLeidos < stream.Length)
            {
                stream.Seek(bytesLeidos, SeekOrigin.Begin);
                stream.Read(bytes, 0, 1);
                texto += (char)bytes[0];
                bytesLeidos++;
            }
            posicionInicial = bytesLeidos;
            return texto;
        }

        /// <summary>
        /// Lee una linea a partir de una posicion a partir del final de una secuencia <see cref="System.IO.Stream"/>.
        /// Al finalizar la lectura el valor de "posicionInicial" será actualizado hasta donde quedo la lectura.
        /// Útil para leer de abajo hacia arriba por bloques.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="stream">Instancia de referencia (implícita).</param>
        /// <param name="posicionInicial">Posición a iniciar la lectura, que por lo general es el final del <see cref="System.IO.Stream"/>.</param>
        /// <returns>Cadena de caracteres leída.</returns>
        public static string ReadLineFromEnd(this Stream stream, ref long posicionInicial)
        {
            byte[] bytes = new byte[1];
            long bytesPorLeer = posicionInicial;

            string texto = string.Empty;
            stream.Read(bytes, 0, 1);

            byte saltoLinea = "\n".ToByteArray()[0];

            while (bytes[0] != saltoLinea && bytesPorLeer > 0)
            {
                texto = (char)bytes[0] + texto;
                stream.Seek(bytesPorLeer, SeekOrigin.Begin);
                stream.Read(bytes, 0, 1);                
                bytesPorLeer--;
            }
            posicionInicial = bytesPorLeer;
            return texto;
        }

        /// <summary>
        /// Lee todo el documento desde el inicio hasta el final y retorna la representación en Cadena de caracteres.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="stream">Instancia de referencia (implícita).</param>
        /// <returns>Cadena de caracteres leída.</returns>
        public static string ReadToEnd(this Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(bytes, 0, (int)stream.Length);
            return bytes.ToString();
        }

        /// <summary>
        /// Lee una cantidad de bytes desde un origen , con un cierto desplazamiento y lo retorna como Cadena de caracteres.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 02/03/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="stream">Instancia de referencia (implícita).</param>
        /// <param name="cantidadBytes">Cantidad de bytes a leer.</param>
        /// <param name="origen">Posición del texto al que aplicar el desplazamiento.</param>
        /// <param name="desplazamiento">Cantidad de posiciones a mover el cursor desde el origen.</param>
        /// <returns>Cadena de caracteres leída.</returns>
        public static string Read(this Stream stream, int cantidadBytes, SeekOrigin origen, int desplazamiento)
        {
            byte[] bytes = new byte[cantidadBytes];
            stream.Seek(desplazamiento, origen);
            stream.Read(bytes, 0, cantidadBytes);
            return bytes.ToStr();
        }
    }
}
