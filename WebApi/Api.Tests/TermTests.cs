using Microsoft.EntityFrameworkCore;
using Api.Infrastructure;
using Api.Services;
using Api.Models;
using Xunit;

namespace Api.Tests {
    public class TermTests {
        private TermService _service;
        private Context _context;

        public TermTests() {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "TermTestDatabase")
                .Options;

            _context = new Context(options);
            _service = new TermService(_context);
        }

        [Fact]
        public void ExampleTest()
        {
            _service.Create(new Term());
            _service.Save();

            Term item = _service.FirstOrDefault<Term>();

            Assert.True(item.Id == 1, "Erro");
        }
    }
}