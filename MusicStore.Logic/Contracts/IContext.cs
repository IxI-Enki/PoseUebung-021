///   N A M E S P A C E   ///
namespace MusicStore.Logic.Contracts;


public interface IContext : IDisposable
{

        #region ___P R O P E R T I E S___ 

        /// <summary>
        /// Gets or sets the collection of genres.
        /// </summary>
        DbSet<Entities.Genre> GenreSet { get; }

        /// <summary>
        /// Gets or sets the collection of artists.
        /// </summary>
        DbSet<Entities.Artist> ArtistSet { get; }

        /// <summary>
        /// Gets or sets the collection of albums.
        /// </summary>
        DbSet<Entities.Album> AlbumSet { get; }

        /// <summary>
        /// Gets or sets the collection of tracks.
        /// </summary>
        DbSet<Entities.Track> TrackSet { get; }

        #endregion


        #region ___M E T H O D___ 

        int SaveChanges( );

        #endregion
}