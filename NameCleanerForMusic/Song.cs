using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data.Entity;

namespace NameCleanerForMusic
{
    public class Song
    {
        public int Id { get; set; }
        public string OldName { get; set; }
        public string NewName { get; set; }
        public DateTime DateOfChange { get; set; }
        public string Path { get; set; }
    }
}
