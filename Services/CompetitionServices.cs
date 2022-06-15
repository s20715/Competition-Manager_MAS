using CompetitionManager.DAL;
using CompetitionManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompetitionManager.Services
{
    public class CompetitionServices
    {
        private CompetitionContext _competitionContext;
        public CompetitionServices(CompetitionContext competitionContext)
        {
            _competitionContext = competitionContext;
        }
       
    }
}