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
#if DEBUG                               //  D A T A B A S E   I N I T I A T I O N   
                                case 0:
                                        ResetDatabaseFromCSV( );
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write( "\n  Database was reset." );
                                        Console.ResetColor( );
                                        Console.Write( "\n  Continue with Enter..." );
                                        Console.ReadLine( );
                                        break;
#endif
                                ///   G E N R E S   O U T P U T   
                                case 1:
                                        PrintGenres( context );
                                        Console.Write( "\n  Continue with Enter..." );
                                        Console.ReadLine( );
                                        break;
                                case 2:
                                        QueryGenres( context );
                                        Console.Write( "\n  Continue with Enter..." );
                                        Console.ReadLine( );
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
                                        Console.Write( "\n  Continue with Enter..." );
                                        Console.ReadLine( );
                                        break;
                                case 6:
                                        QueryArtists( context );
                                        Console.Write( "\n  Continue with Enter..." );
                                        Console.ReadLine( );
                                        break;
                                case 7:
                                        AddArtist( context );
                                        break;
                                case 8:
                                        DeleteArtist( context );
                                        break;

                                ///   A L B U M S   O U T P U T   
                                /*

                                case 9:
                                        PrintAlbums( context );
                                        Console.Write( "\n  Continue with Enter..." );
                                        Console.ReadLine( );
                                        break;
                                case 10:
                                        QueryAlbums( context );
                                        Console.Write( "\n  Continue with Enter..." );
                                        Console.ReadLine( );
                                        break;
                                case 11:
                                        AddAlbum( context );
                                        break;
                                case 12:
                                        DeleteAlbum( context );
                                        break;

                                 */

                                ///   T R A C K S   O U T P U T   
                                /*

                                case 13:
                                        PrintTracks( context );
                                        Console.Write( "\n  Continue with Enter..." );
                                        Console.ReadLine( );
                                        break;
                                case 14:
                                        QueryTracks( context );
                                        Console.Write( "\n  Continue with Enter..." );
                                        Console.ReadLine( );
                                        break;
                                case 15:
                                        AddTrack( context );
                                        break;
                                case 16:
                                        DeleteTrack( context );
                                        break;

                                */

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
                Console.Write( $"\n{new string( ' ' , (Console.WindowWidth / 2 - 5) )}MusicStore" );
                Console.Write( $"\n{new string( '═' , Console.WindowWidth )}\n\n" );
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

                /*
                // Console.WriteLine($"{nameof(PrintAlbums),-25}....{index++}");
                // Console.WriteLine($"{nameof(QueryAlbums),-25}....{index++}");
                // Console.WriteLine($"{nameof(AddAlbum),-25}....{index++}");
                // Console.WriteLine($"{nameof(DeleteAlbum),-25}....{index++}");
                // 
                // Console.WriteLine($"{nameof(PrintTracks),-25}....{index++}");
                // Console.WriteLine($"{nameof(QueryTracks),-25}....{index++}");
                // Console.WriteLine($"{nameof(AddTrack),-25}....{index++}");
                // Console.WriteLine($"{nameof(DeleteTrack),-25}....{index++}");
                */

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
        private static void PrintGenres( IContext context )
        {
                Console.Write
                        (
                                "\n  All Genres\n"
                                + $"  {new string( '─' , 31 )}\n"
                        );

                foreach(var g in context.GenreSet)

                        Console.Write( $" [id:{g.Id,3}]   {g}\n" );
        }

        /// <summary>
        /// Queries genres based on a user-provided condition.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void QueryGenres( IContext context )
        {
                Console.Write
                        (
                                "\n  Query-Genres\n"
                                + $"  {new string( '─' , 31 )}\n  "
                        );

                var query = Console.ReadLine( )!;

                try
                {
                        foreach(var g in context.GenreSet.AsQueryable( ).Where( query ).Include( g => g.Tracks ))

                                Console.Write( $" [id:{g.Id,3}]   {g}\n" );
                }
                catch(Exception ex)
                {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write( $"\n  {ex.Message}\n" );
                }
                Console.ResetColor( );
        }

        /// <summary>
        /// Adds a new a to the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void AddGenre( IContext context )
        {
                var genre = new Genre( );

                Console.Write
                        (
                                "\n  Add Genre\n"
                                + $"  {new string( '─' , 31 )}\n"
                                + "   Name [1024]: "
                        );

                string input = Console.ReadLine( )!;

                if(input == string.Empty)
                {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write( "\n  Can not add empty string to the Set!\n" );
                }
                else if(context.GenreSet.FirstOrDefault( g => g.Name == input ) != null)
                {
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.Write( $"\n  A genre with the name \"{input}\" is already in the Set!\n" );
                }
                else
                {
                        genre.Name = input;

                        context.GenreSet.Add( genre );

                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.Write( $"\n   - Added the genre \"{input}\"\n" );

                        context.SaveChanges( );
                }
                Console.ResetColor( );

                Console.ReadLine( );
        }

        /// <summary>
        /// Deletes a a from the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void DeleteGenre( IContext context )
        {
                Console.Write
                        (
                                "\n  Delete Genre\n"
                                + $"  {new string( '─' , 31 )}\n  "
                        );

                string input = Console.ReadLine( )!;

                Console.ForegroundColor = ConsoleColor.Red;

                if(input == string.Empty)

                        Console.Write( "  Can not remove empty string from the Set!\n" );

                else if(context.GenreSet.FirstOrDefault( g => g.Name == input ) == null)

                        Console.Write( $"\n  No genre with the name \"{input}\" was found in the Set!\n" );
                else
                {
                        context.GenreSet.Remove( context.GenreSet.FirstOrDefault( g => g.Name == input )! );

                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.Write( $"\n  - Removed the genre \"{input}\"\n" );

                        context.SaveChanges( );
                }
                Console.ResetColor( );

                Console.ReadLine( );
        }

        #endregion


        #region A R T I S T S    M E T H O D S

        /// <summary>
        /// Prints all artists in the context.P
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void PrintArtists( IContext context )
        {
                Console.Write
                        (
                                "\n  All Artists\n"
                                + $"  {new string( '─' , 31 )}\n"
                        );

                foreach(var a in context.ArtistSet)

                        Console.Write( $" [id:{a.Id,3}]    {a}\n" );
        }

        /// <summary>
        /// Queries artists based on a user-provided condition.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void QueryArtists( IContext context )
        {
                Console.Write
                        (
                                "\n  Query-Artists\n"
                                + $"  {new string( '─' , 31 )}\n  "
                        );

                var query = Console.ReadLine( )!;

                try
                {
                        foreach(var a in context.ArtistSet.AsQueryable( ).Where( query ).Include( a => a.Albums ))

                                Console.Write( $" [id:{a.Id,3}]   {a}\n" );
                }
                catch(Exception ex)
                {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write( $"\n  {ex.Message}\n" );

                        Console.ResetColor( );
                }
        }

        /// <summary>
        /// Adds a new artist to the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void AddArtist( IContext context )
        {
                var artist = new Artist( );

                Console.Write
                        (
                                "\n  Add Artist\n"
                                + $"  {new string( '─' , 31 )}\n"
                                + "   Name [1024]: "
                        );

                string input = Console.ReadLine( )!;

                if(input == string.Empty)
                {
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write( "\n  Can not add empty string to the Set!\n" );
                }
                else if(context.ArtistSet.FirstOrDefault( a => a.Name == input ) != null)
                {
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.Write( $"\n  An artist with the name \"{input}\" is already in the Set!\n" );
                }
                else
                {
                        artist.Name = input;

                        context.ArtistSet.Add( artist );

                        Console.ForegroundColor = ConsoleColor.Green;

                        Console.Write( $"\n   - Added the artist \"{input}\"\n" );

                        context.SaveChanges( );
                }
                Console.ResetColor( );

                Console.ReadLine( );
        }

        /// <summary>
        /// Deletes an artist from the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void DeleteArtist( IContext context )
        {
                Console.Write
                        (
                                "\n  Delete Artist\n"
                                + $"  {new string( '─' , 31 )}\n  "
                        );

                string input = Console.ReadLine( )!;

                Console.ForegroundColor = ConsoleColor.Red;

                if(input == string.Empty)

                        Console.Write( "  Can not remove empty string from the Set!\n" );

                else if(context.ArtistSet.FirstOrDefault( a => a.Name == input ) == null)

                        Console.Write( $"\n  No artist with the name \"{input}\" was found in the Set!\n" );
                else
                {
                        context.ArtistSet.Remove( context.ArtistSet.FirstOrDefault( a => a.Name == input )! );

                        Console.ForegroundColor = ConsoleColor.Yellow;

                        Console.Write( $"\n  - Removed the artist \"{input}\"\n" );

                        context.SaveChanges( );
                }
                Console.ResetColor( );

                Console.ReadLine( );
        }

        #endregion


        #region ___ T O   D O ___ 
        #region A L B U M S    M E T H O D S

        /// <summary>
        /// Prints all albums in the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void PrintAlbums( IContext context )
        {
                throw new NotImplementedException( );
        }

        /// <summary>
        /// Queries albums based on a user-provided condition.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void QueryAlbums( IContext context )
        {
                throw new NotImplementedException( );
        }

        /// <summary>
        /// Adds a new album to the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void AddAlbum( IContext context )
        {
                throw new NotImplementedException( );
        }

        /// <summary>
        /// Deletes an album from the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void DeleteAlbum( IContext context )
        {
                throw new NotImplementedException( );
        }

        #endregion
        #region T R A C K S   M E T H O D S

        /// <summary>
        /// Prints all tracks in the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void PrintTracks( IContext context )
        {
                throw new NotImplementedException( );
        }

        /// <summary>
        /// Queries tracks based on a user-provided condition.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void QueryTracks( IContext context )
        {
                throw new NotImplementedException( );
        }

        /// <summary>
        /// Adds a new track to the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void AddTrack( IContext context )
        {
                throw new NotImplementedException( );
        }

        /// <summary>
        /// Deletes a track from the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void DeleteTrack( IContext context )
        {
                throw new NotImplementedException( );
        }

        #endregion
        #endregion
}