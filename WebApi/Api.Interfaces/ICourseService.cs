using Api.Models;

namespace Api.Interfaces
{
    public interface ICourseService : IServiceBase
    {
        bool SaveSubjects(int id, int[] subjects);
        bool SaveCoordinators(int id, int[] coordinators);
        bool SaveNDE(int id, int[] NDE);
    }
}