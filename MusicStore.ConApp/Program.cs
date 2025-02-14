///   N A M E S P A C E   ///
namespace MusicStore.ConApp;


internal class Program
{
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main( )
        {
                Console.OutputEncoding = Encoding.UTF8;

                string input = string.Empty;

                using IContext context = Factory.CreateContext( );

                while(!input.Equals( "x" , StringComparison.CurrentCultureIgnoreCase ))
                {
                        PrintMenu( );

                        input = PrintChoice( context );
                }
        }


        #region M E T H O D S

        /// <summary>
        /// Prints the user's choice.
        /// </summary>
        ///
        /// <param name="context"></param>
        ///
        /// <returns>
        /// The choice of the user.
        /// </returns>
        private static string PrintChoice( IContext context )
        {
                string input = Console.ReadLine( )!;

                if(Int32.TryParse( input , out int choice ))
                {
                        switch(choice)
                        {
#if DEBUG                       ///  D A T A B A S E   I N I T I A T I O N   
                                case 0:
                                        ResetDatabaseFromCSV( );
                                        Console.Write( "\n  Database was reset.".ForegroundColor( "green" ) );
                                        WaitForUser( );
                                        break;
                                case 17:
                                        OverrideOldDatabase( );
                                        Console.Write( "\n  Old database was overridden".ForegroundColor( "green" ) );
                                        break;
#endif
                                ///   G E N R E S   O U T P U T   
                                case 1:
                                        PrintGenres( context );
                                        break;
                                case 2:
                                        QueryGenres( context );
                                        WaitForUser( );
                                        break;
                                case 3:
                                        AddGenre( context );
                                        break;
                                case 4:
                                        DeleteGenre( context );
                                        break;

                                ///   A R T I S T S   O U T P U T   
                                case 5:
                                        PrintArtists( context );
                                        break;
                                case 6:
                                        QueryArtists( context );
                                        WaitForUser( );
                                        break;
                                case 7:
                                        AddArtist( context );
                                        break;
                                case 8:
                                        DeleteArtist( context );
                                        break;

                                ///   A L B U M S   O U T P U T   
                                case 9:
                                        PrintAlbums( context );
                                        break;
                                case 10:
                                        QueryAlbums( context );
                                        WaitForUser( );
                                        break;
                                case 11:
                                        AddAlbum( context );
                                        break;
                                case 12:
                                        DeleteAlbum( context );
                                        break;

                                ///   T R A C K S   O U T P U T   
                                case 13:
                                        PrintTracks( context );
                                        break;
                                case 14:
                                        QueryTracks( context );
                                        WaitForUser( );
                                        break;
                                case 15:
                                        AddTrack( context );
                                        break;
                                case 16:
                                        DeleteTrack( context );
                                        break;

                                default:
                                        break;
                        }
                }
                return input;
        }


        /// <summary>
        /// Prints the menu.
        /// </summary>
        private static void PrintMenu( )
        {
                int index = 1;
                Console.Clear( );
                Console.Write( $"\n{new string( ' ' , (Console.WindowWidth / 2 - 5) )}MusicStore".ForegroundColor( "40,122,77" ) );
                Console.Write( $"\n{new string( '═' , Console.WindowWidth ).ForegroundColor( "40,122,77" )}\n\n" );
#if DEBUG
                index = 0;
                Console.Write( $"  {nameof( ResetDatabaseFromCSV ),-25}.... {index++}\n" );
                Console.Write( $" {new string( '┄' , 33 ),-25}\n" );
#endif
                Console.Write( $"  {nameof( PrintGenres/*      */),-25}.... {index++}\n" );
                Console.Write( $"  {nameof( QueryGenres/*      */),-25}.... {index++}\n" );
                Console.Write( $"  {nameof( AddGenre/*         */),-25}.... {index++}\n" );
                Console.Write( $"  {nameof( DeleteGenre/*      */),-25}.... {index++}\n" );
                //
                Console.Write( $"  {new string( '─' , 31 ),-25}\n" );
                //
                Console.Write( $"  {nameof( PrintArtists/*     */),-25}.... {index++}\n" );
                Console.Write( $"  {nameof( QueryArtists/*     */),-25}.... {index++}\n" );
                Console.Write( $"  {nameof( AddArtist/*        */),-25}.... {index++}\n" );
                Console.Write( $"  {nameof( DeleteArtist/*     */),-25}.... {index++}\n" );
                //
                Console.Write( $"  {new string( '─' , 31 ),-25}\n" );
                //
                Console.Write( $"  {nameof( PrintAlbums/*      */),-25}.... {index++}\n" );
                Console.Write( $"  {nameof( QueryAlbums/*      */),-25}... {index++}\n" );
                Console.Write( $"  {nameof( AddAlbum/*         */),-25}... {index++}\n" );
                Console.Write( $"  {nameof( DeleteAlbum/*      */),-25}... {index++}\n" );
                //
                Console.Write( $"  {new string( '─' , 31 ),-25}\n" );
                //
                Console.Write( $"  {nameof( PrintTracks/*      */),-25}... {index++}\n" );
                Console.Write( $"  {nameof( QueryTracks/*      */),-25}... {index++}\n" );
                Console.Write( $"  {nameof( AddTrack/*         */),-25}... {index++}\n" );
                Console.Write( $"  {nameof( DeleteTrack/*      */),-25}... {index++}\n" );
#if DEBUG
                Console.Write( $" {new string( '┄' , 33 ),-25}\n" );
                Console.Write( $"  {nameof( OverrideOldDatabase ),-25}... {index++}\n" );
#endif
                Console.Write( $"  {new string( '─' , 31 ),-25}\n" );
                Console.Write( $"  {"Exit",-25}.... x\n" );
                Console.Write( $" {new string( '━' , 33 )}\n" );
                Console.Write( $"  Your choice :{' ',-17}" );
        }

