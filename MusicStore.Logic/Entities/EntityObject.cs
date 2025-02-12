///   N A M E S P A C E   ///
namespace MusicStore.Logic.Entities;


/// <summary>
/// Represents an abstract base class for all entity objects in the system, ensuring they have a unique identifier.
/// </summary>
///
/// <remarks>
/// This class implements <see cref="IIdentifiable"/>,
///   providing a common foundation for entities that need to be tracked by an identifier in the database or in-memory collections.
/// </remarks>
public abstract class EntityObject : IIdentifiable
{

        #region ___P R O P E R T Y___ 

        /// <summary>
        /// Gets or sets the unique identifier for this entity object.
        /// This serves as the primary key in database contexts or as a unique identifier in application logic.
        /// </summary>
        public int Id { get; set; }

        #endregion


        #region ___M E T H O D___ 

        /// <summary>
        /// Copies the properties from another identifiable object to this entity.
        /// </summary>
        ///
        /// <param name="other">
        /// The other identifiable object from which to copy properties.
        /// </param>
        ///
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="other"/> parameter is null.
        /// </exception>
        ///
        /// <remarks>
        /// This method copies only the identifier,
        ///   assuming that other properties should be managed by derived classes.
        /// It's designed to be overridden by subclasses to include additional property copying if needed.
        /// </remarks>
        public void CopyProperties( IIdentifiable other )
        {
                // Check if the other object is null to prevent null reference exceptions
                ArgumentNullException.ThrowIfNullOrEmpty( nameof( other ) );

                // Copy the Id from the other object to this instance
                Id = other.Id;
        }

        #endregion
}