namespace MusicStore.WebAPI.Controllers;

using TGenre = Models.ModelGenre;


[Route( "api/[controller]" )]
[ApiController]
public class GenresController : ControllerBase
{
        // GET: api/genres
        [HttpGet]
        public IEnumerable<TGenre> Get( )
        {
                using var context = Factory.CreateContext( );

                return [ .. context.GenreSet
                                   .Take( Global.MAX_COUNT )
                                   .AsNoTracking( )
                                   .Select( g => TGenre.Create( g ) )
                       ];
        }

        // GET api/genres/5
        [HttpGet( "{id}" )]
        public TGenre? Get( int id )
        {
                using var context = Factory.CreateContext( );

                var result = context.GenreSet
                                    .FirstOrDefault( g => g.Id == id );

                return result != null
                                 ? TGenre.Create( result )
                                 : null;
        }

        // POST api/genres
        [HttpPost]
        public void Post( [FromBody] TGenre genre )
        {
                using var context = Factory.CreateContext( );

                var result = new Logic.Entities.Genre( );

                if(genre != null)
                {
                        result.CopyProperties( genre );

                        context.GenreSet.Add( result );

                        context.SaveChanges( );
                }
        }

        // PUT api/genres/5
        [HttpPut( "{id}" )]
        public void Put( int id , [FromBody] TGenre genre )
        {
                using var context = Factory.CreateContext( );

                var result = new Logic.Entities.Genre( );

                if(genre != null)
                {
                        result.CopyProperties( genre );
                        
                        result.Id = id;

                        context.GenreSet.Add( result );

                        context.SaveChanges( );
                }
        }

        // DELETE api/genres/5
        [HttpDelete( "{id}" )]
        public void Delete( int id )
        {
                using var context = Factory.CreateContext( );

                var result = context.GenreSet
                                    .FirstOrDefault( g => g.Id == id );

                if(result != null)
                {
                        context.GenreSet.Remove( result );

                        context.SaveChanges( );
                }
        }
}