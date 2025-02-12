///   N A M E S P A C E   ///
namespace MusicStore.WebAPI.Controllers;


[Route( "api/[controller]" )]
[ApiController]
/// <summary>
/// Controller for handling HTTP requests related to genres in the music store application.
/// </summary>
///
/// <typeparam name="TGenre">
/// The model type representing a genre, which should inherit from <see cref="ModelObject"/>.
/// </typeparam>
///
/// <remarks>
/// This controller leverages a generic base controller to provide CRUD operations for genres.
/// It implements specific overrides to manage genre data,
///   interfacing with the database an abstracted context and providing transformation between entities and models.
/// </remarks>
public class GenresController : GenericController<TGenre , Genre>
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
        /// Retrieves the appropriate <see cref="DbSet{TGenre}"/> from the given context for the genre type.
        /// </summary>
        ///
        /// <param name="context">
        /// The context from which to retrieve the DbSet.
        /// </param>
        ///
        /// <returns>
        /// A <see cref="DbSet{TGenre}"/> for the operations.
        /// </returns>
        protected override DbSet<Genre> GetDbSet( IContext context ) => context.GenreSet;


        /// <summary>
        /// Converts an genre to its model representation.
        /// </summary>
        ///
        /// <param name="genre">
        /// The genre to convert.
        /// </param>
        ///
        /// <returns>
        /// A new instance of <typeparamref name="TGenre"/> representing the genre.
        /// </returns>
        protected override TGenre ToModel( Genre genre )
        {
                // Create a new instance of TGenre
                var result = new TGenre( );

                // Copy properties from the genre entity to the model
                result.CopyProperties( genre );

                return result;
        }

        #endregion
}