///   N A M E S P A C E   ///
namespace MusicStore.Logic.Entities;


public abstract class EntityObject : IIdentifiable
{

        #region ___P R O P E R T Y___ 

        public int Id { get; set; }

        #endregion


        #region ___M E T H O D___ 

        public void CopyProperties( IIdentifiable other )
        {
                ArgumentNullException.ThrowIfNullOrEmpty( nameof( other ) );

                Id = other.Id;
        }

        #endregion
}