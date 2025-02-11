using Microsoft.EntityFrameworkCore;
using MusicStore.Logic.Contracts;

namespace MusicStore.Logic.DataContext
{
        /// <summary>
        /// Represents the data context for the Music Store application.
        /// </summary>
        public sealed class MusicStoreContext : DbContext, IContext
        {
                #region FIELDS
                private static string ConnectionString = "data source=MusicStore.db";
                #endregion

                protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
                {
                        optionsBuilder.UseSqlite( ConnectionString );

                        base.OnConfiguring( optionsBuilder );
                }


                #region PROPERTIES
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

                #endregion


                #region CONSTRUCTOR
                /// <summary>
                /// Initializes a new instance of the <see cref="MusicStoreContext"/> class.
                /// </summary>
                public MusicStoreContext( )
                {
                      
                }
                #endregion
        }
}