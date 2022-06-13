using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using CompetitionManager.Models;

namespace CompetitionManager.DAL
{
    public class CompetitionInitializer : System.Data.Entity.DropCreateDatabaseAlways<CompetitionContext>
    {

        protected override void Seed(CompetitionContext context)
        {

            
        
            
            var helpers = new List<Helper>
            {
                new Helper{ID=1,PESEL="88010227648",Address="Płocka",Email="Andrew@gmail.com",FirstName="Andrzej",LastName="Wiśniewski"},
                new Helper{ID=2,PESEL="03260369292",Address="Wolfkego",Email="BW@gmail.com",FirstName="Błażej",LastName="Wójcik"},
                new Helper{ID=3,PESEL="93070311561",Address="Szkolna",Email="KarKow@gmail.com",FirstName="Karyna",LastName="Kowalska"},
                new Helper{ID=4,PESEL="47042487556",Address="Rajska",Email="Jssa@gmail.com",FirstName="Jessica",LastName="Bentley"},
                new Helper{ID=5,PESEL="66061165773",Address="Al. Jana Pawła II",Email="JP2@gmail.com",FirstName="Maciek",LastName="Spocony"}
            };
            helpers.ForEach(x => context.Helpers.Add(x));
            context.SaveChanges();
            
            var game = new Game { ID = 1, Name = "Counter strike", ReleaseDate = new DateTime(2010, 3, 1, 7, 0, 0).Date };
            context.Games.Add(game);
            context.SaveChanges();


            List<string> creators = new List<string>
            {
                "Juri Owsienko"
            };

            var rulebook1 = new Rulebook { ID = 1, Description = "A rulebook of a LAN in Sosnowiec 1939-45", Creators = creators };
            context.Rulebooks.Add(rulebook1);
            var mainOrganizer1 = new MainOrganizer { ID = 6, PESEL = "33344422211", Address = "ul. Wolfkego", Email = "org@gmail.com", FirstName = "Organizeusz", LastName = "Nowak" };
            context.MainOrganizers.Add(mainOrganizer1);
            

            var competitions = new List<Competition> {
                new Competition{ID=1,Game=context.Games.Find(1),RegistrationStartDate=new DateTime(1939, 3, 1, 7, 0, 0).Date,Rulebook =rulebook1,MainOrganizer=mainOrganizer1},//nie uda sie zapisać zmian bez MainOragnizer
                new Competition{ID=2,Game=context.Games.Find(1),RegistrationStartDate=new DateTime(1940, 3, 1, 7, 0, 0).Date,Rulebook=rulebook1,MainOrganizer=mainOrganizer1},
                new Competition{ID=3,Game=context.Games.Find(1),RegistrationStartDate=new DateTime(1941, 3, 1, 7, 0, 0).Date,RegistrationEndDate=new DateTime(1939, 5, 1, 7, 0, 0).Date,StartDate=new DateTime(1939, 6, 1, 7, 0, 0).Date,EndDate=new DateTime(1939, 7, 1, 7, 0, 0).Date,Rulebook=rulebook1,MainOrganizer=mainOrganizer1}
            };
            competitions.ForEach(x => context.Competitions.Add(x));
            context.SaveChanges();
            context.Competitions.Find(2).Helpers.Add(context.Helpers.Find(3));
            context.Competitions.Find(2).Helpers.Add(context.Helpers.Find(4));
            context.SaveChanges();
            
        }
        
    

    }
}