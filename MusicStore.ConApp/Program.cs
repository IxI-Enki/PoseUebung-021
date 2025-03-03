﻿///   N A M E S P A C E   ///
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

                                ///   T R A C K S   O U T P U T   
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
        private static void PrintGenres( IContext context ) => PrintContext( context , 'g' );

        /// <summary>
        /// Queries genres based on a user-provided condition.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void QueryGenres( IContext context )
        {
                Console.Write( $"\n  Query-Genres\n  {new string( '─' , 31 )}\n  " );

                var query = Console.ReadLine( )!;

                try
                {
                        foreach(var a in context.GenreSet.AsQueryable( ).Where( query ).Include( g => g.Tracks ))

                                Console.Write( $"{$" [id:{a.Id,3}]".ForegroundColor( "190,120,40" )}   {a}\n" );
                }
                catch(Exception ex)
                {
                        PrintErrorMessage( ex );
                }
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

                Console.Write( $"\n  Add Genre\n  {new string( '─' , 31 )}\n   Name [1024]: " );

                string input = Console.ReadLine( )!;


                if(CheckForEmptyInput( input , 1 ))

                        if(context.GenreSet.FirstOrDefault( g => g.Name == input ) != null)

                                Console.Write( $"\n   The genre \"{input}\" is already in the Set!\n".ForegroundColor( "190,120,40" ) );
                        else
                        {
                                genre.Name = input;

                                context.GenreSet.Add( genre );

                                Console.Write( $"\n   - Added the genre \"{input}\"\n".ForegroundColor( "green" ) );

                                context.SaveChanges( );
                        }
                WaitForEnter( );
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
                Console.Write( $"\n  Delete Genre\n  {new string( '─' , 31 )}\n  " );

                string input = Console.ReadLine( )!;


                if(CheckForEmptyInput( input , -1 ))

                        if(context.GenreSet.FirstOrDefault( g => g.Name == input ) == null)

                                Console.Write( $"\n   No genre with the name \"{input}\" was found in the Set!\n".ForegroundColor( "190,20,30" ) );
                        else
                        {
                                context.GenreSet.Remove( context.GenreSet.FirstOrDefault( g => g.Name == input )! );

                                Console.Write( $"\n  - Removed the genre \"{input}\"\n".ForegroundColor( "green" ) );

                                context.SaveChanges( );
                        }
                WaitForEnter( );
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
        private static void PrintArtists( IContext context ) => PrintContext( context , 'a' );

        /// <summary>
        /// Queries artists based on a user-provided condition.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void QueryArtists( IContext context )
        {
                Console.Write( $"\n  Query-Artists\n  {new string( '─' , 31 )}\n  " );

                var query = Console.ReadLine( )!;

                try
                {
                        foreach(var a in context.ArtistSet.AsQueryable( ).Where( query ).Include( a => a.Albums ))

                                Console.Write( $"{$" [id:{a.Id,3}]".ForegroundColor( "190,120,40" )}   {a}\n" );
                }
                catch(Exception ex)
                {
                        PrintErrorMessage( ex );
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

                Console.Write( $"\n  Add Artist\n  {new string( '─' , 31 )}\n   Name [1024]: " );

                string input = Console.ReadLine( )!;


                if(CheckForEmptyInput( input , 1 ))

                        if(context.ArtistSet.FirstOrDefault( a => a.Name == input ) != null)

                                Console.Write( $"\n   The artist \"{input}\" is already in the Set!\n".ForegroundColor( "190,120,40" ) );
                        else
                        {
                                artist.Name = input;

                                context.ArtistSet.Add( artist );

                                Console.Write( $"\n   - Added the artist \"{input}\"\n".ForegroundColor( "green" ) );

                                context.SaveChanges( );
                        }
                WaitForEnter( );
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
                Console.Write( $"\n  Delete Artist\n  {new string( '─' , 31 )}\n  " );

                string input = Console.ReadLine( )!;


                if(CheckForEmptyInput( input , -1 ))

                        if(context.ArtistSet.FirstOrDefault( a => a.Name == input ) == null)

                                Console.Write( $"\n   No artist with the name \"{input}\" was found in the Set!\n".ForegroundColor( "190,20,30" ) );
                        else
                        {
                                context.ArtistSet.Remove( context.ArtistSet.FirstOrDefault( a => a.Name == input )! );

                                Console.Write( $"\n  - Removed the artist \"{input}\"\n".ForegroundColor( "green" ) );

                                context.SaveChanges( );
                        }
                WaitForEnter( );
        }

        #endregion


        #region A L B U M S    M E T H O D S

        /// <summary>
        /// Prints all albums in the context.
        /// </summary>
        ///
        /// <param name="context">
        /// The music store context.
        /// </param>
        private static void PrintAlbums( IContext context ) => PrintContext( context , 'l' );

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
        private static void PrintTracks( IContext context ) => PrintContext( context , 't' );

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


        #region H E L P E R   M E T H O D S

        private static bool CheckForEmptyInput( string? input , int addOrRemoveMod )
        {
                bool result = input == string.Empty;

                Console.Write( result ? $"  Can not {(addOrRemoveMod < 0 ? "remove" : "add")} empty string {(addOrRemoveMod < 0 ? "from" : "to")} the Set!\n".ForegroundColor( "190,20,30" ) : "" );

                return !result;
        }

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

        private static void PrintErrorMessage( Exception ex ) => Console.Write( $"\n  {ex.Message}\n".ForegroundColor( "190,20,30" ) );

        private static void WaitForEnter( ) => Console.ReadLine( );

        private static void PrintContext( IContext context , char v )
        {
                Console.Write( string.Concat( "\n  All " ,

                $"{(v == 'g' ? "Genres" : v == 't' ? "Tracks" : v == 'l' ? "Albums" : "Artists")}\n  " ,

                $"{new string( '─' , 31 )}\n" ) );

                PrintResult( context , v );
        }
        #endregion
}