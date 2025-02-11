///   N A M E S P A C E   ///
namespace MusicStore.Logic.Contracts;


/// <summary>
/// Represents an album in the music store.
/// </summary>
public interface IAlbum : IIdentifiable
{

        #region ___P R O P E R T I E S___ 

        /// <summary>
        /// Gets or sets the artist ID.
        /// </summary>
        int ArtistId { get; set; }

        /// <summary>
        /// Gets or sets the title of the album.
        /// </summary>
        string Title { get; set; }

        #endregion


        #region ___N A V I GA T I O N   P R O P E R T I E S___ 

        /// <summary>
        /// Gets or sets the artist associated with the album.
        /// </summary>
        Artist? Artist { get; set; }

        /// <summary>
        /// Gets or sets the tracks in the album.
        /// </summary>
        List<Track> Tracks { get; set; }

        #endregion
}