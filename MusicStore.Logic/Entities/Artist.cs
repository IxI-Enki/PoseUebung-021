using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Logic.Entities;

[Table( "Artists" )]
[Index( nameof( Name ) , IsUnique = true )]
public sealed class Artist : EntityObject, IArtist
{
        #region PROPERTIES
        [MaxLength( 1024 )]
        public string Name { get; set; } = string.Empty;
        #endregion

        #region NAVIGATION PROPERTIES
        public List<Entities.Album>? Albums { get; set; } = [];
        #endregion

        #region METHODS
        public void CopyProperties( IArtist other )
        {
                ArgumentNullException.ThrowIfNullOrEmpty( nameof( other ) );

                base.CopyProperties( other );

                Name = other.Name;
        }
        #endregion

        #region OVERRIDE
        public override string ToString( )
        {
                return new StringBuilder( )
                        .AppendLine( Name )
                        //.AppendLine( "------------------------" )
                        //.AppendLine( Albums?.Select( t => t.Title ).ToString( ) )
                        .ToString( );
        }
        #endregion
}
