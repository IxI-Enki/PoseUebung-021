///   N A M E S P A C E   ///
namespace MusicStore.Logic.Contracts;


public interface IIdentifiable
{

        #region ___P R O P E R T Y___ 

        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        int Id { get; }

        #endregion
}