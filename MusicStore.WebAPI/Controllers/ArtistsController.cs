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
        /// Retrieves the appropriate <see cref="DbSet{TEntity}"/> from the given context for the entity type.
        /// </summary>
        ///
        /// <param name="context">T
        /// he context from which to retrieve the DbSet.
        /// </param>
        ///
        /// <returns>
        /// A <see cref="DbSet{TEntity}"/> for the operations.
        /// </returns>
        protected override DbSet<Artist> GetDbSet( IContext context ) => context.ArtistSet;


        /// <summary>
        /// Converts an entity to its model representation.
        /// </summary>
        ///
        /// <param name="entity">
        /// The entity to convert.
        /// </param>
        ///
        /// <returns>
        /// A new instance of <typeparamref name="TModel"/> representing the entity.
        /// </returns>
        protected override TArtist ToModel( Artist entity )
        {
                var result = new TArtist( );

                result.CopyProperties( entity );

                return result;
        }

        #endregion
}