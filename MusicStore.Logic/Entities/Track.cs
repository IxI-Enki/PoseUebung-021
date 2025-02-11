using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyModel.Resolution;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Logic.Entities;

[Table( "Tracks" )]
[Index( nameof( Title ) , IsUnique = true )]
public sealed class Track : EntityObject, ITrack
{
        #region PROPERTIES
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

        #region NAVIGATION PROPERTIES
        public Album? Album { get; set; }
        public Genre? Genre { get; set; }
        #endregion

        #region METHODS
        public void CopyProperties( ITrack other )
        {
                ArgumentNullException.ThrowIfNull( other , nameof( other ) );

                base.CopyProperties( other );

                AlbumId = other.AlbumId;
                GenreId = other.GenreId;
                Title = other.Title;
                Composer = other.Composer;
                Milliseconds = other.Milliseconds;
                Bytes = other.Bytes;
                UnitPrice = other.UnitPrice;
        }
        #endregion

        #region OVERRIDE
        public override string ToString( )
        {
                return new StringBuilder( )
                        .AppendLine( $"Titel :{Title}" )
                        .AppendLine( "---------------------" )
                        .AppendLine( $"Album-Title: {Title}" )
                        .AppendLine( $"Genre      : {Genre}" )
                        .AppendLine( $"Composer   : {Composer}" )
                        .AppendLine( $"Duration   : {Milliseconds / 1000} [sec]" )
                        .AppendLine( $"Unit-Price : {UnitPrice} [€]" )
                        .AppendLine( $"Bytes      : {Bytes}" )
                        .ToString( );
        }
        #endregion
}