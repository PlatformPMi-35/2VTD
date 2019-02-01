namespace Task3.Controllers
{
    using System.Collections.Generic;

    /// <summary>
    /// This class  represents Repository of Cerrier class.
    /// </summary>
    /// <typeparam name="T">Any class.</typeparam>
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// Get All <see cref="{T}"/>.
        /// </summary>
        /// <returns>Returns All <see cref="{T}"/>.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Get <see cref="{T}"/> by id.
        /// </summary>
        /// <param name="id">Id of <see cref="{T}"/>.</param>
        /// <returns>Needed <see cref="{T}"/>.</returns>
        T Get(int id);

        /// <summary>
        /// Adds <see cref="{T}"/> to Context.
        /// </summary>
        /// <param name="item"><see cref="{T}"/> to add.</param>
        void Create(T item);

        /// <summary>
        /// Update <see cref="{T}"/>.
        /// </summary>
        /// <param name="item">Updated <see cref="{T}"/>.</param>
        void Update(T item);

        /// <summary>
        /// Deletes <see cref="{T}"/> from Context by id.
        /// </summary>
        /// <param name="id">Id of <see cref="{T}"/>.</param>
        void Delete(int id);
    }
}
