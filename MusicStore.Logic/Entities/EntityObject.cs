namespace MusicStore.Logic.Entities;

public abstract class EntityObject : IIdentifiable
{
        public int Id { get; set; }

        public void CopyProperties( IIdentifiable other )
        {
                ArgumentNullException.ThrowIfNullOrEmpty( nameof( other ) );
                Id = other.Id;
        }


}
