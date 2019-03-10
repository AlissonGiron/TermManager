using Microsoft.EntityFrameworkCore;
using Api.Infrastructure;
using Api.Services;
using Api.Models;
using Xunit;

namespace Api.Tests {
    public class ClassTests {
        private ClassService _service;
        private Context _context;

        public ClassTests() {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "ClassTestDatabase")
                .Options;

            _context = new Context(options);
            _service = new ClassService(_context);
        }

        [Fact]
        public void ExampleTest()
        {
            _service.Create(new Class());
            _service.Save();

            Class item = _service.FirstOrDefault<Class>();

            Assert.True(item.Id == 1, "Erro");
        }
    }
}