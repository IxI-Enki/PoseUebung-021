///   N A M E S P A C E   ///
namespace MusicStore.Logic.Contracts;


/// <summary>
/// Defines the contract for a genre within the music store system.
/// </summary>
///
/// <remarks>
/// This interface extends <see cref="IIdentifiable"/>,
///   meaning each genre has a unique identifier.
/// It includes basic properties to describe a genre.
/// </remarks>
public interface IGenre : IIdentifiable
{

        #region ___P R O P E R T Y___

        /// <summary>
        /// Gets or sets the name of the genre,
        ///   which is the primary identifier for the genre within the system.
        /// </summary>
        string Name { get; set; }

        #endregion
}