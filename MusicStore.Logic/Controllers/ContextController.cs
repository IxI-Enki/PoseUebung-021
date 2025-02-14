///   N A M E S P A C E   ///
namespace MusicStore.Logic.Controllers;


public static class Controll<T> where T : EntityObject
{

        public static void Add<F>( IContext context ) where F : class
        {
                string function = "add";

                PrintPrompt( out string type , out string? input , function );


                if(!IsEmptyInput( input , 1 ) && GetSet( type , context ) is DbSet<T> set)
                {
                        EntityObject? element = GetElement( input , set );

                        if(element == null)
                        {
                                set.Add( CreateElement<F>( type , input! )! );

                                PrintResult( type , input! , function );

                                context.SaveChanges( );
                        }
                        else
                                Console.Write( $"\n   The {type} \"{input}\" already exists in the Set!\n".ForegroundColor( "190,20,30" ) );
                }
                Console.ReadLine( );
        }



        public static void Delete( IContext context )
        {
                string function = "delete";

                PrintPrompt( out string type , out string? input , function );


                if(!IsEmptyInput( input , -1 ) && GetSet( type , context ) is DbSet<T> set)
                {
                        EntityObject? element = GetElement( input , set );

                        if(element == null)

                                Console.Write( $"\n   No {type} with the name \"{input}\" was found in the Set!\n".ForegroundColor( "190,20,30" ) );
                        else
                        {
                                set.Remove( GetElement( input , set )! );

                                PrintResult( type , input! , function );

                                context.SaveChanges( );
                        }
                }
                Console.ReadLine( );
        }


        internal static void PrintPrompt( out string type , out string? input , string function )
        {
                type = GetType( );

                if(function != string.Empty && (function.Equals( "add" , StringComparison.InvariantCultureIgnoreCase ) || function.Equals( "delete" , StringComparison.InvariantCultureIgnoreCase )))
                {
                        Console.Write( $"\n  {char.ToUpper( function[ 0 ] )}{function[ 1.. ].ToLower( )} {type}\n  {new string( '─' , 28 )}\n  " );

                        input = Console.ReadLine( )!;
                }
                else
                        input = string.Empty;
        }


        internal static void PrintResult( string type , string input , string function )
        {
                string result = "\n  ";

                if(function == "delete")

                        result += "- Removed";

                else if(function == "add")

                        result += "- Added";

                result += $" the {type} \"{input}\"\n";

                Console.Write( result.ForegroundColor( "green" ) );
        }


        private static T? CreateElement<F>( string type , string input )
        {
                return type switch
                {
                        "Genre" when typeof( T ) == typeof( Genre ) => ( T )( object )new Genre { Name = input },

                        "Artist" when typeof( T ) == typeof( Artist ) => ( T )( object )new Artist { Name = input },

                        "Album" when typeof( T ) == typeof( Album ) => ( T )( object )new Album { Title = input },

                        "Track" when typeof( T ) == typeof( Track ) => ( T )( object )new Track { Title = input },

                        _ => null
                };
        }


        private static T? GetElement( string? input , DbSet<T> set )
        {
                return set switch
                {
                        DbSet<Genre> genreSet => genreSet.FirstOrDefault( g => g.Name == input ) as T,

                        DbSet<Artist> artistSet => artistSet.FirstOrDefault( g => g.Name == input ) as T,

                        DbSet<Album> albumSet => albumSet.FirstOrDefault( g => g.Title == input ) as T,

                        DbSet<Track> trackSet => trackSet.FirstOrDefault( g => g.Title == input ) as T,

                        _ => null
                };
        }


        private static new string GetType( ) => typeof( T ).ToString( ).Split( '.' )[ ^1 ];


        private static object? GetSet( string type , IContext context )
        {
                return type switch
                {
                        "Genre" => context.GenreSet,

                        "Artist" => context.ArtistSet,

                        "Album" => context.AlbumSet,

                        "Track" => context.TrackSet,

                        _ => null,
                };
        }


        private static bool IsEmptyInput( string? input , int addOrRemoveMod )
        {
                bool result = input == string.Empty;

                Console.Write( result ? $"  Can not {(addOrRemoveMod < 0 ? "remove" : "add")} empty string {(addOrRemoveMod < 0 ? "from" : "to")} the Set!\n".ForegroundColor( "190,20,30" ) : "" );

                return result;
        }
}