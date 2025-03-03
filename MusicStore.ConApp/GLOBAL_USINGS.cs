﻿///   C O N S O L E   A P P L I C A T I O N   -   U S I N G S   ///


///   S Y S T E M   ///
global using System;
global using System.Linq;
global using System.Text;
global using System.Drawing;
global using System.Threading.Tasks;
global using System.Linq.Dynamic.Core;
global using System.Collections.Generic;


///   E N T I T Y   F R A M E W O R K   ///
global using Microsoft.EntityFrameworkCore;
global using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


///   M u s i c S t o r e   ///
//   - Logic   
global using MusicStore.Logic;
global using MusicStore.Logic.Entities;
//
global using Genre = MusicStore.Logic.Entities.Genre;
global using Album = MusicStore.Logic.Entities.Album;
global using Track = MusicStore.Logic.Entities.Track;
global using Artist = MusicStore.Logic.Entities.Artist;
//
global using Factory = MusicStore.Logic.DataContext.Factory;
global using IContext = MusicStore.Logic.Contracts.IContext;
global using TEntity = MusicStore.Logic.Entities.EntityObject;

///   E X T E N S I O N S   ///
global using MusicStore.Logic.Extensions;


///   N A M E S P A C E   ///
namespace MusicStore.ConApp;

public static class GLOBAL_USINGS { }