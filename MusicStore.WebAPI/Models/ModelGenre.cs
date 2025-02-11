namespace MusicStore.WebAPI.Models;

public class ModelGenre : ModelObject, IGenre
{
        public string Name { get; set; } = string.Empty;

        public virtual void CopyProperties( IGenre other )
        {
                base.CopyProperties( other );

                Name = other.Name;
        }
                
        public static ModelGenre Create( IGenre genre )
        {
                var result = new ModelGenre( );

                result.CopyProperties( genre );

                return result;
        }
}
