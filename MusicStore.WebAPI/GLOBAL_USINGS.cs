///   A S P   N E T   -   U S I N G S   ///


///   S Y S T E M   ///
global using System.Linq.Dynamic.Core;
global using System.Text.Json;
global using System.Web;

///   A S P   N E T   ///
global using Microsoft.AspNetCore;
global using Microsoft.AspNetCore.Mvc;


///   E N T I T Y   F R A M E W O R K   ///
global using Microsoft.EntityFrameworkCore;


///   M u s i c S t o r e   ///
//   - Logic   
global using MusicStore.Logic.Entities;
global using MusicStore.Logic.Contracts;
//
global using Genre = MusicStore.Logic.Entities.Genre;
global using Album = MusicStore.Logic.Entities.Album;
global using Track = MusicStore.Logic.Entities.Track;
global using Artist = MusicStore.Logic.Entities.Artist;
global using EntityObject = MusicStore.Logic.Entities.EntityObject;
//
global using IGenre = MusicStore.Logic.Contracts.IGenre;
global using IAlbum = MusicStore.Logic.Contracts.IAlbum;
global using ITrack = MusicStore.Logic.Contracts.ITrack;
global using IArtist = MusicStore.Logic.Contracts.IArtist;
global using IContext = MusicStore.Logic.Contracts.IContext;
global using IIdentifiable = MusicStore.Logic.Contracts.IIdentifiable;
//
global using Factory = MusicStore.Logic.DataContext.Factory;
global using CredLoader = MusicStore.Logic.DataContext.DataLoader.CredentialLoader;

//   - WebAPI   
global using TGenre = MusicStore.WebAPI.Models.ModelGenre;
global using TAlbum = MusicStore.WebAPI.Models.ModelAlbum;
global using TTrack = MusicStore.WebAPI.Models.ModelTrack;
global using TArtist = MusicStore.WebAPI.Models.ModelArtist;
//
global using MusicStore.WebAPI;
global using MusicStore.WebAPI.Models;
global using MusicStore.WebAPI.Contracts;
global using MusicStore.WebAPI.Controllers;
//
global using ModelObject = MusicStore.WebAPI.Models.ModelObject;


///   N A M E S P A C E   ///
namespace MusicStore.WebAPI;

public static class GLOBAL_USINGS
{
        public static readonly int MAX_COUNT = 500;
}