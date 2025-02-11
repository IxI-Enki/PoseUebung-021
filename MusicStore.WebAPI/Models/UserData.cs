///   N A M E S P A C E   ///
namespace MusicStore.WebAPI.Models;


/// <summary>
/// Represents user account information,
///   specifically for managing user credentials.
/// </summary>
///
/// <remarks>
/// This class is designed to hold basic user authentication data.
///   <warning>
///   Note that storing passwords in plain text is not recommended for security reasons.
///     In a production environment, passwords would be hashed.
///   </warning>
/// </remarks>
public class UserData
{

        #region ___P R O P E R T I E S___ 

        /// <summary>
        /// Gets or sets the username for the user account.
        ///
        /// ( This should be unique across all users. )
        /// </summary>
        public string Username { get; set; }
                // Initialize to an empty string to prevent null reference exceptions
                = string.Empty;


        /// <summary>
        /// Gets or sets the password for the user account.
        ///   <warning>
        ///   Storing passwords as plain text is highly insecure.
        ///     In production, consider using a secure hashing algorithm to store and verify passwords.
        ///   </warning>
        /// </summary>
        public string Password { get; set; }
                // Initialize to an empty string to prevent null reference exceptions
                = string.Empty;

        #endregion
}