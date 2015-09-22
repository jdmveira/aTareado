namespace Jdmveira.aTareado.Entities
{
    /// <summary>
    /// Interfaz que han de cumplir las clases que pueden realizar una copia exacta de sí mismas
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal interface ICloneable<T>
    {
        /// <summary>
        /// Realiza una copia de sí misma. Este método debería de llamar a todos los correspondientes Clone de sus atributos
        /// </summary>
        /// <returns>Una instancia clon de la original</returns>
        T Clone();
    }
}