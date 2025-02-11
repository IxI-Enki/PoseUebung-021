///   N A M E S P A C E   ///
namespace MusicStore.Logic.Contracts;


/// <summary>
/// Defines the contract for a track in the music store system.
/// </summary>
///
/// <remarks>
/// This interface extends <see cref="IIdentifiable"/>,
///   implying that each track has a unique identifier.
/// It includes properties for various track details and navigation properties for related entities like Album and Genre.
/// </remarks>
public interface ITrack : IIdentifiable
{

        #region ___P R O P E R T I E S___ 

        /// <summary>
        /// Gets or sets the album ID.
        /// </summary>
        int AlbumId { get; set; }


        /// <summary>
        /// Gets or sets the genre ID.
        /// </summary>
        int GenreId { get; set; }


        /// <summary>
        /// Gets or sets the title of the track.
        /// </summary>
        string Title { get; set; }


        /// <summary>
        /// Gets or sets the composer of the track.
        /// </summary>
        string Composer { get; set; }


        /// <summary>
        /// Gets or sets the duration of the track in milliseconds.
        /// </summary>
        long Milliseconds { get; set; }


        /// <summary>
        /// Gets or sets the size of the track in bytes.
        /// </summary>
        long Bytes { get; set; }


        /// <summary>
        /// Gets or sets the unit price of the track.
        /// </summary>
        double UnitPrice { get; set; }

        #endregion


        #region ___N A V I G A T I O N   P R O P E R T I E S___ 

        /// <summary>
        /// Gets or sets the album to which this track belongs.
        /// This is a navigation property facilitating the relationship between tracks and albums.
        /// </summary>
        Album? Album { get; set; }


        /// <summary>
        /// Gets or sets the genre of this track.
        /// This navigation property helps in linking a track to its genre classification.
        /// </summary>
        Genre? Genre { get; set; }

        #endregion
}