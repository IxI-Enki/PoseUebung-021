///   N A M E S P A C E   ///
namespace MusicStore.WebAPI.Models;


/// <summary>
/// Represents an abstract base class for model objects that are identifiable,
///   providing a common structure for models that need to be uniquely identified within the system.
/// </summary>
///
/// <remarks>
/// This class serves as a foundational layer for any model that requires an identity,
///   implementing the <see cref="IIdentifiable"/> interface to ensure all models have an ID property.
/// </remarks>
public abstract class ModelObject : IIdentifiable
{

        #region ___P R O P E R T Y___ 

        /// <summary>
        /// Gets or sets the unique identifier for the model object.
        /// This property is the primary key for database operations or for uniquely identifying an instance in memory or data structures.
        /// </summary>
        public int Id { get; set; }

        #endregion


        #region ___M E T H O D___ 

        /// <summary>
        /// Copies the properties from another identifiable object to this instance.
        /// </summary>
        ///
        /// <param name="other">
        /// The other identifiable object from which to copy properties.
        /// Must implement <see cref="IIdentifiable"/>.
        /// </param>
        ///
        /// <exception cref="ArgumentNullException">
        /// Thrown if the <paramref name="other"/> parameter is null.
        /// </exception>
        ///
        /// <remarks>
        /// This method allows for shallow copying of the ID from one identifiable object to another,
        ///   which can be useful in scenarios like object initialization, data transfer,
        ///   or when creating a temporary copy of an object for manipulation without affecting the original.
        /// It's designed to be overridden for more complex models where additional properties need to be copied.
        /// </remarks>
        public virtual void CopyProperties( IIdentifiable other )
        {
                // Check if the provided object is null to prevent null reference exceptions
                ArgumentNullException.ThrowIfNull( nameof( other ) );

                // Copy the Id from the other object to this instance
                Id = other.Id;
        }

        #endregion
}