### <p align="center"> Music Store with REST API </p>
---

<!--
<div align="center">

  | `classA` |"| card.A |"| `Rel.Type` | `Link` | `Rel.Type` |"| card.B |"| `classB` | : | `LabelText` |  
  |:--------:|-|:------:|-|:----------:|:------:|:----------:|-|:------:|-|:--------:|:-:|:-----------:|

  <details><summary>

  $\scriptsize{click\ for\ more\ syntax}$
  `Relation Type`
  </summary>

  | [*Relation Types*] |${\quad\ \ }$| [*Link Types*] |
  |:------------------:|-------|:--------------:|

  |  Type  |  Description  |${\ }$|  Type  |  Description  |
  |:------:|:-------------:|------|:------:|:-------------:|
  |   <\|  |  Inheritance  |${\ }$|   --   |     Solid     |
  |   \*   |  Composition  |${\ }$|   ..   |     Dashed    |
  |   o	   |  Aggregation  |${\ }$|        |               |
  |   ->   |  Association  |${\ }$|        |               |
  |  <-	   |  Association  |${\ }$|        |               |
  |  \|>   |  Realization  |${\ }$|        |               |

  </details>

</div>
-->


```mermaid
---
  config:
    class:
      hideEmptyMembersBox: true
---
classDiagram
  direction TB

  namespace Contracts{
    class IIdentifiable
    class IDisposable
    class IContext
    class IArtist
    class IAlbum
    class IGenre
    class ITrack
}
class IDisposable{
  <<interface>>
  + Dispose()
}
%%IDisposable "" --() "" IDisposable : is

class IContext{
  <<interface>>
  DbSet~Entities.Artist~ ArtistSet get;
  DbSet~Entities.Album~ AlbumSet get;
  DbSet~Entities.Genre~ GenreSet get;
  DbSet~Entities.Track~ TrackSet get;

  + int SaveChanges()
}
IContext "" .. "" IDisposable : implements
%%IContext "" ()-- "" IContext : is
%% IContext "1" o-- "0..*"  Artist : holds
%% IContext "1" o-- "0..*"  Album : holds
%% IContext "1" o-- "0..*"  Genre : holds
%% IContext "1" o-- "0..*"  Track : holds

%%─────────────────────────────────────

 class IArtist{
  <<interface>>
  %%───────────────────────────────────
  + string Name get; set;
}
%%IArtist "" --() "" IArtist : is
%%─────────────────────────────────────

class IAlbum{
  <<interface>>
  %%───────────────────────────────────
  + int ArtistId get; set;
  + string Title get; set;
}
%%IAlbum "" --() "" IAlbum : is
%%─────────────────────────────────────

class IGenre{
  <<interface>>
  %%───────────────────────────────────
  + string Name get; set;
}
%%IGenre "" --() "" IGenre : is
%%─────────────────────────────────────

class ITrack{
  <<interface>>
  %%───────────────────────────────────
  + int Bytes get; set;
  + int AlbumId get; set;
  + int GenreId get; set;
  + string Title get; set;
  + string Composer get; set;
  + int Milliseconds get; set;
  + double UnitPrice get; set;
}
%%ITrack "" --() "" ITrack : is
%%─────────────────────────────────────

class IIdentifiable{
  <<interface>>
  %%───────────────────────────────────
  + int Id get;
}
%% IIdentifiable "" ()-- "" IIdentifiable : is
IIdentifiable "" <|.. "" IArtist : implements
IIdentifiable "" <|.. "" IAlbum : implements
IIdentifiable "" <|.. "" IGenre : implements
IIdentifiable "" <|.. "" ITrack : implements


namespace Entities{
  class EntityObject
  class Artist
  class Genre
  class Album
  class Track
}
  class Track{

  }
  Track   "" --|> ""  EntityObject : is
 %% Track ..() ITrack : implements

  class Album{

  }
%%  Album ..() IAlbum : implements
  Album   "" --|> ""  EntityObject : is


  class Artist{

  }
%%  Artist ..() IArtist : implements
  Artist   "" --|> ""  EntityObject : is


  class Genre{

  }
  Genre   "" --|> ""  EntityObject : is
%%  Genre ..() IGenre : implements



  class EntityObject{
    <<abstract>>
    + int Id get; set;

    + CopyProperties(IIdentifiable other)
  }
  EntityObject   "" ..() ""  IIdentifiable : implements
  EntityObject "" ..() ""  IIdentifiable : uses

namespace DataContext{
  class MusicStoreContext
  class Factory
  }
  class Factory{
    <<static>>

    + IContext CreateContext()
  }
  Factory "1..1" ..> "0..*" MusicStoreContext : creates
 %% IContext ().. Factory : uses

  class MusicStoreContext{
    <<internal>>
    - static string conectionString
    + DbSet~Entities.Artist~ ArtistSet get; set;
    + DbSet~Entities.Album~ AlbumSet get; set;
    + DbSet~Entities.Genre~ GenreSet get; set;
    + DbSet~Entities.Track~ TrackSet get; set;

    protected override OnConfiguring(DbOptionSBuilder)
  }
  MusicStoreContext "" --|> "" DbContext : is
  MusicStoreContext "1" o-- "0..*"  Artist : holds
  MusicStoreContext "1" o-- "0..*"  Album : holds
  MusicStoreContext "1" o-- "0..*"  Genre : holds
  MusicStoreContext "1" o-- "0..*"  Track : holds
  MusicStoreContext --() IContext : implements


namespace EntityFramework{
  class DbContext
}
  class DbContext{
  }
  %% DbContext "" --() "" DbContext : is

namespace AspNetCore.Mvc{
  class ControllerBase
}
  class ControllerBase{
    <<abstract>>
  }
  note for ControllerBase "[ Controller ]"

namespace Models{
  class ModelObject
  class ModelArtist
  class ModelAlbum
  class ModelGenre
  class ModelTrack
}
  class ModelObject{
    <<abstract>>
     + int Id get; set;
     + virtual CopyProperties(IIdentifiable other)

  }
  ModelObject "" ..() ""  IIdentifiable : implements
  ModelObject "" ..()""  IIdentifiable : uses

  class ModelArtist{

  }
  ModelArtist --|> ModelObject : is
  IArtist ().. ModelArtist : implements

  class  ModelAlbum{

  }
  ModelAlbum --|> ModelObject : is
  IAlbum ().. ModelAlbum : implements

  class  ModelGenre{

  }
  ModelGenre --|> ModelObject : is
  IGenre ().. ModelGenre : iimplements

  class  ModelTrack{

  }
  ModelTrack --|> ModelObject : is
  ITrack ().. ModelTrack : implements


namespace Controllers{
  class MusicStoreController
}
  class MusicStoreController{
    +IEnumerable~TModel~ Get( )
    +TModel? Get( int id )
    + Post( [FromBody] TModel model )
    + Put( int id , [FromBody] TModel model )
    + Delete( int id )
  }
  MusicStoreController ..> TModel : using
  MusicStoreController "" --|> "" ControllerBase : is

  note for MusicStoreController "[ApiController]
  [Route(api/[controller])]
  using TModel = Models.Object;"

```
