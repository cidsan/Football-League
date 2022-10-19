using Football_League.Data.Context;
using Football_League.Data.Models;
using Football_League.Repository.TeamRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Football_League.UnitTests.Services
{
    [TestClass]
    public class TeamRepository_Should
    {
        [TestMethod]
        public async Task Correctly_Create_Team()
        {
            var contextOptions = new DbContextOptionsBuilder<FootballLeagueDbContext>()
                .UseInMemoryDatabase(databaseName: "Correctly_Create_Team")
                .Options;

            var teamToBeAdded = new Team()
            {
                Name = "test",
                GuestMatches = new List<Match>(),
                HostMatches = new List<Match>(),
                Points = 0,
                Rank = "test"
            };

            using (var actContext = new FootballLeagueDbContext(contextOptions))
            {
                actContext.Teams.Add(teamToBeAdded);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new FootballLeagueDbContext(contextOptions))
            {
                var team = await assertContext.Teams.FirstOrDefaultAsync();

                Assert.AreEqual(teamToBeAdded.Name, team.Name);
                Assert.AreEqual(teamToBeAdded.Points, team.Points);
                Assert.AreEqual(teamToBeAdded.Rank, team.Rank);
            }
        }

        [TestMethod]
        public async Task Correctly_Update_Team()
        {
            var contextOptions = new DbContextOptionsBuilder<FootballLeagueDbContext>()
                .UseInMemoryDatabase(databaseName: "Correctly_Update_Team")
                .Options;

            var teamToBeAdded = new Team()
            {
                Name = "test",
                GuestMatches = new List<Match>(),
                HostMatches = new List<Match>(),
                Points = 0,
                Rank = "test"
            };


            using (var actContext = new FootballLeagueDbContext(contextOptions))
            {
                actContext.Teams.Add(teamToBeAdded);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new FootballLeagueDbContext(contextOptions))
            {
                var team = await assertContext.Teams.FirstOrDefaultAsync();
                team.Name = "updatedTest";

                var SUT = new TeamRepository(assertContext);
                var updatedTeam = await SUT.UpdateAsync(team);

                Assert.AreEqual(updatedTeam.Name, team.Name);

            }
        }

        [TestMethod]
        public async Task Correctly_Delete_Team()
        {
            var contextOptions = new DbContextOptionsBuilder<FootballLeagueDbContext>()
                    .UseInMemoryDatabase(databaseName: "Correctly_Delete_Team")
                    .Options;

            var teamToBeAdded = new Team()
            {
                Name = "test",
                GuestMatches = new List<Match>(),
                HostMatches = new List<Match>(),
                Points = 0,
                Rank = "test"
            };


            using (var actContext = new FootballLeagueDbContext(contextOptions))
            {
                actContext.Teams.Add(teamToBeAdded);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new FootballLeagueDbContext(contextOptions))
            {
                var team = await assertContext.Teams.FirstOrDefaultAsync();

                var SUT = new TeamRepository(assertContext);
                await SUT.DeleteAsync(team);

                var emptyTeam = await assertContext.Teams.FirstOrDefaultAsync();

                Assert.IsNull(emptyTeam);

            }
        }

        [TestMethod]
        public async Task Correctly_Get_Team()
        {
            var contextOptions = new DbContextOptionsBuilder<FootballLeagueDbContext>()
                    .UseInMemoryDatabase(databaseName: "Correctly_Delete_Team")
                    .Options;

            var teamToBeAdded = new Team()
            {
                Name = "test",
                GuestMatches = new List<Match>(),
                HostMatches = new List<Match>(),
                Points = 0,
                Rank = "test"
            };


            using (var actContext = new FootballLeagueDbContext(contextOptions))
            {
                actContext.Teams.Add(teamToBeAdded);
                await actContext.SaveChangesAsync();
            }

            using (var assertContext = new FootballLeagueDbContext(contextOptions))
            {
                var addedTeam = await assertContext.Teams.FirstOrDefaultAsync();

                var SUT = new TeamRepository(assertContext);
                var team = await SUT.GetAsync(addedTeam.Id);

                Assert.AreEqual(addedTeam.Id, team.Id);
                Assert.AreEqual(addedTeam.Name, team.Name);

            }
        }
    }
}
