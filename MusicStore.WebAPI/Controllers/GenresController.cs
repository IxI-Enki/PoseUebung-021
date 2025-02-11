///   N A M E S P A C E   ///
namespace MusicStore.WebAPI.Controllers;


[Route( "api/[controller]" )]
[ApiController]
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
                var result = new TGenre( );

                result.CopyProperties( genre );

                return result;
        }

        #endregion
}