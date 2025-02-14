///   N A M E S P A C E   ///
namespace MusicStore.Logic.Controllers;

/// <summary>
/// Provides generic methods for managing database entities,
///   specifically for adding and deleting records.
/// </summary>
///
/// <typeparam name="T">
/// The type of entity to manage, must inherit from <see cref="EntityObject"/>.
/// </typeparam>
///
/// <remarks>
/// This class is designed to work with different types of entities in a generic way,
///   providing CRUD operations through the command line interface.
/// </remarks>
public static class Controll<T> where T : EntityObject
{

        #region ___M E T H O D S___ 

        /// <summary>
        /// Adds a new entity to the specified database context.
        /// </summary>
        ///
        /// <typeparam name="F">
        /// The type of the entity to add, must be a class.
        /// </typeparam>
        /// 
        /// <param name="context">
        /// The database context to add the entity to.
        /// </param>
        public static void Add<F>( IContext context ) where F : class
        {
                // Set the operation type
                string function = "add";

                // Get user input for type and name/title
                PrintPrompt( out string type , out string? input , function );

                // Check if input isn't empty and get the correct set
                if(!IsEmptyInput( input , 1 ) && GetSet( type , context ) is DbSet<T> set)
                {
                        // Look for an existing element with this name
                        EntityObject? element = GetElement( input , set );

                        // If no element exists with this name
                        if(element == null)
                        {
                                // Create and add new element
                                set.Add( CreateElement<F>( type , input! )! );

                                // Notify user of successful addition
                                PrintResult( type , input! , function );

                                // Commit the change to the database
                                context.SaveChanges( );
                        }
                        else
                                // Inform user that element already exists
                                Console.Write( $"\n   The {type} \"{input}\" already exists in the Set!\n".ForegroundColor( "190,20,30" ) );
                }
                // Wait for user to acknowledge before continuing
                Console.ReadLine( );
        }


        /// <summary>
        /// Deletes an entity from the specified database context.
        /// </summary>
        ///
        /// <param name="context">
        /// The database context from which to delete the entity.
        /// </param>
        public static void Delete( IContext context )
        {
                // Set the operation type
                string function = "delete";

                // Get user input for type and name/title
                PrintPrompt( out string type , out string? input , function );

                // Check if input isn't empty and get the correct set
                if(!IsEmptyInput( input , -1 ) && GetSet( type , context ) is DbSet<T> set)
                {
                        // Look for the element to delete
                        EntityObject? element = GetElement( input , set );

                        // If element not found
                        if(element == null)

                                // Inform user if element not found
                                Console.Write( $"\n   No {type} with the name \"{input}\" was found in the Set!\n".ForegroundColor( "190,20,30" ) );
                        else
                        {
                                // Remove the found element
                                set.Remove( GetElement( input , set )! );

                                // Notify user of successful deletion
                                PrintResult( type , input! , function );

                                // Commit the change to the database
                                context.SaveChanges( );
                        }
                }
                // Wait for user to acknowledge before continuing
                Console.ReadLine( );
        }

        #endregion


        #region ___P R I V A T E   M E T H O D S___ 

        /// <summary>
        /// Prompts the user for input based on the operation (add or delete).
        /// </summary>
        ///
        /// <param name="type">
        /// The type of entity being operated on.
        /// </param>
        /// <param name="input">
        /// The user input for the entity name or title.
        /// </param>
        /// <param name="function">
        /// The operation being performed ("add" or "delete").
        /// </param>
        internal static void PrintPrompt( out string type , out string? input , string function )
        {
                // Get the type name for display
                type = GetType( );

                // Check if function is valid for prompting user
                if(function != string.Empty && (function.Equals( "add" , StringComparison.InvariantCultureIgnoreCase ) || function.Equals( "delete" , StringComparison.InvariantCultureIgnoreCase )))
                {
                        // Format prompt for user input
                        Console.Write( $"\n  {char.ToUpper( function[ 0 ] )}{function[ 1.. ].ToLower( )} {type}\n  {new string( '─' , 28 )}\n  " );

                        // Get user input
                        input = Console.ReadLine( )!;
                }
                else
                        // If function is invalid, set input to empty
                        input = string.Empty;
        }


        /// <summary>
        /// Prints the result of the operation to the console.
        /// </summary>
        ///
        /// <param name="type">
        /// The type of entity affected.
        /// </param>
        /// <param name="input">
        /// The name or title of the entity.
        /// </param>
        /// <param name="function">
        /// The operation performed ("add" or "delete").
        /// </param>
        internal static void PrintResult( string type , string input , string function )
        {
                // Initialize result message
                string result = "\n  ";

                // Format result for deletion
                if(function == "delete")

                        result += "- Removed";

                // Format result for addition
                else if(function == "add")

                        result += "- Added";

                // Append entity type and name to result
                result += $" the {type} \"{input}\"\n";

                // Print result in green
                Console.Write( result.ForegroundColor( "green" ) );
        }


