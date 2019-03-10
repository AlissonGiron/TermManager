using Microsoft.EntityFrameworkCore;
using Api.Infrastructure;
using Api.Services;
using Api.Models;
using Xunit;

namespace Api.Tests {
    public class UserTests {
        private UserService _service;
        private Context _context;

        public UserTests() {
            var options = new DbContextOptionsBuilder<Context>()
                .UseInMemoryDatabase(databaseName: "UserTestDatabase")
                .Options;

            _context = new Context(options);
            _service = new UserService(_context);
        }

        [Fact]
        public void ExampleTest()
        {
            _service.Create(new User());
            _service.Save();

            User item = _service.FirstOrDefault<User>();

            Assert.True(item.Id == 1, "Erro");
        }
    }
}