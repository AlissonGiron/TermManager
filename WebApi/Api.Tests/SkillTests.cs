using Microsoft.EntityFrameworkCore;
using Api.Infrastructure;
using Api.Services;
using Api.Models;
using Xunit;

namespace Api.Tests {
    public class SkillTests {
        private SkillService _service;
        private Context _context;

        public SkillTests() {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "SkillTestDatabase")
                .Options;

            _context = new Context(options);
            _service = new SkillService(_context);
        }

        [Fact]
        public void ExampleTest()
        {
            _service.Create(new Skill());
            _service.Save();

            Skill item = _service.FirstOrDefault<Skill>();

            Assert.True(item.Id == 1, "Erro");
        }
    }
}