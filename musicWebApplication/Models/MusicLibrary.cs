using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using musicWebApplication;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace musicWebApplication.Models
{
    public class MusicLibrary : DbContext
    {
        public MusicLibrary() : base("name=MusicLibraryContext")
        {

        }
        public DbSet<Festival> Festivals { get; set; }
        public DbSet<Dj> Djs { get; set; }
        public DbSet<Tune> Tunes { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }


    }
    public class Review
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ReviewId { get; set; }

        [Display(Name ="Festival")]
        public int FestivalId { get; set; }

        public string Content { get; set; }

        [Display(Name ="User")]
        public string UserId { get; set; }

        [ForeignKey("FestivalId")]
        public virtual Festival festival { get; set; }
    }
}