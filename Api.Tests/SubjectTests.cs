using Microsoft.EntityFrameworkCore;
using Api.Infrastructure;
using Api.Services;
using Api.Models;
using Xunit;

namespace Api.Tests {
    public class SubjectTests {
        private SubjectService _service;
        private Context _context;

        public SubjectTests() {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "SubjectTestDatabase")
                .Options;

            _context = new Context(options);
            _service = new SubjectService(_context);
        }

        [Fact]
        public void ExampleTest()
        {
            _service.Create(new Subject());
            _service.Save();

            Subject item = _service.FirstOrDefault<Subject>();

            Assert.True(item.Id == 1, "Erro");
        }
    }
}