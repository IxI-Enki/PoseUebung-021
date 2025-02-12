///   N A M E S P A C E   ///
namespace MusicStore.WebAPI.Controllers;


/// <summary>
/// Provides access to a database context for handling entities and models.
///
/// This class manages the lifecycle of a database context,
///   offering methods to get the context and specific DbSets.
/// </summary>
///
/// <typeparam name="TModel">
/// The type of model object that this accessor deals with.
/// Must inherit from ModelObject.
/// </typeparam>
/// <typeparam name="TEntity">
/// The type of entity object that this accessor deals with.
/// Must inherit from EntityObject.
/// </typeparam>
///
/// <remarks>
/// This class ensures that only one context is used per instance,
///   promoting thread safety
///   and resource management through the IDisposable pattern.
/// It's designed for scenarios where you need to interact with the database in a controlled manner,
///   allowing for type-specific operations.
/// </remarks>
public sealed class ContextAccessor<TModel, TEntity> :
        IDisposable,              // This interface allows the class to implement a 'Dispose' method for proper resource cleanup.
        IContextAccessor<TEntity> // This interface defines the methods GetContext and GetDbSet to provide a consistent way to access context-related operations for entities of type TEntity.

        where TModel : ModelObject, new()   // This constraint specifies that TModel must be or inherit from ModelObject and should have a parameterless constructor.This allows for creating new instances of TModel when needed.
        where TEntity : EntityObject, new() // Ensures TEntity inherits from EntityObject and can be instantiated without parameters, useful for operations that might need to create new entities.
{

        #region ___F I E L D___ 

        /// <summary>
        /// The context used for database operations.
        /// Can be null if not initialized.
        /// </summary>
        IContext? _context = null;

        #endregion


        #region ___M E T H O D S___ 

        /// <summary>
        /// Disposes the context to free up resources.
        /// </summary>
        ///
        /// <remarks>
        /// This method ensures that the context is properly disposed of,
        ///   which is crucial for managing database connections and other resources.
        /// </remarks>
        public void Dispose( )
        {
                // Dispose the context if it's not null
                _context?.Dispose( );

                // Reset the context to null to ensure it's not used again
                _context = null;
        }


        /// <summary>
        /// Retrieves or initializes the context for database operations.
        /// </summary>
        ///
        /// <returns>
        /// An instance of <see cref="IContext"/>.
        /// If no context exists, one is created.
        /// </returns>
        ///
        /// <remarks>
        /// This method uses lazy initialization to create the context only when it's first requested.
        /// </remarks>
        public IContext GetContext( )
        {
                // Use null-coalescing assignment to create the context only if it's null
                return _context ??= Factory.CreateContext( );
        }


        /// <summary>
        /// Retrieves the DbSet for the specified entity type.
        /// </summary>
        ///
        /// <returns>
        /// A <see cref="DbSet{TEntity}"/> associated with the specified entity type, or null if no match is found.
        /// </returns>
        ///
        /// <remarks>
        /// This method checks the type of TEntity against known types to return the appropriate DbSet.
        /// If the type does not match any predefined sets, it returns null.
        /// </remarks>
        public DbSet<TEntity>? GetDbSet( )
        {
                // Initialize result as null by default
                DbSet<TEntity>? result = default;

                // Check the type of TEntity and return the corresponding DbSet
                if(typeof( TEntity ) == typeof( Genre ))
                {
                        // Cast GenreSet to DbSet<TEntity> for type consistency
                        result = GetContext( ).GenreSet as DbSet<TEntity>;
                }
                else if(typeof( TEntity ) == typeof( Artist ))
                {
                        // Cast ArtistSet to DbSet<TEntity> for type consistency
                        result = GetContext( ).ArtistSet as DbSet<TEntity>;
                }
                else if(typeof( TEntity ) == typeof( Album ))
                {
                        // Cast AlbumSet to DbSet<TEntity> for type consistency
                        result = GetContext( ).AlbumSet as DbSet<TEntity>;
                }
                else if(typeof( TEntity ) == typeof( Track ))
                {
                        // Cast TrackSet to DbSet<TEntity> for type consistency
                        result = GetContext( ).TrackSet as DbSet<TEntity>;
                }

                // Return the found DbSet or null
                return result;
        }

        #endregion
}