        #endregion


        #region D A T A B A S E   I N I T I A T I O N

        /// <summary>
        /// Initiates the Databes if execuuted in Debug-Mode.
        /// </summary>
        public static void ResetDatabaseFromCSV( )
        {
#if DEBUG
                Factory.InitDatabase( );
#endif
        }

        #endregion


        #region G E N R E S   M E T H O D S

        /// <summary>
        /// Prints all genres in the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void PrintGenres( IContext context ) => Print( context , 'g' );


        /// <summary>
        /// Queries genres based on a user-provided condition.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void QueryGenres( IContext context ) => Controll<Genre>.Query( context );


        /// <summary>
        /// Adds a new a to the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void AddGenre( IContext context ) => Controll<Genre>.Add<Genre>( context );


        /// <summary>
        /// Deletes a a from the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void DeleteGenre( IContext context ) => Controll<Genre>.Delete( context );


        #endregion


        #region A R T I S T S    M E T H O D S

        /// <summary>
        /// Prints all artists in the context.P
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void PrintArtists( IContext context ) => Print( context , 'a' );


        /// <summary>
        /// Queries artists based on a user-provided condition.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void QueryArtists( IContext context ) => Controll<Artist>.Query( context );


        /// <summary>
        /// Adds a new artist to the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void AddArtist( IContext context ) => Controll<Artist>.Add<Artist>( context );


        /// <summary>
        /// Deletes an artist from the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void DeleteArtist( IContext context ) => Controll<Artist>.Delete( context );

        #endregion


        #region A L B U M S    M E T H O D S

        /// <summary>
        /// Prints all albums in the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void PrintAlbums( IContext context ) => Print( context , 'l' );


        /// <summary>
        /// Queries albums based on a user-provided condition.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void QueryAlbums( IContext context ) => Controll<Album>.Query( context );


        /// <summary>
        /// Adds a new album to the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void AddAlbum( IContext context ) => Controll<Album>.Add<Album>( context );   // TODO: Implement AddAlbum


        /// <summary>
        /// Deletes an album from the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void DeleteAlbum( IContext context ) => Controll<Album>.Delete( context );
        #endregion


        #region T R A C K S   M E T H O D S

        /// <summary>
        /// Prints all tracks in the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void PrintTracks( IContext context ) => Print( context , 't' );


        /// <summary>
        /// Queries tracks based on a user-provided condition.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void QueryTracks( IContext context ) => Controll<Track>.Query( context );


        /// <summary>
        /// Adds a new track to the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void AddTrack( IContext context ) => Controll<Track>.Add<Track>( context );   // TODO: Implement AddTrack


        /// <summary>
        /// Deletes a track from the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void DeleteTrack( IContext context ) => Controll<Track>.Delete( context );

        #endregion


        #region H E L P E R   M E T H O D S

        private static void PrintResult( IContext context , char setMod )
        {
                switch(setMod)
                {
                        case 'a':
                                foreach(var a in context.ArtistSet) Print( a );
                                break;

                        case 'g':
                                foreach(var a in context.GenreSet) Print( a );
                                break;

                        case 't':
                                // Load all related data in one query
                                var t = context.TrackSet
                                               .Include( a => a.Album )
                                               .ThenInclude( a => a.Tracks )
                                               .Include( a => a.Genre )
                                               .ToList( );

                                foreach(var a in t) Print( a );
                                break;

                        case 'l':
                                // Load all related data in one query
                                var data = context.AlbumSet
                                                  .Include( a => a.Tracks )
                                                  .ThenInclude( t => t.Genre )
                                                  .Include( a => a.Artist )
                                                  .ToList( );

                                foreach(var a in data) Print( a );
                                break;

                        default: break;
                }

                static void Print( EntityObject a ) => Console.Write
                           (
                                string.Concat(
#if DEBUG
                                "  " , $"[id:{a.Id,4}]".BackgroundColor( "80,80,80" ) , $"{" ",5}{(a is Album al

                                          ? $" : {(al.Title.Length >= Console.WindowWidth - 23

                                            ? string.Concat( al.Title.ToUpperInvariant( ).AsSpan( 0 , Console.WindowWidth - 23 ) , " ...\n" )

                                            : $"{al.Title.ToUpperInvariant( )}")}\n".ForegroundColor( "green" )

                                          : a is Track t

                                          ? $": {(t.Title.Length >= Console.WindowWidth - 22

                                            ? string.Concat( t.Title.ToUpperInvariant( ).AsSpan( 0 , Console.WindowWidth - 22 ) , "...\n" )

                                            : $"{t.Title.ToUpperInvariant( )}")}\n".ForegroundColor( "green" )

                                          : "")}" ) +
#endif
                                $"{a}\n"
                           );
        }


        private static void Print( IContext context , char v )
        {
                Console.Write( string.Concat( "\n  All " ,

                $"{(v == 'g' ? "Genres" : v == 't' ? "Tracks" : v == 'l' ? "Albums" : "Artists")}\n  " ,

                $"{new string( '─' , 31 )}\n" ) );

                PrintResult( context , v );

                WaitForUser( );
        }


        private static void WaitForUser( )
        {
                Console.Write( "\n  Continue with Enter..." );
                Console.ReadLine( );
        }

        #endregion


        private static void OverrideOldDatabase( )                                                   // TODO: Implement OverrideOldDatabase
        {
                throw new NotImplementedException( );
        }
}