///   N A M E S P A C E   ///
namespace MusicStore.WebAPI.Contracts;


public interface IContextAccessor<TEntity>

        where TEntity : EntityObject, new()
{

        IContext GetContext( );

        DbSet<TEntity>? GetDbSet( );
}