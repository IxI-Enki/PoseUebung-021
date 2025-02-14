///   N A M E S P A C E   ///
namespace MusicStore.Logic.Controllers;


public static class Controll<T> where T : EntityObject
{
        public static void Delete( IContext context )
        {
                string type = typeof( T ).ToString( ).Split( '.' )[ ^1 ];

                Console.Write( $"\n  Delete {type}\n  {new string( '─' , 31 )}\n  " );

                string input = Console.ReadLine( )!;

                if(!IsEmptyInput( input , -1 ) && GetSet( type , context ) is DbSet<T> set)
                {

                        EntityObject? element = GetElement( input , set );

                        if(element == null)

                                Console.Write( $"\n   No {type} with the name \"{input}\" was found in the Set!\n".ForegroundColor( "190,20,30" ) );
                        else
                        {
                                set.Remove( GetElement( input , set )! );

                                Console.Write( $"\n  - Removed the {type} \"{input}\"\n".ForegroundColor( "green" ) );

                                context.SaveChanges( );
                        }
                }
                Console.ReadLine( );
        }

        private static T? GetElement( string input , DbSet<T> set )
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