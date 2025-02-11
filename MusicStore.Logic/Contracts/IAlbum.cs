///   N A M E S P A C E   ///
namespace MusicStore.Logic.Contracts;


/// <summary>
/// Defines the contract for an album in the music store system.
/// </summary>
///
/// <remarks>
/// This interface extends <see cref="IIdentifiable"/>,
///   indicating that each album has a unique identifier.
/// It includes properties for album details and navigation properties for related entities like Artist and Tracks.
/// </remarks>
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


        #region ___N A V I G A T I O N   P R O P E R T I E S___ 

        /// <summary>
        /// Gets or sets the artist who created this album.
        /// This is a navigation property facilitating the relationship between albums and artists.
        /// </summary>
        Artist? Artist { get; set; }


        /// <summary>
        /// Gets or sets the list of tracks contained within this album.
        /// This navigation property allows for easy access to all tracks associated with an album.
        /// </summary>
        List<Track> Tracks { get; set; }

        #endregion
}