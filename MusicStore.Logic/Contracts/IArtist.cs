///   N A M E S P A C E   ///
namespace MusicStore.Logic.Contracts;


/// <summary>
/// Defines the contract for an artist within the music store system.
/// </summary>
///
/// <remarks>
/// This interface extends <see cref="IIdentifiable"/>,
///   meaning each artist has a unique identifier.
/// It includes basic properties to describe an artist.
/// </remarks>
public interface IArtist : IIdentifiable
{

        #region ___P R O P E R T Y___ 

        /// <summary>
        /// Gets or sets the name of the artist,
        ///   which is the primary identifier for the artist within the system.
        /// </summary>
        string Name { get; set; }

        #endregion
}