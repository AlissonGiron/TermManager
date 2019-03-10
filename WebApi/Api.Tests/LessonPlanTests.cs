using Microsoft.EntityFrameworkCore;
using Api.Infrastructure;
using Api.Services;
using Api.Models;
using Xunit;

namespace Api.Tests {
    public class LessonPlanTests {
        private LessonPlanService _service;
        private Context _context;

        public LessonPlanTests() {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "LessonPlanTestDatabase")
                .Options;

            _context = new Context(options);
            _service = new LessonPlanService(_context);
        }

        [Fact]
        public void ExampleTest()
        {
            _service.Create(new LessonPlan());
            _service.Save();

            LessonPlan item = _service.FirstOrDefault<LessonPlan>();

            Assert.True(item.Id == 1, "Erro");
        }
    }
}