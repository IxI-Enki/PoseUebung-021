﻿///   L O G I C   -   U S I N G S   ///


///   S Y S T E M   ///
global using System;
global using System.Linq;
global using System.Text;
global using System.Drawing;
global using System.Threading.Tasks;
global using System.Collections.Generic;
//
global using System.ComponentModel.DataAnnotations;
global using System.ComponentModel.DataAnnotations.Schema;
//
global using Assembly = System.Reflection.Assembly;


///   E N T I T Y   F R A M E W O R K   ///
global using Microsoft.EntityFrameworkCore;
global using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


///   M u s i c S t o r e   ///
//   - Logic   
global using MusicStore.Logic;
global using MusicStore.Logic.Entities;
global using MusicStore.Logic.Contracts;
//
global using Track = MusicStore.Logic.Entities.Track;
global using Album = MusicStore.Logic.Entities.Album;
global using Genre = MusicStore.Logic.Entities.Genre;
global using Artist = MusicStore.Logic.Entities.Artist;

///   E X T E N S I O N S   ///
global using MusicStore.Logic.Extensions;


///   N A M E S P A C E   ///
namespace MusicStore.Logic;

public static class GLOBAL_USINGS
{

        public static string Seperator_Line( ) => new( '─' , Console.WindowWidth );
        public static string Seperator_Dotted( ) => new( '┄' , Console.WindowWidth );
        public static string Seperator_Strokes( ) => new( '╌' , Console.WindowWidth );
        public static string Seperator_Double( ) => new( '═' , Console.WindowWidth );
        public static string Seperator_Bold( ) => new( '━' , Console.WindowWidth );

}