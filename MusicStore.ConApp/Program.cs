using Microsoft.EntityFrameworkCore;
using MusicStore.Logic;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Linq.Dynamic.Core;
using MusicStore.Logic.Entities;

namespace MusicStore.ConApp
{
        internal class Program
        {

                /// <summary>
                /// The main entry point for the application.
                /// </summary>
                static void Main(/*string[] args*/)
                {
                        string input = string.Empty;
                        Logic.Contracts.IContext context = Logic.DataContext.Factory.CreateContext( );

                        while(!input.Equals( "x" , StringComparison.CurrentCultureIgnoreCase ))
                        {
                                int index = 1;
                                Console.Clear( );
                                Console.WriteLine( "MusicStore" );
                                Console.WriteLine( "==========================================" );

                                Console.WriteLine( $"{nameof( PrintGenres ),-25}....{index++}" );
                                Console.WriteLine( $"{nameof( QueryGenres ),-25}....{index++}" );
                                Console.WriteLine( $"{nameof( AddGenre ),-25}....{index++}" );
                                Console.WriteLine( $"{nameof( DeleteGenre ),-25}....{index++}" );

                                Console.WriteLine( $"{nameof( PrintArtists ),-25}....{index++}" );
                                Console.WriteLine( $"{nameof( QueryArtists ),-25}....{index++}" );
                                Console.WriteLine( $"{nameof( AddArtist ),-25}....{index++}" );
                                Console.WriteLine( $"{nameof( DeleteArtist ),-25}....{index++}" );

                                // Console.WriteLine($"{nameof(PrintAlbums),-25}....{index++}");
                                // Console.WriteLine($"{nameof(QueryAlbums),-25}....{index++}");
                                // Console.WriteLine($"{nameof(AddAlbum),-25}....{index++}");
                                // Console.WriteLine($"{nameof(DeleteAlbum),-25}....{index++}");
                                // 
                                // Console.WriteLine($"{nameof(PrintTracks),-25}....{index++}");
                                // Console.WriteLine($"{nameof(QueryTracks),-25}....{index++}");
                                // Console.WriteLine($"{nameof(AddTrack),-25}....{index++}");
                                // Console.WriteLine($"{nameof(DeleteTrack),-25}....{index++}");

                                Console.WriteLine( );
                                Console.WriteLine( $"Exit...............x" );
                                Console.Write( "Your choice: " );

                                input = Console.ReadLine( )!;
                                if(Int32.TryParse( input , out int choice ))
                                {
                                        switch(choice)
                                        {
                                                case 1:
                                                        PrintGenres( context );
                                                        Console.WriteLine( );
                                                        Console.Write( "Continue with Enter..." );
                                                        Console.ReadLine( );
                                                        break;
                                                case 2:
                                                        QueryGenres( context );
                                                        Console.WriteLine( );
                                                        Console.Write( "Continue with Enter..." );
                                                        Console.ReadLine( );
                                                        break;
                                                case 3:
                                                        AddGenre( context );
                                                        break;
                                                case 4:
                                                        DeleteGenre( context );
                                                        break;
                                                case 5:
                                                        PrintArtists( context );
                                                        Console.WriteLine( );
                                                        Console.Write( "Continue with Enter..." );
                                                        Console.ReadLine( );
                                                        break;
                                                case 6:
                                                        QueryArtists( context );
                                                        Console.WriteLine( );
                                                        Console.Write( "Continue with Enter..." );
                                                        Console.ReadLine( );
                                                        break;
                                                case 7:
                                                        AddArtist( context );
                                                        break;
                                                case 8:
                                                        DeleteArtist( context );
                                                        break;
                                                case 9:
                                                        PrintAlbums( context );
                                                        Console.WriteLine( );
                                                        Console.Write( "Continue with Enter..." );
                                                        Console.ReadLine( );
                                                        break;
                                                case 10:
                                                        QueryAlbums( context );
                                                        Console.WriteLine( );
                                                        Console.Write( "Continue with Enter..." );
                                                        Console.ReadLine( );
                                                        break;
                                                case 11:
                                                        AddAlbum( context );
                                                        break;
                                                case 12:
                                                        DeleteAlbum( context );
                                                        break;
                                                case 13:
                                                        PrintTracks( context );
                                                        Console.WriteLine( );
                                                        Console.Write( "Continue with Enter..." );
                                                        Console.ReadLine( );
                                                        break;
                                                case 14:
                                                        QueryTracks( context );
                                                        Console.WriteLine( );
                                                        Console.Write( "Continue with Enter..." );
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
                        }
                }

                #region G E N R E S   M E T H O D S

                /// <summary>
                /// Prints all genres in the context.
                /// </summary>
                /// <param name="context">The music store context.</param>
                private static void PrintGenres( Logic.Contracts.IContext context )
                {
                        Console.Write
                                (
                                        "\nAll Genres :\n"
                                        + "------------\n"
                                );

                        foreach(var g in context.GenreSet)
                        {
                                Console.Write( $" [id:{g.Id,3}]   {g}\n" );
                        }
                }

                /// <summary>
                /// Queries genres based on a user-provided condition.
                /// </summary>
                /// <param name="context">The music store context.</param>
                private static void QueryGenres( Logic.Contracts.IContext context )
                {
                        Console.Write
                                (
                                        "\nQuery-Genres:\n"
                                        + "----------------\n"
                                );

                        var query = Console.ReadLine( )!;
                        try
                        {
                                foreach(var g in context.GenreSet.AsQueryable( ).Where( query ).Include( g => g.Tracks ))
                                {
                                        Console.Write( $" [id:{g.Id,3}]   {g}\n" );
                                }
                        }
                        catch(Exception ex)
                        {
                                Console.Write( $"\n{ex.Message}\n" );
                        }
                }

                /// <summary>
                /// Adds a new a to the context.
                /// </summary>
                /// <param name="context">The music store context.</param>
                private static void AddGenre( Logic.Contracts.IContext context )
                {
                        var genre = new Logic.Entities.Genre( );

                        Console.Write
                                (
                                        "\nAdd Genre  :\n"
                                        + "------------\n"
                                        + "Name [1024]: "
                                );

                        string input = Console.ReadLine( )!;

                        if(input == string.Empty)
                        {
                                Console.Write( "\n  Can not add empty string to the Set!\n" );
                        }
                        else if(context.GenreSet.FirstOrDefault( g => g.Name == input ) != null)
                        {
                                Console.Write( $"\n  A genre with the name: \"{input}\" is already in the Set!\n" );
                        }
                        else
                        {
                                genre.Name = input;

                                context.GenreSet.Add( genre );

                                Console.Write( $"\n  - Added the genre: \"{input}\"\n" );

                                context.SaveChanges( );
                        }
                        Console.ReadLine( );
                }

                /// <summary>
                /// Deletes a a from the context.
                /// </summary>
                /// <param name="context">The music store context.</param>
                private static void DeleteGenre( Logic.Contracts.IContext context )
                {
                        Console.Write
                                (
                                        "\nDelete Genre  :\n" +
                                        "-----------------\n"
                                );

                        string input = Console.ReadLine( )!;

                        if(input == string.Empty)
                        {
                                Console.Write( "\n  Can not remove empty string from the Set!\n" );
                        }
                        else if(context.GenreSet.FirstOrDefault( g => g.Name == input ) == null)
                        {
                                Console.Write( $"\n  No genre with the name: \"{input}\" was found in the Set!\n" );
                        }
                        else
                        {
                                context.GenreSet.Remove( context.GenreSet.FirstOrDefault( g => g.Name == input )! );

                                Console.Write( $"\n - Removed the genre: \"{input}\"\n" );

                                context.SaveChanges( );
                        }
                        Console.ReadLine( );
                }

                #endregion


                #region A R T I S T S    M E T H O D S

                /// <summary>
                /// Prints all artists in the context.P
                /// </summary>
                /// <param name="context">The music store context.</param>
                private static void PrintArtists( Logic.Contracts.IContext context )
                {
                        Console.Write
                                (
                                        "\nAll Artists :\n"
                                        + "-------------\n"
                                );

                        foreach(var a in context.ArtistSet)
                        {
                                Console.Write( $" [id:{a.Id,3}]    {a}\n" );
                        }
                }

                /// <summary>
                /// Queries artists based on a user-provided condition.
                /// </summary>
                /// <param name="context">The music store context.</param>
                private static void QueryArtists( Logic.Contracts.IContext context )
                {
                        Console.Write
                                (
                                        "\nQuery-Artists:\n"
                                        + "----------------\n"
                                );

                        var query = Console.ReadLine( )!;
                        try
                        {
                                foreach(var a in context.ArtistSet.AsQueryable( ).Where( query ).Include( a => a.Albums ))
                                {
                                        Console.Write( $" [id:{a.Id,3}]   {a}\n" );
                                }
                        }
                        catch(Exception ex)
                        {
                                Console.Write( $"\n{ex.Message}\n" );

                        }
                }

                /// <summary>
                /// Adds a new artist to the context.
                /// </summary>
                /// <param name="context">The music store context.</param>
                private static void AddArtist( Logic.Contracts.IContext context )
                {
                        var artist = new Logic.Entities.Artist( );

                        Console.Write
                                (
                                        "\nAdd Artist :\n"
                                        + "------------\n"
                                        + "Name [1024]: "
                                );

                        string input = Console.ReadLine( )!;

                        if(input == string.Empty)
                        {
                                Console.Write( "\n  Can not add empty string to the Set!\n" );
                        }
                        else if(context.ArtistSet.FirstOrDefault( a => a.Name == input ) != null)
                        {
                                Console.Write( $"\n  An artist with the name: \"{input}\" is already in the Set!\n" );
                        }
                        else
                        {
                                artist.Name = input;

                                context.ArtistSet.Add( artist );

                                Console.Write( $"\n  - Added the artist: \"{input}\"\n" );

                                context.SaveChanges( );
                        }
                        Console.ReadLine( );
                }

                /// <summary>
                /// Deletes an artist from the context.
                /// </summary>
                /// <param name="context">The music store context.</param>
                private static void DeleteArtist( Logic.Contracts.IContext context )
                {
                        Console.Write
                                (
                                        "\nDelete Artist :\n" +
                                        "-----------------\n"
                                );

                        string input = Console.ReadLine( )!;

                        if(input == string.Empty)
                        {
                                Console.Write( "\n  Can not remove empty string from the Set!\n" );
                        }
                        else if(context.ArtistSet.FirstOrDefault( a => a.Name == input ) == null)
                        {
                                Console.Write( $"\n  No artist with the name: \"{input}\" was found in the Set!\n" );
                        }
                        else
                        {
                                context.ArtistSet.Remove( context.ArtistSet.FirstOrDefault( a => a.Name == input )! );

                                Console.Write( $"\n - Removed the artist: \"{input}\"\n" );

                                context.SaveChanges( );
                        }
                        Console.ReadLine( );
                }

                #endregion


                #region A L B U M S    M E T H O D S

                /// <summary>
                /// Prints all albums in the context.
                /// </summary>
                /// <param name="context">The music store context.</param>
                private static void PrintAlbums( Logic.Contracts.IContext context )
                {
                        throw new NotImplementedException( );
                }

                /// <summary>
                /// Queries albums based on a user-provided condition.
                /// </summary>
                /// <param name="context">The music store context.</param>
                private static void QueryAlbums( Logic.Contracts.IContext context )
                {
                        throw new NotImplementedException( );
                }

                /// <summary>
                /// Adds a new album to the context.
                /// </summary>
                /// <param name="context">The music store context.</param>
                private static void AddAlbum( Logic.Contracts.IContext context )
                {
                        throw new NotImplementedException( );
                }

                /// <summary>
                /// Deletes an album from the context.
                /// </summary>
                /// <param name="context">The music store context.</param>
                private static void DeleteAlbum( Logic.Contracts.IContext context )
                {
                        throw new NotImplementedException( );
                }

                #endregion


                #region T R A C K S   M E T H O D S

                /// <summary>
                /// Prints all tracks in the context.
                /// </summary>
                /// <param name="context">The music store context.</param>
                private static void PrintTracks( Logic.Contracts.IContext context )
                {
                        throw new NotImplementedException( );
                }

                /// <summary>
                /// Queries tracks based on a user-provided condition.
                /// </summary>
                /// <param name="context">The music store context.</param>
                private static void QueryTracks( Logic.Contracts.IContext context )
                {
                        throw new NotImplementedException( );
                }

                /// <summary>
                /// Adds a new track to the context.
                /// </summary>
                /// <param name="context">The music store context.</param>
                private static void AddTrack( Logic.Contracts.IContext context )
                {
                        throw new NotImplementedException( );
                }

                /// <summary>
                /// Deletes a track from the context.
                /// </summary>
                /// <param name="context">The music store context.</param>
                private static void DeleteTrack( Logic.Contracts.IContext context )
                {
                        throw new NotImplementedException( );
                }

                #endregion
        }
}
