///   N A M E S P A C E   ///
namespace MusicStore.WebAPI.Contracts;


/// <summary>
/// Defines the contract for accessing a database context tailored to a specific entity type.
/// </summary>
///
/// <typeparam name="TEntity">
/// The type of entity this accessor will work with.
/// Must inherit from EntityObject and have a parameterless constructor.
/// </typeparam>
///
/// <remarks>
/// This interface is designed to standardize how different parts of the application can interact with database context
///   for specific entity types, ensuring type safety and consistency in database operations.
/// </remarks>
public interface IContextAccessor<TEntity>

        where TEntity : EntityObject, new()  // This constraint ensures that TEntity is or derives from EntityObject & can be instantiated without arguments.
                                             // This is useful for creating new instances of the entity when needed within the implementation of methods.
{
        /// <summary>
        /// Retrieves the database context.
        /// </summary>
        ///
        /// <returns>
        /// An <see cref="IContext"/> instance which manages the database operations.
        /// </returns>
        ///
        /// <remarks>
        /// This method should return the context in a way that it's either already initialized or initializes it on demand.
        /// </remarks>
        IContext GetContext( );


        /// <summary>
        /// Retrieves the DbSet for the specified entity type.
        /// </summary>
        ///
        /// <returns>
        /// A <see cref="DbSet{TEntity}"/> for operations on the entity in question, or null if not found or applicable.
        /// </returns>
        ///
        /// <remarks>
        /// This method allows for type-specific database operations by providing access to the entity collection within the context.
        /// </remarks>
        DbSet<TEntity>? GetDbSet( );
}