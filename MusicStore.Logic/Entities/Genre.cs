///   N A M E S P A C E   ///
namespace MusicStore.Logic.Entities;


[Table( "Genres" )]
[Index( nameof( Name ) , IsUnique = true )]
public sealed class Genre : EntityObject, IGenre
{

        #region ___P R O P E R TY___ 

        [MaxLength( 1024 )]
        public string Name { get; set; } = string.Empty;

        #endregion


        #region ___N A V I G A T I O N   P R O P E R T Y___

        public List<Entities.Track>? Tracks { get; set; } = [];

        #endregion


        #region ___M E T H O D___
        
        public void CopyProperties( IGenre other )
        {
                ArgumentNullException.ThrowIfNullOrEmpty( nameof( other ) );

                base.CopyProperties( other );

                Name = other.Name;
        }

        #endregion


        #region ___O V E R R I D E___

        public override string ToString( )

                => new StringBuilder( )
                        .Append( Name )
                        .ToString( );

        #endregion
}