using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace musicWebApplication.Models
{
    public class TuneDTO
    {
        public int TuneId { get; set; }
        public string Name { get; set; }
        public string SongName { get; set; }

        public int DjId { get; set; }

        public List<DjDTO> Djs { get; set; }
    }
}