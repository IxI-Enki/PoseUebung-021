///   N A M E S P A C E   ///
namespace MusicStore.WebAPI.Controllers;


[Route( "api/[controller]" )]
[ApiController]
/// <summary>
/// An abstract base controller for handling CRUD operations on entities of type <typeparamref name="TEntity"/> 
///   with corresponding models of type <typeparamref name="TModel"/>.
/// </summary>
///
/// <typeparam name="TModel">
/// The model type, which must inherit from <see cref="ModelObject"/>.
/// </typeparam>
/// <typeparam name="TEntity">
/// The entity type, which must inherit from <see cref="EntityObject"/>.
/// </typeparam>
///
/// <remarks>
/// This controller provides generic endpoints for common operations
///   like fetching, querying, creating, updating, and deleting entities.
/// It uses generics to work with different types while maintaining a consistent API structure.
/// </remarks>
public abstract class GenericController<TModel, TEntity>
        : ControllerBase

        where TModel : ModelObject, new()   // This constraint specifies that TModel must be or inherit from ModelObject and should have a parameterless constructor.
                                            //   this allows for creating new instances of TModel when needed.
        where TEntity : EntityObject, new() // Ensures TEntity inherits from EntityObject and can be instantiated without parameters,
                                            //   useful for operations that might need to create new entities.
{

        #region A B S T R A C T S

        /// <summary>
        /// Provides the database context for operations.
        /// </summary>
        ///
        /// <returns>
        /// An instance of <see cref="IContext"/>.
        /// </returns>
        protected abstract IContext GetContext( );


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
        protected abstract DbSet<TEntity> GetDbSet( IContext context );


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
        protected abstract TModel ToModel( TEntity entity );

        #endregion


        #region G E T

        /// <summary>
        /// Retrieves all items of the specified entity type.
        /// </summary>
        ///
        /// <returns>
        /// An <see cref="ActionResult"/> containing a collection of <typeparamref name="TModel"/> objects.
        /// </returns>
        [HttpGet]
        [ProducesResponseType( StatusCodes.Status200OK )]
        public ActionResult<IEnumerable<TModel>> Get( )
        {
                // Create a new context within a using block for resource management
                using var context = GetContext( );

                // Get the DbSet for the entity type
                var dbSet = GetDbSet( context );

                var querySet = dbSet
                    .AsQueryable( )   // Convert to IQueryable for LINQ operations
                    .AsNoTracking( ); // Disable change tracking for performance when we don't need to update entities

                var query = querySet
                    .Take( GLOBAL_USINGS.MAX_COUNT ) // Limit the number of items returned to prevent overwhelming responses
                    .ToArray( );                     // Execute the query and convert to array

                var result = query
                    .Select( e => ToModel( e ) ); // Convert each entity to its model representation

                // Return the result with an OK status
                return Ok( result );
        }


        /// <summary>
        /// Queries items based on a provided predicate string.
        /// </summary>
        ///
        /// <param name="predicate">
        /// A string representing a LINQ where clause to filter results.
        /// </param>
        ///
        /// <returns>
        /// An <see cref="ActionResult"/> containing filtered <typeparamref name="TModel"/> objects.
        /// </returns>
        ///
        /// <remarks>
        /// This method uses URL-decoded string to apply dynamic filtering to the dataset.
        /// Ensure that the predicate is sanitized to prevent injection attacks.
        /// </remarks>
        [HttpGet( "/api/[controller]/query/{predicate}" )]
        [ProducesResponseType( StatusCodes.Status200OK )]
        public ActionResult<IEnumerable<TModel>> Query( string predicate )
        {
                using var context = GetContext( );

                var dbSet = GetDbSet( context );

                var querySet = dbSet
                                .AsQueryable( )
                                .AsNoTracking( );

                // Use HttpUtility.UrlDecode to decode the predicate from URL encoding
                var query = querySet
                                .Where( HttpUtility.UrlDecode( predicate ) )  // Dynamically apply the where clause based on the predicate
                                .Take( GLOBAL_USINGS.MAX_COUNT )
                                .ToArray( );

                var result = query
                                .Select( e => ToModel( e ) );

                return Ok( result );
        }


        /// <summary>
        /// Retrieves an item by its ID.
        /// </summary>
        ///
        /// <param name="id">
        /// The ID of the item to retrieve.
        /// </param>
        ///
        /// <returns>
        /// An <see cref="ActionResult"/> containing the <typeparamref name="TModel"/> if found,
        ///   or a <see cref="StatusCodes.Status404NotFound"/> response if not found.
        /// </returns>
        [HttpGet( "{id}" )]
        [ProducesResponseType( StatusCodes.Status200OK )]
        [ProducesResponseType( StatusCodes.Status404NotFound )]
        public ActionResult<TModel>? Get( int id )
        {
                using var context = GetContext( );
                var dbSet = GetDbSet( context );

                // Use FirstOrDefault to get the entity or null if not found
                var result = dbSet
                    .FirstOrDefault( e => e.Id == id );

                return result != null
                    ? Ok( ToModel( result ) )         // If found, return the model with OK status
                    : NotFound( $"{id} not found" );  // If not found, return NotFound with a message
        }

        #endregion


        #region P O S T

        /// <summary>
        /// Creates a new item.
        /// </summary>
        ///
        /// <param name="model">
        /// The model to create an entity from.
        /// </param>
        ///
        /// <returns>
        /// An <see cref="ActionResult"/> with the created <typeparamref name="TModel"/>
        ///   and a 201 Created status,
        ///   or a 400 Bad Request if an error occurred.
        /// </returns>
        [HttpPost]
        [ProducesResponseType( StatusCodes.Status201Created )]
        [ProducesResponseType( StatusCodes.Status400BadRequest )]
        public ActionResult<TModel> Post( [FromBody] TModel model )
        {
                try
                {
                        using var context = GetContext( );

                        var dbSet = GetDbSet( context );

                        // Create a new entity instance
                        var entity = new TEntity( );

                        // Copy properties from the model to the entity
                        entity.CopyProperties( model );

                        // Add the entity to the DbSet
                        dbSet.Add( entity );

                        // Commit changes to the database
                        context.SaveChanges( );

                        // Use CreatedAtAction to return a 201 Created response with the new entity's location
                        return CreatedAtAction( nameof( Get ) , new { id = entity.Id } , ToModel( entity ) );
                }
                catch(Exception ex)
                {
                        // Return any exception message as a BadRequest
                        return BadRequest( ex.Message );
                }
        }

        #endregion


        #region P U T

        /// <summary>
        /// Updates an existing item.
        /// </summary>
        ///
        /// <param name="id">
        /// The ID of the item to update.
        /// </param>
        /// <param name="model">
        /// The updated model data.
        /// </param>
        ///
        /// <returns>
        /// An <see cref="ActionResult"/> with the updated <typeparamref name="TModel"/> on success,
        ///   or appropriate error responses for not found or bad request scenarios.
        /// </returns>
        [HttpPut( "{id}" )]
        [ProducesResponseType( StatusCodes.Status200OK )]
        [ProducesResponseType( StatusCodes.Status404NotFound )]
        [ProducesResponseType( StatusCodes.Status400BadRequest )]
        public ActionResult<TModel> Put( int id , [FromBody] TModel model )
        {
                try
                {
                        using var context = GetContext( );

                        var dbSet = GetDbSet( context );

                        // Look for the entity by ID
                        var entity = dbSet
                            .FirstOrDefault( e => e.Id == id );

                        if(entity != null)
                        {
                                // Update entity properties from model
                                entity.CopyProperties( model );  
                                
                                // Save changes to the database
                                context.SaveChanges( );          
                        }

                        return entity == null
                            ? NotFound( $"{id} not found" )  // Return NotFound if entity wasn't found
                            : Ok( ToModel( entity ) );       // Return updated model if update was successful
                }
                catch(Exception ex)
                {
                        return BadRequest( ex.Message );
                }
        }

        #endregion


        #region D E L E T E

        /// <summary>
        /// Deletes an item by its ID.
        /// </summary>
        ///
        /// <param name="id">
        /// The ID of the item to delete.
        /// </param>
        ///
        /// <returns>
        /// An <see cref="ActionResult"/> indicating success with a 204 No Content status,
        ///   or appropriate error responses if the item isn't found or an error occurs.
        /// </returns>
        [HttpDelete( "{id}" )]
        [ProducesResponseType( StatusCodes.Status204NoContent )]
        [ProducesResponseType( StatusCodes.Status404NotFound )]
        [ProducesResponseType( StatusCodes.Status400BadRequest )]
        public ActionResult Delete( int id )
        {
                try
                {
                        using var context = GetContext( );

                        var dbSet = GetDbSet( context );

                        // Find the entity to delete
                        var entity = dbSet
                            .FirstOrDefault( e => e.Id == id );

                        if(entity != null)
                        {
                                // Mark the entity for deletion
                                dbSet.Remove( entity ); 

                                // Commit the deletion to the database
                                context.SaveChanges( ); 
                        }
                        return entity == null
                            ? NotFound( $"{id} not found" )  // If not found, return NotFound
                            : NoContent( );                  // If deleted, return NoContent (204)
                }
                catch(Exception ex)
                {
                        return BadRequest( ex.Message );
                }
        }

        #endregion
}