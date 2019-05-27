using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Models;
using Api.Infrastructure.Helpers;
using System.Linq;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    public class CourseController : Controller<Course>
    {
        ICourseService service => (ICourseService)_service;

        public CourseController(ICourseService service): base(service) { }

        [HttpGet("CheckCodeExists/{id}/{code}")]
        public IActionResult CheckCodeExists(int id, string code) => Ok(_service.Count(new Query<Course>().Filter(s => s.Code == code && s.Id != id)) > 0);

        [HttpGet("CourseSubject/{id}")]
        public virtual IActionResult ReadSubject(int id) => Read(new Query<Subject>().Filter(s => id > 0 ? s.Courses.Any(v => v.IdCourse == id) : true).Track(false));

        [HttpPut("CourseSubject/{id}")]
        public virtual IActionResult SaveSubjects(int id, [FromBody] int[] subjects) => Ok(service.SaveSubjects(id, subjects));

        // Skill

        [HttpGet("CourseSkill/{id}")]
        public virtual IActionResult ReadSkill(int id) => Read(new Query<Skill>().Filter(s => s.IdCourse == id));

        [HttpPost("CourseSkill/{id}")]
        public virtual IActionResult CreateSkill(int id, [FromBody] Skill entity)
        {
            entity.IdCourse = id;
            return Create(entity);
        }

        [HttpPut("CourseSkill/{id}")]
        public virtual IActionResult EditSkill(int id, [FromBody] Skill entity)
        {
            entity.Id = id;
            return Edit(entity);
        }

        [HttpDelete("CourseSkill/{id}")]
        public virtual IActionResult DeleteSkill(int id) => Delete(_service.FirstOrDefault<Skill>(s => s.Id == id));

        // Competence

        [HttpGet("CourseCompetence/{id}")]
        public virtual IActionResult ReadCompetence(int id) => Read(new Query<Competence>().Filter(s => s.IdCourse == id));
        
        [HttpPost("CourseCompetence/{id}")]
        public virtual IActionResult CreateCompetence(int id, [FromBody] Competence entity)
        {
            entity.IdCourse = id;
            return Create(entity);
        }

        [HttpPut("CourseCompetence/{id}")]
        public virtual IActionResult EditCompetence(int id, [FromBody] Competence entity)
        {
            entity.Id = id;
            return Edit(entity);
        }

        [HttpDelete("CourseCompetence/{id}")]
        public virtual IActionResult DeleteCompetence(int id) => Delete(_service.FirstOrDefault<Competence>(s => s.Id == id));

        // Goal

        [HttpGet("CourseGoal/{id}")]
        public virtual IActionResult ReadGoal(int id) => Read(new Query<Goal>().Filter(s => s.IdCourse == id));

        [HttpPost("CourseGoal/{id}")]
        public virtual IActionResult CreateGoal(int id, [FromBody] Goal entity)
        {
            entity.IdCourse = id;
            return Create(entity);
        }

        [HttpPut("CourseGoal/{id}")]
        public virtual IActionResult EditGoal(int id, [FromBody] Goal entity)
        {
            entity.Id = id;
            return Edit(entity);
        }

        [HttpDelete("CourseGoal/{id}")]
        public virtual IActionResult DeleteGoal(int id) => Delete(_service.FirstOrDefault<Goal>(s => s.Id == id));

        // NDE Members
        [HttpGet("CourseNDEMember/{id}")]
        public virtual IActionResult ReadNDEMember(int id) => Read(new Query<NDEMember>().Filter(s => s.IdCourse == id));

        [HttpPost("CourseNDEMember/{id}")]
        public virtual IActionResult CreateNDEMember(int id, [FromBody] NDEMember entity)
        {
            entity.IdCourse = id;
            return Create(entity);
        }

        [HttpPut("CourseNDEMember/{id}")]
        public virtual IActionResult EditNDEMember(int id, [FromBody] NDEMember entity)
        {
            entity.Id = id;
            return Edit(entity);
        }

        [HttpDelete("CourseNDEMember/{id}")]
        public virtual IActionResult DeleteNDEMember(int id) => Delete(_service.FirstOrDefault<NDEMember>(s => s.Id == id));


        // Books
        [HttpGet("CourseBook/{id}")]
        public virtual IActionResult ReadBook(int id) => Read(new Query<Book>().Filter(s => s.IdCourse == id));

        [HttpPost("CourseBook/{id}")]
        public virtual IActionResult CreateBook(int id, [FromBody] Book entity)
        {
            entity.IdCourse = id;
            return Create(entity);
        }

        [HttpPut("CourseBook/{id}")]
        public virtual IActionResult EditBook(int id, [FromBody] Book entity)
        {
            entity.Id = id;
            return Edit(entity);
        }

        [HttpDelete("CourseBook/{id}")]
        public virtual IActionResult DeleteBook(int id) => Delete(_service.FirstOrDefault<Book>(s => s.Id == id));

    }
}
