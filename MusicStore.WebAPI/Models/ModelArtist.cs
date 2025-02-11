namespace MusicStore.WebAPI.Models;

public class ModelArtist : ModelObject, IArtist
{
        public string Name { get; set; } = string.Empty;

        public virtual void CopyProperties( IArtist other )
        {
                base.CopyProperties( other );

                Name = other.Name;
        }

        public static ModelArtist Create( IArtist artist )
        {
                var result = new ModelArtist( );

                result.CopyProperties( artist );

                return result;
        }
}