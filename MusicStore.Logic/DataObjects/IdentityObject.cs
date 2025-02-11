///   N A M E S P A C E   ///
namespace MusicStore.Logic.DataObjects;


/// <summary>
/// An abstract base class for objects that need to be uniquely identifiable in the system.
/// </summary>
///
/// <remarks>
/// This class implements <see cref="IIdentifiable"/> and provides a basic framework for identity management,
///   including ID property management and methods for equality comparison, hashing, and string representation.
/// </remarks>
public abstract partial class IdentityObject : IIdentifiable
{

        #region ___P R O P E R T Y___ 

        /// <summary>
        /// Gets or sets (internally) the unique identifier for the entity. 
        /// </summary>
        ///
        /// <remarks>
        /// The use of `internal set` allows derived classes within the same assembly to set this property,
        ///   while external code can only read it, ensuring controlled modification of the ID.
        /// </remarks>
        public int Id { get; internal set; }

        #endregion


        #region ___M E T H O D___ 

        /// <summary>
        /// Copies the properties from another identifiable object to this instance.
        /// </summary>
        ///
        /// <param name="other">
        /// Another object implementing <see cref="IIdentifiable"/>
        ///   from which to copy properties.
        /// </param>
        ///
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="other"/> parameter is null.
        /// </exception>
        ///
        /// <remarks>
        /// This method primarily copies the ID but is designed to be overridden for copying additional properties in derived classes.
        /// </remarks>
        protected virtual void CopyProperties( IIdentifiable other )
        {
                ArgumentNullException.ThrowIfNull( other );

                Id = other.Id;
        }

        #endregion


        #region ___O V E R R I D E S___ 

        /// <summary>
        /// Determines whether the specified object is equal to the current object by comparing their IDs.
        /// </summary>
        ///
        /// <param name="obj">
        /// The object to compare with the current object.
        /// </param>
        ///
        /// <returns>
        /// True if the specified object has the same ID as this object; otherwise, false.
        /// </returns>
        ///
        /// <remarks>
        /// This method assumes that two objects are equal if their IDs match,
        ///   which is often suitable for identity-based equality.
        /// </remarks>
        public override bool Equals( object? obj )
        {
                if(obj is IdentityObject other)

                        return Id == other.Id;

                return false;
        }


        /// <summary>
        /// Serves as the default hash function, using the ID for hash code generation.
        /// </summary>
        ///
        /// <returns>
        /// A hash code for the current object based on its ID.
        /// </returns>
        public override int GetHashCode( )
                => Id;


        /// <summary>
        /// Returns a string that represents the current object,
        ///   which is simply the ID string representation.
        /// </summary>
        ///
        /// <returns>
        /// A string representation of the object's ID.
        /// </returns>
        public override string ToString( )
                => Id.ToString( );

        #endregion
}