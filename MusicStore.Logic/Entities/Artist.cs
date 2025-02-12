///   N A M E S P A C E   ///
namespace MusicStore.Logic.Entities;


[Table( "Artists" )]
[Index( nameof( Name ) , IsUnique = true )]
/// <summary>
/// Represents an artist in the music store database,
///   inheriting from <see cref="EntityObject"/>
///   and implementing <see cref="IArtist"/>.
/// </summary>
///
/// <remarks>
/// This class ensures that each artist has a unique name within the system,
///   facilitating identification and preventing duplicates.
/// </remarks>
public sealed class Artist : EntityObject, IArtist
{

        #region ___P R O P E R TY___ 

        /// <summary>
        /// The name of the artist, which must be unique across all artists in the database.
        /// </summary>
        ///
        /// <remarks>
        /// The length of the name is constrained to a maximum of 1024 characters to avoid overly long entries.
        /// </remarks>
        [MaxLength( 1024 )]
        public string Name { get; set; } = string.Empty;

        #endregion


        #region ___N A V I G A T I O N   P R O P E R T Y___

        /// <summary>
        /// Navigation property representing all albums by this artist.
        /// </summary>
        ///
        /// <remarks>
        /// This property establishes a one-to-many relationship between artists and albums.
        /// It's initialized with an empty list to prevent null references at object creation.
        /// </remarks>
        public List<Album>? Albums { get; set; } = [];

        #endregion


        #region ___M E T H O D___

        /// <summary>
        /// Copies properties from another artist object, including the base properties.
        /// </summary>
        ///
        /// <param name="other">
        /// The other artist object to copy properties from.
        /// </param>
        ///
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="other"/> parameter is null.
        /// </exception>
        public void CopyProperties( IArtist other )
        {
                // Ensure the parameter isn't null
                ArgumentNullException.ThrowIfNull( other , nameof( other ) );

                // Copy properties from the base class (like ID)
                base.CopyProperties( other );

                // Copy the artist-specific property
                Name = other.Name;
        }

        #endregion


        #region ___O V E R R I D E___

        /// <summary>
        /// Provides a string representation of the artist, which is simply his name.
        /// </summary>
        ///
        /// <returns>
        /// The name of the artist as a string.
        /// </returns>
        public override string ToString( )

                => new StringBuilder( )
                        .Append( $"    {Name}" )
                        .ToString( );

        #endregion
}