        /// <summary>
        /// Creates a new entity based on the type and input provided.
        /// </summary>
        ///
        /// <typeparam name="F">
        /// The type of entity to create.
        /// </typeparam>
        /// <param name="type">
        /// The name of the entity type as a string.
        /// </param>
        /// <param name="input">
        /// The name or title for the new entity.
        /// </param>
        /// <returns>
        /// A new instance of the entity if the type matches, otherwise null.
        /// </returns>
        private static T? CreateElement<F>( string type , string input )
        {
                // Create new entity based on type
                return type switch
                {
                        // Create a new Genre
                        "Genre" when typeof( T ) == typeof( Genre ) => ( T )( object )new Genre { Name = input },

                        // Create a new Artist
                        "Artist" when typeof( T ) == typeof( Artist ) => ( T )( object )new Artist { Name = input },

                        // Create a new Album
                        "Album" when typeof( T ) == typeof( Album ) => ( T )( object )new Album { Title = input },

                        // Create a new Track
                        "Track" when typeof( T ) == typeof( Track ) => ( T )( object )new Track { Title = input },

                        // Return null if type doesn't match
                        _ => null
                };
        }


        /// <summary>
        /// Retrieves an entity from the given set based on the input.
        /// </summary>
        ///
        /// <param name="input">
        /// The name or title to search for.
        /// </param>
        /// <param name="set">
        /// The DbSet to search within.
        /// </param>
        ///
        /// <returns>
        /// The matching entity if found, otherwise null.
        /// </returns>
        private static T? GetElement( string? input , DbSet<T> set )
        {
                // Find entity by name or title in the set
                return set switch
                {
                        // Find Genre by name
                        DbSet<Genre> genreSet => genreSet.FirstOrDefault( g => g.Name == input ) as T,

                        // Find Artist by name
                        DbSet<Artist> artistSet => artistSet.FirstOrDefault( g => g.Name == input ) as T,

                        // Find Album by title
                        DbSet<Album> albumSet => albumSet.FirstOrDefault( g => g.Title == input ) as T,

                        // Find Track by title
                        DbSet<Track> trackSet => trackSet.FirstOrDefault( g => g.Title == input ) as T,

                        // Return null if no match
                        _ => null
                };
        }


        /// <summary>
        /// Gets the name of the type T as a string.
        /// </summary>
        ///
        /// <returns>
        /// The simple name of type T.
        /// </returns>
        private static new string GetType( ) => typeof( T ).ToString( ).Split( '.' )[ ^1 ];


        /// <summary>
        /// Retrieves the appropriate DbSet for the entity type from the context.
        /// </summary>
        ///
        /// <param name="type">
        /// The type of entity as a string.
        /// </param>
        /// <param name="context">
        /// The database context to retrieve the set from.
        /// </param>
        ///
        /// <returns>
        /// The corresponding DbSet or null if not found.
        /// </returns>
        private static object? GetSet( string type , IContext context )
        {
                // Return the appropriate DbSet based on type
                return type switch
                {
                        // Return Genre set
                        "Genre" => context.GenreSet,

                        // Return Artist set
                        "Artist" => context.ArtistSet,

                        // Return Album set
                        "Album" => context.AlbumSet,

                        // Return Track set
                        "Track" => context.TrackSet,

                        // Return null if type not recognized
                        _ => null,
                };
        }


        /// <summary>
        /// Checks if the input string is empty and prints a message if it is.
        /// </summary>
        ///
        /// <param name="input">
        /// The string to check.
        /// </param>
        /// <param name="addOrRemoveMod">
        /// A modifier to determine if we're adding (1) or removing (-1).
        /// </param>
        ///
        /// <returns>
        /// True if the input is empty, otherwise false.
        /// </returns>
        private static bool IsEmptyInput( string? input , int addOrRemoveMod )
        {
                // Check if input is empty
                bool result = input == string.Empty;

                // Warn user about empty input if applicable
                Console.Write( result ? $"  Can not {(addOrRemoveMod < 0 ? "remove" : "add")} empty string {(addOrRemoveMod < 0 ? "from" : "to")} the Set!\n".ForegroundColor( "190,20,30" ) : "" );

                // Return result of empty check
                return result;
        }

        #endregion
}