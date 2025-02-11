namespace MusicStore.WebAPI.Models;

public abstract class ModelObject : Logic.Contracts.IIdentifiable
{
        public int Id { get; set; }

        public virtual void CopyProperties( Logic.Contracts.IIdentifiable other )
        {
                ArgumentNullException.ThrowIfNull( other );

                Id = other.Id;
        }
}
