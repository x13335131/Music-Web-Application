using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace musicWebApplication.Models
{
    public class DjDTO
    {
        public int DjId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        public List<TuneDTO> Tunes { get; set; }
    }
}