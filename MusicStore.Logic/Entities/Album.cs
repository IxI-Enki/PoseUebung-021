
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Logic.Entities;
[Table( "Albums" )]
[Index( nameof( Title ) , IsUnique = true )]
public sealed class Album : EntityObject, IAlbum
{
        #region PROPERTIES
        [MaxLength( 1024 )]
        public int ArtistId { get; set; }
        [MaxLength( 1024 )]
        public string Title { get; set; } = string.Empty;
        #endregion

        #region NAVIGATION PROPERTIES
        public Artist? Artist { get; set; }
        public List<Entities.Track> Tracks { get; set; } = [];
        #endregion

        #region METHODS
        public void CopyProperties( IAlbum other )
        {
                ArgumentNullException.ThrowIfNull( other , nameof( other ) );

                base.CopyProperties( other );

                Artist = other.Artist;
                Title = other.Title;
        }
        #endregion

        #region OVERRIDE
        public override string ToString( )
        {
                return new StringBuilder( )
                        .AppendLine( $"Album-Titel  : {Title}" )
                        .AppendLine( $"Album-Artist : {Artist}" )
                        .AppendLine( "------------------------" )
                        .AppendLine( Tracks.Select( t => t.Title ).ToString( ) )
                        .ToString( );
        }
        #endregion
}