using Microsoft.EntityFrameworkCore;
using Api.Infrastructure;
using Api.Services;
using Api.Models;
using Xunit;

namespace Api.Tests {
    public class CompetenceTests {
        private CompetenceService _service;
        private Context _context;

        public CompetenceTests() {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "CompetenceTestDatabase")
                .Options;

            _context = new Context(options);
            _service = new CompetenceService(_context);
        }

        [Fact]
        public void ExampleTest()
        {
            _service.Create(new Competence());
            _service.Save();

            Competence item = _service.FirstOrDefault<Competence>();

            Assert.True(item.Id == 1, "Erro");
        }
    }
}