using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Models;
using Api.Infrastructure.Helpers;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    public class CourseController : Controller<Course>
    {
        public CourseController(ICourseService service): base(service) { }

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
    }
}
