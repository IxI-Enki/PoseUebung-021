///   N A M E S P A C E   ///
namespace MusicStore.Logic.Contracts;


/// <summary>
/// Defines the contract for a database context in the system,
///   providing access to various entity sets 
///   and including operations for managing the context lifecycle and saving changes.
/// </summary>
///
/// <remarks>
/// This interface ensures that any class implementing it can handle database operations
///   for genres, artists, albums, and tracks,
///   while also managing resources through IDisposable.
/// </remarks>
public interface IContext : IDisposable
{

        #region ___P R O P E R T I E S___ 

        /// <summary>
        /// Gets or sets the collection of genres.
        /// </summary>
        DbSet<Genre> GenreSet { get; }


        /// <summary>
        /// Gets or sets the collection of artists.
        /// </summary>
        DbSet<Artist> ArtistSet { get; }


        /// <summary>
        /// Gets or sets the collection of albums.
        /// </summary>
        DbSet<Album> AlbumSet { get; }


        /// <summary>
        /// Gets or sets the collection of tracks.
        /// </summary>
        DbSet<Track> TrackSet { get; }

        #endregion


        #region ___M E T H O D___ 

        /// <summary>
        /// Saves all changes made in this context to the database.
        /// </summary>
        ///
        /// <returns>
        /// The number of state entries written to the database.
        /// </returns>
        ///
        /// <remarks>
        /// This method commits all pending changes to the database.
        /// It's crucial for ensuring that all operations like add, update, or delete
        ///   are reflected in the persistent storage.
        /// </remarks>
        int SaveChanges( );

        #endregion
}