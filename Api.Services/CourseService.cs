using Api.Infrastructure;
using Api.Interfaces;
using Api.Models;

namespace Api.Services
{
    public class CourseService : ServiceBase, ICourseService
    {
        public CourseService(Context context) : base(context) {}
    }
}