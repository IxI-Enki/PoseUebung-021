///   N A M E S P A C E   ///
namespace MusicStore.Logic.DataContext;


/// <summary>
/// Represents the data context for the Music Store application.
/// </summary>
public sealed class MusicStoreContext : DbContext, IContext
{

        #region ___F I E L D S___ 

        private static readonly string _path
                = Path.GetDirectoryName( System.Reflection.Assembly.GetExecutingAssembly( ).Location )!;

        private static string _connectionString( )
        {
                string result = Path.Combine( _path , "Connections" );

                try
                {
                        if(File.Exists( Path.Combine( result , "mssql.txt" ) )) //    MYSQL

                                result = Path.Combine( result , "mssql.txt" );

                        else throw new ArgumentException( "MISSING FILE" );
                }
                catch(ArgumentException a)
                {
                        result = Path.Combine( _path , "Connections" , "README.md" );

                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write( $"\n{a.Message}:\nPlease read the provided document in:\n\t {result}\n" );

                        Console.ResetColor( );
                }
                return result;
        }

        #endregion


        #region ___O V E R R I D E___ 

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
                optionsBuilder.UseSqlServer( ConnectionString );

                base.OnConfiguring( optionsBuilder );
        }

        #endregion


        #region ___P R O P E R T I E S___ 

        /// <summary>
        /// Gets or sets the collection of genres.
        /// </summary>
        public DbSet<Entities.Genre> GenreSet { get; set; }

        /// <summary>
        /// Gets or sets the collection of artists.
        /// </summary>
        public DbSet<Entities.Artist> ArtistSet { get; set; }

        /// <summary>
        /// Gets or sets the collection of albums.
        /// </summary>
        public DbSet<Entities.Album> AlbumSet { get; set; }

        /// <summary>
        /// Gets or sets the collection of tracks.
        /// </summary>
        public DbSet<Entities.Track> TrackSet { get; set; }

        internal static string ConnectionString { get => File.ReadAllText( _connectionString( ) ); }

        #endregion


        #region ___C O N S T R U C T O R___ 

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicStoreContext"/> class.
        /// </summary>
        public MusicStoreContext( ) { }

        #endregion
}