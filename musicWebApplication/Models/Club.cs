using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace musicWebApplication.Models
    
{
    public class Club
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClubId { get; set; }

        public string Name { get; set; }

        public string ClubName { get; set; }

        public decimal Price { get; set; }

        public DateTime Established { get; set; }

        [Display(Name = "Dj Name")]
        public int DjId { get; set; }

        [ForeignKey("DjId")]
        public virtual Dj Djs
        {
            get; set;
        }
    }
}