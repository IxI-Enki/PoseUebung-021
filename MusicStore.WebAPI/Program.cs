///   N A M E S P A C E   ///
namespace MusicStore.WebAPI;


/// <summary>
/// The main entry point for the application,
///   responsible for configuring and running the web application.
/// </summary>
public class Program
{
        /// <summary>
        /// The main method that starts the application,
        ///   configures the service container, and sets up the middleware pipeline.
        /// </summary>
        ///
        /// <param name="args">
        /// Command line arguments passed to the application.
        /// </param>
        public static void Main( string[] args )
        {
                var builder = WebApplication.CreateBuilder( args );

                // Configure services for dependency injection
                // AddControllers sets up support for controller-based APIs
                builder.Services.AddControllers( )
                                .AddNewtonsoftJson( ); // Adds Newtonsoft.Json for JSON serialization, particularly useful for PATCH operations

                // Build the application after configuring services
                var app = builder.Build( );

                // Configure the HTTP request pipeline
                if(app.Environment.IsDevelopment( ))

                        // Enable detailed error pages during development
                        app.UseDeveloperExceptionPage( );

                else    // Use HSTS (HTTP Strict Transport Security) in production to enforce HTTPS
                        app.UseHsts( );


                // Redirect HTTP requests to HTTPS
                app.UseHttpsRedirection( );

                // Enable authorization middleware
                app.UseAuthorization( );

                // Map controller routes
                app.MapControllers( );

                // Start the application listening for requests
                app.Run( );
        }
}