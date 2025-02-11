using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicStore.Logic.Entities;

[Table( "Genres" )]
[Index( nameof( Name ) , IsUnique = true )]
public sealed class Genre : EntityObject, IGenre
{
        #region PROPERTIES
        [MaxLength( 1024 )]
        public string Name { get; set; } = string.Empty;
        #endregion

        #region NAVIGATION PROPERTIES
        public List<Entities.Track>? Tracks { get; set; }
        #endregion

        #region METHODS
        public void CopyProperties( IGenre other )
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
                        .Append( Name )
                        .ToString( );
        }
        #endregion
}