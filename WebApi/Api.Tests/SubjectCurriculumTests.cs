using Microsoft.EntityFrameworkCore;
using Api.Infrastructure;
using Api.Services;
using Api.Models;
using Xunit;

namespace Api.Tests {
    public class SubjectCurriculumTests {
        private SubjectCurriculumService _service;
        private Context _context;

        public SubjectCurriculumTests() {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "SubjectCurriculumTestDatabase")
                .Options;

            _context = new Context(options);
            _service = new SubjectCurriculumService(_context);
        }

        [Fact]
        public void ExampleTest()
        {
            _service.Create(new SubjectCurriculum());
            _service.Save();

            SubjectCurriculum item = _service.FirstOrDefault<SubjectCurriculum>();

            Assert.True(item.Id == 1, "Erro");
        }
    }
}