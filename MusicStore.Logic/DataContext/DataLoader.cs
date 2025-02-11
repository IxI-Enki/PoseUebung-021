using MusicStore.Logic.Entities;


///   N A M E S P A C E   ///
namespace MusicStore.Logic.DataContext;


public static class DataLoader
{

        #region ___M E T H O D S___ 

        /// LOAD FROM CSV:

        /// <summary>
        /// Loads genres from a CSV file.
        /// </summary>
        /// <param name="path">The path to the CSV file.</param>
        /// <returns>A list of genres.</returns>
        internal static List<Entities.Genre> LoadGenresFromCSV( string path )
        {
                var result = new List<Entities.Genre>( );

                result.AddRange(
                        File.ReadAllLines( path )
                        .Skip( 1 )
                        .Select( line => line.Split( ';' ) )
                        .Select( genre => new Entities.Genre
                        {
                                Name = genre[ 1 ]
                        } ) );

                return result;
        }


        /// <summary>
        /// Loads artists from a CSV file.
        /// </summary>
        /// <param name="path">The path to the CSV file.</param>
        /// <returns>A list of artists.</returns>
        internal static List<Entities.Artist> LoadArtistsFromCSV( string path )
        {
                var result = new List<Entities.Artist>( );

                result.AddRange(
                        File.ReadAllLines( path )
                        .Skip( 1 )
                        .Select( line => line.Split( ';' ) )
                        .Select( artist => new Entities.Artist
                        {
                                Name = artist[ 1 ]
                        } ) );

                return result;
        }


        // ALBUMS
        /// <summary>
        /// Loads albums from a CSV file.
        /// </summary>
        /// <param name="path">The path to the CSV file.</param>
        /// <returns>A list of albums.</returns>


        // TRACKS
        /// <summary>
        /// Loads tracks from a CSV file.
        /// </summary>
        /// <param name="path">The path to the CSV file.</param>
        /// <returns>A list of tracks.</returns>

        #endregion
}