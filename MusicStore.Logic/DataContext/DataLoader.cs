///   N A M E S P A C E   ///
namespace MusicStore.Logic.DataContext;


/// <summary>
/// Provides static methods for loading data from CSV files into entity collections.
/// </summary>
///
/// <remarks>
/// This class is designed to handle the bulk import of data from CSV files,
///   specifically for genres and artists. 
/// It's meant to be used in scenarios where initial data loading or batch operations are required.
/// </remarks>
public static class DataLoader
{

        #region ___M E T H O D S___ 

        /// <summary>
        /// Loads genre data from a CSV file into a list of <see cref="Entities.Genre"/> objects.
        /// </summary>
        ///
        /// <param name="path">
        /// The file path of the CSV containing genre data.
        /// Each user after the header should have at least two fields where the second field is the genre name.
        /// </param>
        ///
        /// <returns>
        /// A <see cref="List{T}"/> of <see cref="Entities.Genre"/>objects populated from the CSV.
        /// </returns>
        ///
        /// <exception cref="FileNotFoundException">
        /// Thrown if the file at the specified path does not exist.
        /// </exception>
        /// <exception cref="IOException">
        /// Thrown if an I/O error occurs while reading the file.
        /// </exception>
        internal static List<Genre> LoadGenresFromCSV( string path )
        {
                var result = new List<Genre>( );

                // Read all user from the file, skipping the header row
                result.AddRange(
                        File.ReadAllLines( path )
                        .Skip( 1 )                            // Skip header
                        .Select( line => line.Split( ';' ) )  // Split each user by ';'
                        .Select( genre => new Genre
                        {
                                Name = genre[ 1 ]  // Genre name is in the second column (index 1)
                        } ) );

                return result;
        }


        /// <summary>
        /// Loads artist data from a CSV file into a list of <see cref="Entities.Artist"/> objects.
        /// </summary>
        ///
        /// <param name="path">
        /// The file path of the CSV containing artist data.
        /// Each user after the header should have at least two fields where the second field is the artist name.
        /// </param>
        ///
        /// <returns>
        /// A <see cref="List{T}"/> of <see cref="Entities.Artist"/> objects populated from the CSV.
        /// </returns>
        /// 
        /// <exception cref="FileNotFoundException">
        /// Thrown if the file at the specified path does not exist.
        /// </exception>
        /// <exception cref="IOException">T
        /// hrown if an I/O error occurs while reading the file.
        /// </exception>
        internal static List<Artist> LoadArtistsFromCSV( string path )
        {
                var result = new List<Artist>( );

                // Read all user from the file, skipping the header row
                result.AddRange(
                        File.ReadAllLines( path )
                        .Skip( 1 )                            // Skip header
                        .Select( line => line.Split( ';' ) )  // Split each user by ';'
                        .Select( artist => new Artist
                        {
                                Name = artist[ 1 ]  // Artist name is in the second column (index 1)
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



        // CREDENTIALS


        public class CredentialLoader
        {
                public CredentialLoader( ) { }
                static CredentialLoader( ) => Instance = new( );
                public static CredentialLoader? Instance { get; }

                private readonly string _path
                  = Path.GetDirectoryName( Assembly.GetExecutingAssembly( ).Location )!.ToString( );


                public UserCredentials? LoadCredentials( )
                {
                        var user = new List<UserCredentials>( );

                        user.AddRange(
                                File.ReadAllLines( Path.Combine( _path , "Connections" , "credentials.csv" ) )
                                .Skip( 1 )
                                .Select( l => l.Split( ';' ) )
                                .Select( u => new UserCredentials
                                {
                                        Username = u[ 0 ] ,
                                        Password = u[ 1 ] ,
                                        Role = u[ 2 ]

                                } ) );

                        return user.FirstOrDefault( );
                }

                public class UserCredentials
                {
                        public string Username { get; set; } = string.Empty;

                        public string Password { get; set; } = string.Empty;

                        public string Role { get; set; } = string.Empty;
                }

        }
        #endregion
}