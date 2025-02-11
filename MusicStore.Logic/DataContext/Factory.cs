///   N A M E S P A C E   ///
namespace MusicStore.Logic.DataContext;


/// <summary>
/// A static class responsible for creating and initializing database contexts,
///   specifically for the music store application.
/// </summary>
///
/// <remarks>
/// This factory class manages the creation of <see cref="IContext"/> instances 
///   and provides methods for database initialization,
///   which are particularly useful during development or for setting up new environments.
///
/// The use of conditional compilation (#if DEBUG) ensures that database operations like creation and seeding are only available in debug builds.
/// </remarks>
public static class Factory
{

        #region ___F I E L D___ 

        /// <summary>
        /// The path to the directory where the executing assembly resides,
        ///   used for locating data files for database initialization.
        /// </summary>
        private static readonly string _path
                = Path.GetDirectoryName( Assembly.GetExecutingAssembly( ).Location )!.ToString( );

        #endregion


        #region ___M E T H O D S___ 

        /// <summary>
        /// Creates and returns a new instance of <see cref="IContext"/>.
        /// </summary>
        ///
        /// <returns>
        /// A new <see cref="IContext"/> instance, specifically <see cref="MusicStoreContext"/>.
        /// </returns>
        ///
        /// <remarks>
        /// This method should be used whenever a new context is needed for database operations within the application.
        /// </remarks>
        public static IContext CreateContext( )
        {
                var result = new MusicStoreContext( );

                return result;
        }

#if DEBUG
        /// <summary>
        /// Deletes and recreates the database.
        /// This method is only available in debug builds.
        /// </summary>
        ///
        /// <remarks>
        /// Useful for ensuring a clean state of the database during development,
        ///   testing, or when you need to reset the database.
        /// </remarks>
        public static void CreateDatabase( )
        {
                var context = new MusicStoreContext( );

                context.Database.EnsureDeleted( );

                context.Database.EnsureCreated( );
        }

        /// <summary>
        /// Initializes the database with data
        ///   by first recreating it and then seeding it with genres and artists from CSV files.
        /// This method is only available in debug builds.
        /// </summary>
        ///
        /// <remarks>
        /// This method is critical for setting up the database with initial data
        ///   for testing or development purposes. 
        /// It reads from predefined CSV files to populate the database with sample data.
        /// </remarks>
        public static void InitDatabase( )
        {
                var context = CreateContext( );

                try
                {
                        // Recreate the database to ensure a clean state
                        CreateDatabase( );

                        // Load genres from CSV and add to the context
                        var genres = DataLoader.LoadGenresFromCSV( Path.Combine( _path , "Data" , "genres.csv" ) );

                        genres.ToList( ).ForEach( genre => context.GenreSet.Add( genre ) );

                        context.SaveChanges( );

                        // Load artists from CSV and add to the context
                        var artists = DataLoader.LoadArtistsFromCSV( Path.Combine( _path , "Data" , "artists.csv" ) );

                        artists.ToList( ).ForEach( artist => context.ArtistSet.Add( artist ) );

                        context.SaveChanges( );

                        ///    
                        ///    FURTHER LOADING   ///
                        ///    
                        /// TODO: Add any additional data seeding here
                        ///    

                }
                catch
                {            
                        // Handle exceptions that occur during database initialization
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write( $"\n NO DATABASE INITIATED !\n\t - please close the Application" );

                        Console.ResetColor( );

                        Console.ReadLine( );
                }
        }
#endif
        #endregion
}