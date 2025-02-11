///   N A M E S P A C E   ///
namespace MusicStore.Logic.DataContext;


/// <summary>
/// Factory class to create instances of IContext.
/// </summary>
public static class Factory
{

        #region ___F I E L D___ 

        private static readonly string _path
                = Path.GetDirectoryName( Assembly.GetExecutingAssembly( ).Location )!.ToString( );

        #endregion


        #region ___M E T H O D S___ 

        /// <summary>
        /// Creates an instance of IContext.
        /// </summary>
        /// <returns>An instance of IContext.</returns>
        public static IContext CreateContext( )
        {
                var result = new MusicStoreContext( );

                return result;
        }

#if DEBUG
        public static void CreateDatabase( )
        {
                var context = new MusicStoreContext( );

                context.Database.EnsureDeleted( );

                context.Database.EnsureCreated( );
        }


        public static void InitDatabase( )
        {
                var context = CreateContext( );

                try
                {
                        CreateDatabase( );

                        var genres = DataLoader.LoadGenresFromCSV( Path.Combine( _path , "Data" , "genres.csv" ) );

                        genres.ToList( ).ForEach( genre => context.GenreSet.Add( genre ) );

                        context.SaveChanges( );

                        var artists = DataLoader.LoadArtistsFromCSV( Path.Combine( _path , "Data" , "artists.csv" ) );

                        artists.ToList( ).ForEach( artist => context.ArtistSet.Add( artist ) );

                        context.SaveChanges( );

                        ///    
                        ///    
                        ///    FURTHER LOADING   ///
                        ///    
                        ///    

                }
                catch
                {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write( $"\n NO DATABASE INITIATED !\n\t - please close the Application" );

                        Console.ResetColor( );

                        Console.ReadLine( );
                }
        }
#endif
        #endregion
}