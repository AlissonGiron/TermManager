using Api.Infrastructure;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class ClassService : ServiceBase, IClassService
    {
        public ClassService(Context context) : base(context) {}

        public override void Create<T>(T entity)
        {
            Class _entity = entity as Class;

            



            _context.Add(entity);
        }
    }
}