using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPIStore.Models
{
    [Table("MusicTB")]
    public class MusicTB
    {
        [Key]
        public long MusicID { get; set; }
        public string MusicLabel { get; set; }
        public string MovieName { get; set; }
        public string Lyricist { get; set; }
        public string Singer { get; set; }
        public string SongName { get; set; }
    }
}
