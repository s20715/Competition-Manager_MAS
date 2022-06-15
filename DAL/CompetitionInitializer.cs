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
            var game2 = new Game { ID = 2,Name = "LoL", ReleaseDate = new DateTime(2013, 3, 1, 7, 0, 0).Date };
            var game3 = new Game { ID = 3, Name = "WoW", ReleaseDate = new DateTime(2008, 3, 1, 7, 0, 0).Date };
            context.Games.Add(game);
            context.Games.Add(game2);
            context.Games.Add(game3);
            context.SaveChanges();


            List<string> creators = new List<string>
            {
                "Juri Owsienko"
            };

            var rulebook1 = new Rulebook { ID = 1, Description = "A rulebook of a LAN in Sosnowiec 1939-45", Creators = creators };
            context.Rulebooks.Add(rulebook1);
            var mainOrganizer1 = new MainOrganizer {PESEL = "33344422211", Address = "ul. Wolfkego", Email = "org@gmail.com", FirstName = "Organizeusz", LastName = "Nowak" };
            var mainOrganizer2 = new MainOrganizer {PESEL = "12312312322", Address = "ul. Jana Pawła", Email = "333@gmail.com", FirstName = "Organek", LastName = "Nowakowski" };
            context.MainOrganizers.Add(mainOrganizer1);
            context.MainOrganizers.Add(mainOrganizer2);
            
            var competitions = new List<Competition> {
                new Competition{ID=1,Game=context.Games.Find(1),RegistrationStartDate=new DateTime(1939, 3, 1, 7, 0, 0).Date,MainOrganizer=mainOrganizer1,CurrentCompetitionState="zakończony"},//nie uda sie zapisać zmian bez MainOragnizer
                new Competition{ID=2,Game=context.Games.Find(1),RegistrationStartDate=new DateTime(1940, 3, 1, 7, 0, 0).Date,MainOrganizer=mainOrganizer1,Rulebook =rulebook1,CurrentCompetitionState="zakończony"},
                new Competition{ID=3,Game=context.Games.Find(1),RegistrationStartDate=new DateTime(1941, 3, 1, 7, 0, 0).Date,RegistrationEndDate=new DateTime(1939, 5, 1, 7, 0, 0).Date,StartDate=new DateTime(1939, 6, 1, 7, 0, 0).Date,EndDate=new DateTime(1939, 7, 1, 7, 0, 0).Date,MainOrganizer=mainOrganizer1,CurrentCompetitionState="zakończony"}
            };
            competitions.ForEach(x => context.Competitions.Add(x));
            context.SaveChanges();
            context.Competitions.Find(2).Helpers.Add(context.Helpers.Find(3));
            context.Competitions.Find(2).Helpers.Add(context.Helpers.Find(4));
            context.SaveChanges();
            //BAG
            
            var contribution = new Contribution { ID = 1, Amount = 100000, Contributor = "Andrzej Piaseczny" };
            context.Contributions.Add(contribution);
            var bags = new List<BagContribution>
            {
                new BagContribution {ID=1, Contribution=context.Contributions.Find(1)},
                new BagContribution {ID=2, Contribution=context.Contributions.Find(1)},
                new BagContribution {ID=3 ,Contribution=context.Contributions.Find(1)}
            };

            context.Competitions.Find(1).BagContributions.Add(bags[0]);
            context.Competitions.Find(1).BagContributions.Add(bags[1]);
            context.Competitions.Find(1).BagContributions.Add(bags[2]);
            context.SaveChanges();

            var participants = new List<Participant>
            {
                new Participant{FirstName="Andrzej",LastName="Wójcik",DateOfBirth=new DateTime(2000, 3, 1, 7, 0, 0).Date,Email="AW@gmail.com"},
                new Participant{FirstName="Błażej",LastName="Wójcik",DateOfBirth=new DateTime(2000, 3, 1, 7, 0, 0).Date,Email="BW@gmail.com"}
            };
            participants.ForEach(x => context.Participants.Add(x));
            context.SaveChanges();
            var guests = new List<Guest>
            {
                new Guest{FirstName="Grzegorz",LastName="Brzęczeszczykiewicz",},
                new Guest{FirstName="Maciej",LastName="Dąbrowski",}
            };
            guests.ForEach(x => context.Guests.Add(x));
            context.SaveChanges();
            var captain = new Captain { FirstName = "Jakub", LastName = "Wójcik", DateOfBirth = new DateTime(2000, 2, 1, 7, 0, 0).Date, Email = "jw2@gmail.com", TelephoneNumber = 666555666 };
            var t1 = new Team { };
            context.Captains.Add(captain);
            context.SaveChanges();
            //context.Teams.Add(t1);

        }
        
    

    }
}