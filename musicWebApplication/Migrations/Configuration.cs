namespace musicWebApplication.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<musicWebApplication.Models.MusicLibrary>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(musicWebApplication.Models.MusicLibrary context)
        {
            context.Djs.AddOrUpdate(
              new Dj { Name = "Andrew Peters", DjId = 1, Genre = "Dance" },
              new Dj { Name = "Steve Angello", DjId = 2, Genre = "Dance" },
              new Dj { Name = "Lovely Laura", DjId = 3, Genre = "Dance" }
              );


           
            context.Tunes.AddOrUpdate(
            new Tune { TuneId = 1, Name = "Purpose", SongName = "Sorry" , DjId = 1},
            new Tune { TuneId = 2, Name = "Dance Hits", SongName = "Countdown" , DjId = 1},
            new Tune { TuneId = 3, Name = "Party Anthems", SongName = "Destination Unknown" , DjId = 1}
            );



            context.Clubs.AddOrUpdate(
           new Club { ClubId = 1, Name = "Dj Damo", ClubName = "Howl On The Moon", Price=8.00M, Established= new DateTime(2017,9,5), DjId = 1},
           new Club { ClubId = 2, Name = "John O'Callaghan", ClubName = "Wrights Venue", Price = 20.00M, Established = new DateTime(2017,8,8) , DjId=1},
           new Club { ClubId = 3, Name = "Elliot", ClubName = "Hanger", Price = 8.00M, Established = new DateTime(2017,7,7) , DjId = 1}
      

         );

            context.Festivals.AddOrUpdate(
            new Festival { FestivalId = 1, Name = "Sea Sessions", Location = "Bray Pier", Date = "09/09/2017" , DjId = 1},
            new Festival { FestivalId = 2, Name = "Boxed Off Festival", Location = "Mullingar", Date = "09/06/2017" , DjId = 1},
            new Festival { FestivalId = 3, Name = "Cream", Location = "3 Arena", Date = "10/24/2017", DjId = 1 }


            );
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
