///   N A M E S P A C E   ///
namespace MusicStore.Logic.DataObjects;


/// <summary>
/// Represents an abstract base class for identifiable objects.
/// </summary>
public abstract partial class IdentityObject : Contracts.IIdentifiable
{

        #region ___P R O P E R T Y___ 

        /// <summary>
        /// Gets the unique identifier for the entity.
        /// </summary>
        public int Id { get; internal set; }

        #endregion


        #region ___M E T H O D___ 

        /// <summary>
        /// Copies the properties from another identifiable object.
        /// </summary>
        /// <param name="other">The other album to copy properties from.</param>
        /// <exception cref="ArgumentNullException">Thrown when the other album is null.</exception>
        protected virtual void CopyProperties( Contracts.IIdentifiable other )
        {
                ArgumentNullException.ThrowIfNull( other );

                Id = other.Id;
        }

        #endregion


        #region ___O V E R R I D E S___ 

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if the specified object is equal to the current object; otherwise, false.</returns>
        public override bool Equals( object? obj )
        {
                if(obj is IdentityObject other)

                        return Id == other.Id;

                return false;
        }

        /// <summary>
        /// Serves as the default hash function.
        /// </summary>
        /// <returns>A hash code for the current object.</returns>
        public override int GetHashCode( )

                => Id;

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString( )

                => Id.ToString( );

        #endregion
}