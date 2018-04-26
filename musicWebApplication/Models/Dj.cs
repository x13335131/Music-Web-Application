using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using musicWebApplication;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace musicWebApplication.Models

{
    public class Dj
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DjId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        public virtual ICollection<Tune> Tunes
        {
            get; set;
        }
    }
}