///   N A M E S P A C E   ///
namespace MusicStore.Logic.Entities;


[Table( "Albums" )]
[Index( nameof( Title ) , IsUnique = true )]
public sealed class Album : EntityObject, IAlbum
{

        #region ___P R O P E R T I E S___ 

        [MaxLength( 1024 )]
        public int ArtistId { get; set; }

        [MaxLength( 1024 )]
        public string Title { get; set; } = string.Empty;

        #endregion


        #region ___N A V I G A T I O N   P R O P E R T I E S___ 

        public Artist? Artist { get; set; }

        public List<Track> Tracks { get; set; } = [];

        #endregion


        #region ___M E T H O D___ 

        public void CopyProperties( IAlbum other )
        {
                ArgumentNullException.ThrowIfNull( other , nameof( other ) );

                base.CopyProperties( other );

                Title = other.Title;
                Artist = other.Artist;
        }

        #endregion


        #region ___O V E R R I D E___

        public override string ToString( )

                => new StringBuilder( )
                        .AppendLine( $"Album-Titel  : {Title}" )
                        .AppendLine( $"Album-Artist : {Artist}" )
                        .AppendLine( "------------------------" )
                        .AppendLine( Tracks.Select( t => t.Title ).ToString( ) )
                        .ToString( );

        #endregion
}