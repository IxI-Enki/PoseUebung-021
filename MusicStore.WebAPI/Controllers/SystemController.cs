///   N A M E S P A C E   ///
namespace MusicStore.WebAPI.Controllers;

using CredLoader = MusicStore.Logic.DataContext.DataLoader.CredentialLoader;


[Route( "api/[controller]" )]
[ApiController]
/// <summary>
/// Controller for handling system-level operations,
///   such as database initialization.
/// </summary>
///
/// <remarks>
/// This controller is primarily used for administrative tasks within the system,
///   with specific routes for initializing databases or other critical operations.
/// </remarks>
public class SystemController : ControllerBase
{
        /// <summary>
        /// Endpoint for initializing the system, specifically the database.
        /// </summary>
        ///
        /// <param name="model">
        /// A <see cref="UserData"/> object containing user credentials.
        /// </param>
        ///
        /// <returns>
        /// - <see cref="StatusCodes.Status200OK"/> if the credentials are correct and initialization is successful.
        /// - <see cref="StatusCodes.Status400BadRequest"/> if credentials are incorrect or initialization fails.
        /// </returns>
        ///
        /// <remarks>
        /// This method checks for admin credentials before attempting to initialize the database.
        ///   <warning>
        ///   NOTE: The credentials check here is very basic and SHOULD NOT BE USED in production
        ///           without stronger security measures like encrypted storage, secure transmission,
        ///           and possibly two-factor authentication.
        ///   </warning>
        /// </remarks>
        [HttpPost]
        [ProducesResponseType( StatusCodes.Status200OK )]
        [ProducesResponseType( StatusCodes.Status400BadRequest )]
        public ActionResult Post( [FromBody] UserData model )
        {
                ActionResult? result;

                // Check if the provided credentials match the admin credentials
                if(
                        // Check if the provided username matches the admin name (case-insensitive)
                        model.Username.Equals( CredLoader.Instance!.LoadCredentials( )?.Username , StringComparison.CurrentCultureIgnoreCase )
                        // Check if the provided password matches the admin password (case-sensitive)
                        && model.Password.Equals( CredLoader.Instance!.LoadCredentials( )?.Password )
                        )
                {
                        try
                        {
#if DEBUG                       // Initialize the database only in a debug environment
                                Factory.InitDatabase( );
#endif
                                result = Ok( $" ✅ Welcome {CredLoader.Instance!.LoadCredentials( )?.Username} !" );
                        }
                        catch(Exception ex)
                        {
                                // If an exception occurs during initialization, return a BadRequest with the error message
                                result = BadRequest( ex.Message );
                        }
                }
                else
                {
                        // If credentials do not match, return BadRequest with a message
                        result = BadRequest( "Invalid credentials." );
                }
                return result;
        }
}