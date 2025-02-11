///   N A M E S P A C E   ///
namespace MusicStore.WebAPI.Controllers;


[Route( "api/[controller]" )]
[ApiController]
public class ArtistsController : GenericController<TArtist , Artist>
{

        #region ___O V E R R I D E S___ 

        /// <summary>
        /// Provides the database context for operations.
        /// </summary>
        ///
        /// <returns>
        /// An instance of <see cref="IContext"/>.
        /// </returns>
        protected override IContext GetContext( ) => Factory.CreateContext( );


        /// <summary>
        /// Retrieves the appropriate <see cref="DbSet{Artist}"/> from the given context for the artist type.
        /// </summary>
        ///
        /// <param name="context">
        /// The context from which to retrieve the DbSet.
        /// </param>
        ///
        /// <returns>
        /// A <see cref="DbSet{Artist}"/> for the operations.
        /// </returns>
        protected override DbSet<Artist> GetDbSet( IContext context ) => context.ArtistSet;


        /// <summary>
        /// Converts an artist to its model representation.
        /// </summary>
        ///
        /// <param name="artist">
        /// The artist to convert.
        /// </param>
        ///
        /// <returns>
        /// A new instance of <typeparamref name="TArtist"/> representing the artist.
        /// </returns>
        protected override TArtist ToModel( Artist artist )
        {
                var result = new TArtist( );

                result.CopyProperties( artist );

                return result;
        }

        #endregion
}