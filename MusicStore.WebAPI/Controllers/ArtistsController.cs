namespace MusicStore.WebAPI.Controllers;

using TArtist = Models.ModelArtist;


[Route( "api/[controller]" )]
[ApiController]
public class ArtistsController : ControllerBase
{
        // GET: api/artists
        [HttpGet]
        public IEnumerable<TArtist> Get( )
        {
                using var context = Factory.CreateContext( );

                return [ .. context.ArtistSet
                                   .Take( Global.MAX_COUNT )
                                   .AsNoTracking( )
                                   .Select( a => TArtist.Create( a ) )
                       ];
        }

        // GET api/artists/5
        [HttpGet( "{id}" )]
        public TArtist? Get( int id )
        {
                using var context = Factory.CreateContext( );

                var result = context.ArtistSet
                                    .FirstOrDefault( a => a.Id == id );

                return result != null
                                 ? TArtist.Create( result )
                                 : null;
        }

        // POST api/artists
        [HttpPost]
        public void Post( [FromBody] TArtist artist )
        {
                using var context = Factory.CreateContext( );

                var result = new Logic.Entities.Artist( );

                if(artist != null)
                {
                        result.CopyProperties( artist );

                        context.ArtistSet.Add( result );

                        context.SaveChanges( );
                }
        }

        // PUT api/artists/5
        [HttpPut( "{id}" )]
        public void Put( int id , [FromBody] TArtist artist )
        {
                using var context = Factory.CreateContext( );

                var result = new Logic.Entities.Artist( );

                if(artist != null)
                {
                        result.CopyProperties( artist );

                        result.Id = id;

                        context.ArtistSet.Add( result );

                        context.SaveChanges( );
                }
        }

        // DELETE api/artists/5
        [HttpDelete( "{id}" )]
        public void Delete( int id )
        {
                using var context = Factory.CreateContext( );

                var result = context.ArtistSet
                                    .FirstOrDefault( a => a.Id == id );

                if(result != null)
                {
                        context.ArtistSet.Remove( result );

                        context.SaveChanges( );
                }
        }
}