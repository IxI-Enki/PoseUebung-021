using System.Diagnostics.CodeAnalysis;
using System.Transactions;

///   N A M E S P A C E   ///
namespace MusicStore.Logic.Entities;


[Table( "Tracks" )]
[Index( nameof( Title ) )]
[Index( nameof( AlbumId ) )]
[Index( nameof( GenreId ) )]
/// <summary>
/// Represents a track in the music store database,
///   ínheriting from <see cref="EntityObject"/>
///   and implementing <see cref="ITrack"/>.
/// </summary>
/// 
/// <remarks>
/// This class ensures each track has a unique title within the system,
///   facilitating identification. 
/// It maintains relationships with albums and genres while storing track-specific details.
/// </remarks>
public sealed class Track : EntityObject, ITrack
{

        #region ___P R O P E R T I E S___ 

        /// <summary>
        /// The ID of the album to which this track belongs,
        ///   used for establishing a foreign key relationship.
        /// </summary>
        public int AlbumId { get; set; }


        /// <summary>
        /// The ID of the genre associated with this track,
        ///   sed for establishing a foreign key relationship.
        /// </summary>
        public int GenreId { get; set; }


        /// <summary>
        /// The title of the track, which must be unique across all tracks in the database.
        /// </summary>
        [MaxLength( 1024 )]
        public string Title { get; set; } = string.Empty;


        /// <summary>
        /// The composer or composers of the track.
        /// </summary>
        [MaxLength( 1024 )]
        public string Composer { get; set; } = string.Empty;


        /// <summary>
        /// The duration of the track in milliseconds.
        /// </summary>
        public long Milliseconds { get; set; }


        /// <summary>
        /// The size of the track file in bytes.
        /// </summary>
        public long Bytes { get; set; }


        /// <summary>
        /// The unit price of the track.
        /// </summary>
        public double UnitPrice { get; set; }

        #endregion


        #region ___N A V I G A T I O N    P R O P E R T I E S___ 

        /// <summary>
        /// Navigation property to the album this track belongs to,
        ///   establishing a many-to-one relationship.
        /// </summary>
        public Album? Album { get; set; }


        /// <summary>
        /// Navigation property to the genre this track is categorized under,
        ///   establishing a many-to-one relationship.
        /// </summary>
        public Genre? Genre { get; set; }

        #endregion


        #region ___M E T H O D___ 

        /// <summary>
        /// Copies properties from another track object, including the base properties.
        /// </summary>
        ///
        /// <param name="other">
        /// The other track object to copy properties from.
        /// </param>
        ///
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="other"/> parameter is null.
        /// </exception>
        public void CopyProperties( ITrack other )
        {
                // Ensure the parameter isn't null
                ArgumentNullException.ThrowIfNull( other , nameof( other ) );

                // Copy properties from the base class (like ID)
                base.CopyProperties( other );

                // Copy all track-specific properties with efficient null handling
                Title = other.Title;
                Bytes = other.Bytes;
                AlbumId = other.AlbumId;
                GenreId = other.GenreId;
                Composer = other.Composer;
                UnitPrice = other.UnitPrice;
                Milliseconds = other.Milliseconds;

                Album?.CopyProperties( other.Album! );
                Genre?.CopyProperties( other.Genre! );
        }

        #endregion


        #region ___O V E R R I D E___ 

        /// <summary>
        /// Provides a string representation of the track, including all its details.
        /// </summary>
        ///
        /// <returns>
        /// A formatted string describing the track.
        /// </returns>
        public override string ToString( )

                => new StringBuilder( )
                        .AppendLine( $"Track-Titel : {Title}" )
                        .AppendLine( "---------------------" )
                        // Include album title if available, otherwise mark as "Unknown"
                        .AppendLine( $"Album-Title : {Album?.Title ?? "Unknown"}" )
                        // Include genre name if available, otherwise mark as "Unknown"
                        .AppendLine( $"Genre       : {Genre?.Name ?? "Unknown"}" )
                        .AppendLine( $"Composer    : {Composer}" )
                        // Convert milliseconds to seconds for human readability
                        .AppendLine( $"Duration    : {Milliseconds / 1000} [sec]" )
                        .AppendLine( $"Unit-Price  : {UnitPrice} [€]" )
                        .AppendLine( $"Bytes       : {Bytes}" )
                        .ToString( );

        #endregion
}