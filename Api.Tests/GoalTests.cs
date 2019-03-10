using Microsoft.EntityFrameworkCore;
using Api.Infrastructure;
using Api.Services;
using Api.Models;
using Xunit;

namespace Api.Tests {
    public class GoalTests {
        private GoalService _service;
        private Context _context;

        public GoalTests() {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "GoalTestDatabase")
                .Options;

            _context = new Context(options);
            _service = new GoalService(_context);
        }

        [Fact]
        public void ExampleTest()
        {
            _service.Create(new Goal());
            _service.Save();

            Goal item = _service.FirstOrDefault<Goal>();

            Assert.True(item.Id == 1, "Erro");
        }
    }
}