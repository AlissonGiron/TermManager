using Microsoft.EntityFrameworkCore;
using Api.Infrastructure;
using Api.Services;
using Api.Models;
using Xunit;

namespace Api.Tests {
    public class CourseTests {
        private CourseService _service;
        private Context _context;

        public CourseTests() {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "CourseTestDatabase")
                .Options;

            _context = new Context(options);
            _service = new CourseService(_context);
        }

        [Fact]
        public void ExampleTest()
        {
            _service.Create(new Course());
            _service.Save();

            Course item = _service.FirstOrDefault<Course>();

            Assert.True(item.Id == 1, "Erro");
        }
    }
}