using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace musicWebApplication.Models
{
    public class Festival
    {
        public Festival()
        {
            this.reviews = new HashSet<Review>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FestivalId { get; set; }
        public string Name { get; set; }
        public string Location { get; set;}
        public string Date { get; set; }

        [Display(Name ="Dj Name")]
        public int DjId { get; set; }

        [ForeignKey("DjId")]        
        public virtual Dj dj { get; set; }


        public virtual ICollection<Review> reviews { get; set; }
    }
}