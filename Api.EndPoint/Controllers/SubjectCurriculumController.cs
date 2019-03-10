using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Models;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    public class SubjectCurriculumController : Controller<SubjectCurriculum>
    {
        public SubjectCurriculumController(ISubjectCurriculumService service): base(service) { }
    }
}
