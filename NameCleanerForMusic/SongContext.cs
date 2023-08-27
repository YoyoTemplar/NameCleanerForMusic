using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Numerics;


namespace NameCleanerForMusic
{
    public class SongContext : DbContext
    {
    public SongContext() : base("DBConnection")
        { 
            //для создания бд если она не существует
            //if (!Database.Exists())
            //{
            //    Database.Create();
            //}
        }

        public DbSet<Song> Songs { get; set; }
    }
}
