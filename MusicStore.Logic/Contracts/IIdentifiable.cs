///   N A M E S P A C E   ///
namespace MusicStore.Logic.Contracts;


/// <summary>
/// Defines the contract for entities that have a unique identifier.
/// </summary>
///
/// <remarks>
/// This interface ensures that any class implementing it has a property for a unique identifier, 
///   facilitating operations like database key management, object comparison, and more.
/// </remarks>
public interface IIdentifiable
{

        #region ___P R O P E R T Y___ 

        /// <summary>
        /// Gets the unique identifier for the entity.
        /// This property should be immutable once set.
        /// </summary>
        ///
        /// <value>
        /// An integer representing the unique ID of the entity.
        /// This is an auto-incremented value from the database.
        /// </value>
        int Id { get; }

        #endregion
}