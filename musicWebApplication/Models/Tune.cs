using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace musicWebApplication.Models
{
    public class Tune
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TuneId { get; set; }
        public string Name { get; set; }
        public string SongName { get; set; }

        public int DjId { get; set; }

        [ForeignKey("DjId")]
        public virtual Dj Djs
        {
            get; set;
        }
    }
}
