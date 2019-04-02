using Api.Models;

namespace Api.Interfaces
{
    public interface ICourseService : IServiceBase
    {
        bool SaveSubjects(int id, int[] subjects);
    }
}