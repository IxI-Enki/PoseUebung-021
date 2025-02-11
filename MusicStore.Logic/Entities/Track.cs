///   N A M E S P A C E   ///
namespace MusicStore.Logic.Entities;


[Table( "Tracks" )]
[Index( nameof( Title ) , IsUnique = true )]
public sealed class Track : EntityObject, ITrack
{

        #region ___P R O P E R T I E S___ 

        [MaxLength( 1024 )]
        public int AlbumId { get; set; }

        [MaxLength( 1024 )]
        public int GenreId { get; set; }

        [MaxLength( 1024 )]
        public string Title { get; set; } = string.Empty;

        [MaxLength( 1024 )]
        public string Composer { get; set; } = string.Empty;

        [MaxLength( 100000 )]
        public long Milliseconds { get; set; }

        [MaxLength( 8000 )]
        public long Bytes { get; set; }

        [MaxLength( 1024 )]
        public double UnitPrice { get; set; }

        #endregion


        #region ___N A V I G A T I O N    P R O P E R T I E S___ 

        public Album? Album { get; set; }

        public Genre? Genre { get; set; }

        #endregion


        #region ___M E T H O D___ 

        public void CopyProperties( ITrack other )
        {
                ArgumentNullException.ThrowIfNull( other , nameof( other ) );

                base.CopyProperties( other );

                Title = other.Title;
                Bytes = other.Bytes;
                AlbumId = other.AlbumId;
                GenreId = other.GenreId;
                Composer = other.Composer;
                UnitPrice = other.UnitPrice;
                Milliseconds = other.Milliseconds;
        }

        #endregion


        #region ___O V E R R I D E___ 

        public override string ToString( )

                => new StringBuilder( )
                        .AppendLine( $"Titel :{Title}" )
                        .AppendLine( "---------------------" )
                        .AppendLine( $"Album-Title: {Title}" )
                        .AppendLine( $"Genre      : {Genre}" )
                        .AppendLine( $"Composer   : {Composer}" )
                        .AppendLine( $"Duration   : {Milliseconds / 1000} [sec]" )
                        .AppendLine( $"Unit-Price : {UnitPrice} [€]" )
                        .AppendLine( $"Bytes      : {Bytes}" )
                        .ToString( );

        #endregion
}