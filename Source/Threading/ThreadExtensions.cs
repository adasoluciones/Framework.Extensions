using System;
using System.Threading;

namespace Ada.Framework.Extensions.Threading
{
    /// <summary>
    /// Clase con métodos de extensión para un hilo o subproceso (Thread).
    /// </summary>
    /// <remarks>
    ///     Registro de versiones:
    ///     
    ///         1.0 03/11/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
    /// </remarks>
    public static class ThreadExtensions
    {
        /// <summary>
        /// Guarda un objeto o valor en un espacio de memoria disponible sólo para el hilo actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 03/11/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="hilo">Hilo de origen.</param>
        /// <param name="nombre">Nombre del valor a guardar.</param>
        /// <param name="data">Valor a guardar.</param>
        public static void Guardar(this Thread hilo, string nombre, object data)
        {
            LocalDataStoreSlot slot = Thread.GetNamedDataSlot(nombre);
            if (slot == null)
            {
                slot = Thread.AllocateNamedDataSlot(nombre);
            }
            Thread.SetData(slot, data);
        }

        /// <summary>
        /// Obtiene un objeto guardado en el hilo actual.
        /// </summary>
        /// <remarks>
        ///     Registro de versiones:
        ///     
        ///         1.0 03/11/2015 Marcos Abraham Hernández Bravo (Ada Ltda.): versión inicial.
        /// </remarks>
        /// <param name="hilo">Hilo de origen.</param>
        /// <param name="nombre">Nombre del valor guardado.</param>
        /// <returns>Valor guardado.</returns>
        public static object Obtener(this Thread hilo, string nombre)
        {
            var slot = Thread.GetNamedDataSlot(nombre);
            return Thread.GetData(slot);
        }
    }
}
