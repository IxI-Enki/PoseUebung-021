///   N A M E S P A C E   ///
namespace MusicStore.Logic.Contracts;


/// <summary>
/// Represents a music genre with an identifiable ID and a name.
/// </summary>
public interface IGenre : IIdentifiable
{

        #region ___P R O P E R T Y___

        /// <summary>
        /// Gets or sets the name of the genre.
        /// </summary>
        string Name { get; set; }

        #endregion
}