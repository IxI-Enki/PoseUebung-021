///   N A M E S P A C E   ///
namespace MusicStore.Logic.Entities;


[Table( "Albums" )]
[Index( nameof( Title ) , IsUnique = true )]
/// <summary>
/// Represents an album in the music store database,
///   inheriting from <see cref="EntityObject"/>
///   and implementing <see cref="IAlbum"/>.
/// </summary>
///
/// <remarks>
/// This class ensures each album has a unique title within the system
///   facilitating identification. 
/// It includes relationships with artists and tracks.
/// </remarks>
public sealed class Album : EntityObject, IAlbum
{

        #region ___P R O P E R T I E S___ 

        /// <summary>
        /// The ID of the artist associated with this album, used for foreign key relationship.
        /// </summary>
        public int ArtistId { get; set; }


        /// <summary>
        /// The title of the album, which must be unique across all albums in the database.
        /// </summary>
        ///
        /// <remarks>
        /// The length of the title is constrained to a maximum of 1024 characters to prevent overly long entries.
        /// </remarks>
        [MaxLength( 1024 )]
        public string Title { get; set; } = string.Empty;

        #endregion


        #region ___N A V I G A T I O N   P R O P E R T I E S___ 

        /// <summary>
        /// Navigation property to the artist of this album,
        ///   establishing a many-to-one relationship.
        /// </summary>
        public Artist? Artist { get; set; }


        /// <summary>
        /// Navigation property representing all tracks in this album,
        ///   establishing a one-to-many relationship.
        /// </summary>
        ///
        /// <remarks>
        /// This property is initialized with an empty list to avoid null references when the object is first created.
        /// </remarks>
        public List<Track> Tracks { get; set; } = [];

        #endregion


        #region ___M E T H O D___ 

        /// <summary>
        /// Copies properties from another album object, including the base properties.
        /// </summary>
        ///
        /// <param name="other">
        /// The other album object to copy properties from.
        /// </param>
        ///
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="other"/> parameter is null.
        /// </exception>
        public void CopyProperties( IAlbum other )
        {
                // Ensure the parameter isn't null
                ArgumentNullException.ThrowIfNull( other , nameof( other ) );

                // Copy properties from the base class (like ID)
                base.CopyProperties( other );

                // Copy the album-specific properties
                Title = other.Title;

                Artist?.CopyProperties( other.Artist! );
        }

        #endregion


        #region ___O V E R R I D E___

        /// <summary>
        /// Provides a string representation of the album, including its title, artist, and tracks.
        /// </summary>
        ///
        /// <returns>
        /// A formatted string describing the album.
        /// </returns>
        public override string ToString( )
        {
                var result = new StringBuilder( )

                         .AppendLine( GLOBAL_USINGS.Seperator_Bold( ).ForegroundColor( "110,110,110" ) )

                         .AppendLine( $"    Album-Title  : {(Title.Length >= Console.WindowWidth - 23

                                ? string.Concat( Title.AsSpan( 0 , Console.WindowWidth - 23 ) , " ..." ) : Title)}" )


                         .AppendLine( $"    Album-Artist : {(Artist?.Name.Length >= Console.WindowWidth - 23

                                ? string.Concat( Artist.Name.AsSpan( 0 , Console.WindowWidth - 23 ) , " ..." ) : Artist?.Name)}" )


                         .AppendLine( GLOBAL_USINGS.Seperator_Line( ).ForegroundColor( "30,30,30" ) );

                int i = 1;

                if(Tracks.Select( t => t.Title ).Any( ))

                        result.AppendLine( string.Join(

                                     Environment.NewLine , Tracks.Select( t => $"{string.Concat( $"{i++,6}" , " : " ,

                                     t.Title.AsSpan( 0 , ((t.Title.Length > Console.WindowWidth - 13)

                                     ? (Console.WindowWidth - 13) : (t.Title.Length - 1)) ) ,


                                     $"{(t.Title.Length >= (Console.WindowWidth - 13) ? " ..." : "")}" )}" ) )

                        ).AppendLine( GLOBAL_USINGS.Seperator_Bold( ).ForegroundColor( "110,110,110" ) + "\n" );

                return result.ToString( );
        }
        #endregion
}