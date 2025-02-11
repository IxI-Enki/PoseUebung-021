///   A S P   N E T   -   U S I N G S   ///


///__ A S P   N E T __
global using Microsoft.AspNetCore;
global using Microsoft.AspNetCore.Mvc;

///__ E N T I T Y   F R A M E W O R K __
global using Microsoft.EntityFrameworkCore;


///   M u s i c S t o r e   ///
//   - Logic   
global using MusicStore.Logic.Entities;
global using MusicStore.Logic.Contracts;
//
global using IGenre = MusicStore.Logic.Contracts.IGenre;
global using IAlbum = MusicStore.Logic.Contracts.IAlbum;
global using ITrack = MusicStore.Logic.Contracts.ITrack;
global using IArtist = MusicStore.Logic.Contracts.IArtist;
//
global using Factory = MusicStore.Logic.DataContext.Factory;

//   - WebAPI   
global using MusicStore.WebAPI;
global using MusicStore.WebAPI.Controllers;
global using MusicStore.WebAPI.Models;
global using MusicStore.WebAPI.Contracts;




///   N A M E S P A C E   ///
namespace MusicStore.WebAPI;

public static class GLOBAL_USINGS
{
        public static readonly int MAX_COUNT = 500;
}