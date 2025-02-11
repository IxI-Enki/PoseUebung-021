///   N A M E S P A C E   ///
namespace MusicStore.Logic.Contracts;


/// <summary>
/// Represents an artist in the music store.
/// </summary>
public interface IArtist : IIdentifiable
{

        #region ___P R O P E R T Y___ 

        /// <summary>
        /// Gets or sets the name of the artist.
        /// </summary>
        string Name { get; set; }

        #endregion
}