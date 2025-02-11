///__ A S P   N E T __
global using Microsoft.AspNetCore;
global using Microsoft.AspNetCore.Mvc;

///__ E N T I T Y   F R A M E W O R K __
global using Microsoft.EntityFrameworkCore;


///__ M U S I C S T O R E __

//   Logic   
global using Factory = MusicStore.Logic.DataContext.Factory;

global using IArtist = MusicStore.Logic.Contracts.IArtist;
global using IGenre = MusicStore.Logic.Contracts.IGenre;
global using IAlbum = MusicStore.Logic.Contracts.IAlbum;
global using ITrack = MusicStore.Logic.Contracts.ITrack;


//   Web API   
namespace MusicStore.WebAPI;

public static class Global
{
        public static readonly int MAX_COUNT = 500;
}