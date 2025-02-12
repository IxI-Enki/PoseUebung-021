///   N A M E S P A C E   ///
namespace MusicStore.WebAPI.Controllers;


[Route( "api/[controller]" )]
[ApiController]
/// <summary>
/// Controller for handling HTTP requests related to artists in the music store application.
/// </summary>
///
/// <typeparam name="TArtist">
/// The model type representing an artist, which should inherit from <see cref="ModelObject"/>.
/// </typeparam>
///
/// <remarks>
/// This controller uses a generic base controller to provide CRUD operations for artists.
/// It implements specific overrides to manage artist data,
///   interfacing with the database through an abstracted context and providing transformation between entities and models.
/// </remarks>
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
                // Create a new instance of the model
                var result = new TArtist( );

                // Copy properties from the genre entity to the model
                result.CopyProperties( artist );

                return result;
        }

        #endregion
}