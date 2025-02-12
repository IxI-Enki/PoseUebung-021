///   N A M E S P A C E   ///
namespace MusicStore.Logic.Entities;


[Table( "Genres" )]
[Index( nameof( Name ) , IsUnique = true )]
/// <summary>
/// Represents a genre in the music store database,
///   inheriting from <see cref="EntityObject"/>
///   and implementing <see cref="IGenre"/>.
/// </summary>
///
/// <remarks>
/// This class defines a genre with a unique name, used as a category for tracks.
/// The class ensures data integrity through database constraints like uniqueness on the name.
/// </remarks>
public sealed class Genre : EntityObject, IGenre
{

        #region ___P R O P E R TY___ 

        /// <summary>
        /// The name of the genre, which must be unique across all genres in the database.
        /// </summary>
        ///
        /// <remarks>
        /// The length of the name is constrained to a maximum of 1024 characters to prevent overly long entries.
        /// </remarks>
        [MaxLength( 1024 )]
        public string Name { get; set; } = string.Empty;

        #endregion


        #region ___N A V I G A T I O N   P R O P E R T Y___

        /// <summary>
        /// Navigation property representing all tracks associated with this genre.
        /// </summary>
        ///
        /// <remarks>
        /// This property allows for one-to-many relationship between genres and tracks.
        /// It's initialized with an empty list to avoid null references when the object is first created.
        /// </remarks>
        public List<Track>? Tracks { get; set; } = [];

        #endregion


        #region ___M E T H O D___

        /// <summary>
        /// Copies properties from another genre object, including the base properties.
        /// </summary>
        ///
        /// <param name="other">
        /// The other genre object to copy properties from.
        /// </param>
        ///
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="other"/> parameter is null or empty.
        /// </exception>
        public void CopyProperties( IGenre other )
        {
                // Ensure the parameter isn't null
                ArgumentNullException.ThrowIfNullOrEmpty( nameof( other ) );

                // Copy properties from the base class (like ID)
                base.CopyProperties( other );

                // Copy the genre-specific property
                Name = other.Name;
        }

        #endregion


        #region ___O V E R R I D E___

        /// <summary>
        /// Provides a string representation of the genre, which is simply its name.
        /// </summary>
        ///
        /// <returns>
        /// The name of the genre as a string.
        /// </returns>
        public override string ToString( )

                => new StringBuilder( )
                        .Append( $"{Name}" )
                        .ToString( );

        #endregion
}