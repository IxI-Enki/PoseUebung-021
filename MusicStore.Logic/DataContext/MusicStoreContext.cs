///   N A M E S P A C E   ///
namespace MusicStore.Logic.DataContext;


/// <summary>
/// Represents the data context for the Music Store application,
///   providing an interface to interact with the database.
/// </summary>
///
/// <remarks>
/// This class inherits from <see cref="DbContext"/> for Entity Framework Core operations
/// and implements <see cref="IContext"/> for custom context management within the application.
/// </remarks>
public sealed class MusicStoreContext : DbContext, IContext
{

        #region ___F I E L D S___ 

        /// <summary>
        /// The path to the directory where the executing assembly resides,
        ///   used for locating connection string files.
        /// </summary>
        private static readonly string _path
                = Path.GetDirectoryName( Assembly.GetExecutingAssembly( ).Location )!;


        /// <summary>
        /// Determines the path to the connection string file,
        ///   with fallback to error handling if the file is missing.
        /// </summary>
        ///
        /// <returns>
        /// The path to the connection string file or a README if the connection string file is not found.
        /// </returns>
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
                        // If the connection string file is missing, point to a README for instructions
                        result = Path.Combine( _path , "Connections" , "README.md" );

                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.Write( $"\n{a.Message}:\nPlease read the provided document in:\n\t {result}\n" );

                        Console.ResetColor( );
                }
                return result;
        }

        #endregion


        #region ___O V E R R I D E S___ 

        /// <summary>
        /// Configures the database context.
        /// This method sets up the connection to the SQL Server using the connection string.
        /// </summary>
        ///
        /// <param name="optionsBuilder">
        /// The builder for configuring the DbContext options.
        /// </param>
        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
                // Configures the DbContext to use SQL Server with the provided connection string.
                //
                // 'ConnectionString' should contain details like server name, database, authentication info.
                optionsBuilder.UseSqlServer( ConnectionString );

                // Calls the base DbContext's OnConfiguring method.
                //
                // This ensures that if any base class has overridden this method with additional configurations,
                //   those are applied after ours.
                //
                // While the base implementation does nothing, this is good practice for extensibility.
                base.OnConfiguring( optionsBuilder );
        }


        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
                base.OnModelCreating( modelBuilder );

                // ALBUM Relationships
                modelBuilder.Entity<Album>( )
                            .HasMany( a => a.Tracks )
                            .WithOne( t => t.Album )
                            .HasForeignKey( t => t.AlbumId );

                modelBuilder.Entity<Album>( )
                            .HasOne( a => a.Artist )
                            .WithMany( a => a.Albums )
                            .HasForeignKey( a => a.ArtistId );

                // ARTIST Relationships
                modelBuilder.Entity<Artist>( )
                            .HasMany( a => a.Albums )
                            .WithOne( a => a.Artist )
                            .HasForeignKey( a => a.ArtistId );

                // GENRE Relationships
                modelBuilder.Entity<Genre>( )
                            .HasMany( g => g.Tracks )
                            .WithOne( t => t.Genre )
                            .HasForeignKey( t => t.GenreId );

                // TRACK Relationships
                modelBuilder.Entity<Track>( )
                            .HasOne( t => t.Album )
                            .WithMany( a => a.Tracks )
                            .HasForeignKey( t => t.AlbumId );

                modelBuilder.Entity<Track>( )
                            .HasOne( t => t.Genre )
                            .WithMany( g => g.Tracks )
                            .HasForeignKey( t => t.GenreId );
        }

        #endregion


        #region ___P R O P E R T I E S___ 

        /// <summary>
        /// Gets or sets the collection of genres.
        /// </summary>
        public DbSet<Genre> GenreSet { get; set; }


        /// <summary>
        /// Gets or sets the collection of artists.
        /// </summary>
        public DbSet<Artist> ArtistSet { get; set; }


        /// <summary>
        /// Gets or sets the collection of albums.
        /// </summary>
        public DbSet<Album> AlbumSet { get; set; }


        /// <summary>
        /// Gets or sets the collection of tracks.
        /// </summary>
        public DbSet<Track> TrackSet { get; set; }


        /// <summary>
        /// Gets the connection string by reading from the file specified by <see cref="_connectionString"/>.
        /// This property is internal,
        ///   it's used within this assembly for database configuration.
        /// </summary>
        internal static string ConnectionString => File.ReadAllText( _connectionString( ) );

        #endregion


        #region ___C O N S T R U C T O R___ 

        /// <summary>
        /// Initializes a new instance of the <see cref="MusicStoreContext"/> class.
        /// This constructor is empty
        ///   as the configuration is handled in <see cref="OnConfiguring(DbContextOptionsBuilder)"/>.
        /// </summary>
        public MusicStoreContext( ) { }

        #endregion
}