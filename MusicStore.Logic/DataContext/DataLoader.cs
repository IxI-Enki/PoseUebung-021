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
        /// Loads album data from a CSV file into a list of <see cref="Entities.Genre"/> objects.
        /// </summary>
        ///
        /// <param name="path">
        /// The file path of the CSV containing album data.
        /// Each user after the header should have at least two fields where the second field is the album name.
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
                                //Id = Convert.ToInt32( genre[ 0 ] ) ,
                                Name = genre[ 1 ]             // Genre name is in the second column (index 1)
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
                                //Id = Convert.ToInt32( artist[ 0 ] ) ,
                                Name = artist[ 1 ]            // Artist name is in the second column (index 1)
                        } ) );
                return result;
        }


        /// <summary>
        /// Loads albums from a CSV file.
        /// </summary>
        /// <param name="path">The path to the CSV file.</param>
        /// <returns>A list of albums.</returns>
        internal static List<Album> LoadAlbumsFromCSV( string path )
        {
                var result = new List<Album>( );

                // Read all albums from the file, skipping the header row
                result.AddRange(
                        File.ReadAllLines( path )
                        .Skip( 1 )                                        // Skip header
                        .Select( line => line.Split( ';' ) )              // Split each album by ';'
                        .Select( album => new Album
                        {
                                //Id = Convert.ToInt32( album[ 0 ] ) ,
                                Title = album[ 1 ] ,                      // Album titls is in the second column (index 1)
                                ArtistId = Convert.ToInt32( album[ 2 ] )  // Artist ID is in the third column (index 2)
                        } ) );
                return result;
        }


        /// <summary>
        /// Loads tracks from a CSV file.
        /// </summary>
        /// <param name="path">The path to the CSV file.</param>
        /// <returns>A list of tracks.</returns>
        internal static List<Track> LoadTracksFromCSV( string path )
        {
                var result = new List<Track>( );

                // Read all tracks from the file, skipping the header row
                result.AddRange(
                        File.ReadAllLines( path )
                        .Skip( 1 )                                              // Skip header
                        .Select( line => line.Split( ';' ) )                    // Split each track by ';'
                        .Select( track => new Track
                        {
                                //Id = Convert.ToInt32( track[ 0 ] ) ,
                                Title = track[ 1 ] ,                            // Track titla is in the second column (index 1)
                                //AlbumId = Convert.ToInt32( track[ 2 ] ) ,       // Album ID is in the third column (index 2)
                                GenreId = Convert.ToInt32( track[ 3 ] ) ,       // Genre ID is in the fourth column (index 3)
                                Composer = track[ 4 ] ,                         // Composer is in the fifth column (index 4)
                                Milliseconds = Convert.ToInt64( track[ 5 ] ) ,  // Milliseconds is in the sixth column (index 5)
                                Bytes = Convert.ToInt64( track[ 6 ] ) ,         // Bytes is in the seventh column (index 6)
                                UnitPrice = Convert.ToDouble( track[ 7 ] )      // Unit price is in the eighth column (index 7)
                        } ) );
                return result;
        }
        #endregion


        /// <summary>
        /// Nested class for handling credential loading from a CSV file.
        /// </summary>
        ///
        /// <remarks>
        /// This class uses a singleton pattern to manage credential loading,
        ///   ensuring that only one instance is used for loading credentials across the application.
        /// </remarks>
        public class CredentialLoader
        {

                #region ___C O N S T R U C T O R___ 

                private CredentialLoader( ) => _path = Path.GetDirectoryName( Assembly.GetExecutingAssembly( ).Location )!;

                #endregion

                #region ___F I E L D S___ 

                private static readonly Lazy<CredentialLoader> _instance
                        = new( ( ) => new CredentialLoader( ) );

                private readonly string _path;

                #endregion

                #region ___P R O P E R T Y___ 

                public static CredentialLoader Instance
                        => _instance.Value;

                #endregion

                #region ___P U B L I C   M E T H O D___ 

                /// <summary>
                /// Loads user credentials from a CSV file.
                /// </summary>
                ///
                /// <returns>
                /// The first <see cref="UserCredentials"/> object found in the CSV, or null if no valid entry exists.
                /// </returns>
                ///
                /// <exception cref="FileNotFoundException">
                /// Thrown if the credential file does not exist.
                /// </exception>
                /// <exception cref="IOException">
                /// Thrown if an I/O error occurs while reading the file.
                /// </exception>
                public UserCredentials? LoadCredentials( )
                {
                        var user = new List<UserCredentials>( );

                        user.AddRange(
                                File.ReadAllLines( Path.Combine( _path , "Connections" , "credentials.csv" ) )
                                .Skip( 1 )                         // Skip header
                                .Select( l => l.Split( ';' ) )
                                .Select( u => new UserCredentials
                                {
                                        Username = u[ 0 ] ,
                                        Password = u[ 1 ] ,
                                        Role = u[ 2 ]
                                } ) );

                        return user.FirstOrDefault( );
                }

                #endregion


                #region E M B E D D E D   C L A S S

                /// <summary>
                /// Represents user credentials with username, password, and role.
                /// </summary>
                public class UserCredentials
                {
                        public string Username { get; set; }
                                = string.Empty;

                        public string Password { get; set; }
                                = string.Empty;

                        public string Role { get; set; }
                                = string.Empty;
                }

                #endregion
        }
}