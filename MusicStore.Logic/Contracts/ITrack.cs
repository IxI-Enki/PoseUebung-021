///   N A M E S P A C E   ///
namespace MusicStore.Logic.Contracts;


/// <summary>
/// Represents a track in the music store.
/// </summary>
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
        /// Gets or sets the album associated with the track.
        /// </summary>
        Album? Album { get; set; }

        /// <summary>
        /// Gets or sets the genre associated with the track.
        /// </summary>
        Genre? Genre { get; set; }

        #endregion
}