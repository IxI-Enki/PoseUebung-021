///   N A M E S P A C E   ///
namespace MusicStore.WebAPI.Models;


/// <summary>
/// Represents a model for a genre, inheriting from <see cref="ModelObject"/>
///   to include an identifier and implementing <see cref="IGenre"/> for genre-specific properties and behaviors.
/// </summary>
///
/// <remarks>
/// This class is designed to encapsulate genre-related data and operations,
///   providing a concrete implementation of a genre model
///   that can be used in data transfer and business logic.
/// </remarks>
public class ModelGenre :
        ModelObject,  // Provides the base class functionality, including the Id property for identification.
        IGenre        // An interface that defines genre-specific properties like Name.
{

        #region ___P R O P E R T Y___ 

        /// <summary>
        /// Gets or sets the name of the genre.
        /// This is the key attribute defining the genre.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        #endregion


        #region ___M E T H O D S___ 

        /// <summary>
        /// Copies properties from another genre object,
        ///   including the base properties from <see cref="ModelObject"/>.
        /// </summary>
        ///
        /// <param name="other">
        /// Another genre object that implements <see cref="IGenre"/> from which to copy properties.
        /// </param>
        ///
        /// <exception cref="ArgumentNullException">
        /// Thrown if the <paramref name="other"/> parameter is null.
        /// </exception>
        ///
        /// <remarks>
        /// This method overrides the base class's CopyProperties to include genre-specific properties like Name,
        ///   allowing for a complete transfer of state from one genre object to this instance.
        /// It first calls the base method to copy the Id,
        ///   then adds the Name property.
        /// </remarks>
        public virtual void CopyProperties( IGenre other )
        {
                // Call the base class method to copy the Id property
                base.CopyProperties( other );

                // Copy the Name property from the provided genre object
                Name = other.Name;
        }


        /// <summary>
        /// Creates a new instance of <see cref="ModelGenre"/>
        ///   and copies properties from an existing genre.
        /// </summary>
        ///
        /// <param name="genre">
        /// The genre object from which to copy properties.
        /// Must implement <see cref="IGenre"/>.
        /// </param>
        ///
        /// <returns>
        /// A new <see cref="ModelGenre"/> instance with properties copied from the provided genre.
        /// </returns>
        ///
        /// <exception cref="ArgumentNullException">
        /// Thrown if the <paramref name="genre"/> parameter is null.
        /// </exception>
        ///
        /// <remarks>
        /// This static factory method provides a convenient way to instantiate a new ModelGenre object
        ///   based on an existing genre,
        ///   encapsulating the creation and initialization logic.
        /// It ensures that the new object starts with the same state as the provided genre,
        ///   which can be useful for cloning or data transformation scenarios.
        /// </remarks>
        public static ModelGenre Create( IGenre genre )
        {
                // Ensure the genre parameter is not null before proceeding
                ArgumentNullException.ThrowIfNull( genre , nameof( genre ) );

                // Create a new instance of ModelGenre
                var result = new ModelGenre( );

                // Copy properties from the provided genre to the new instance
                result.CopyProperties( genre );

                return result;
        }

        #endregion
}
