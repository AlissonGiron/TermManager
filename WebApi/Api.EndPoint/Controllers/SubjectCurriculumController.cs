using Microsoft.AspNetCore.Mvc;
using Api.Interfaces;
using Api.Models;
using Api.Infrastructure.Helpers;
using System.Linq;
using Newtonsoft.Json;
using System;

namespace Api.EndPoint.Controllers
{
    [ApiController]
    public class SubjectCurriculumController : Controller<SubjectCurriculum>
    {
        public SubjectCurriculumController(ISubjectCurriculumService service): base(service) { }

        [HttpGet("GetCourses/{id}")]
        public virtual IActionResult GetCourses(int id) => Read(new Query<Course>().Track(false));

        [HttpGet("GetSubjects/{id}")]
        public virtual IActionResult GetSubjects(int id) => Read(new Query<Subject>().Track(false));

        protected override IActionResult Create<TItem>(TItem entity)
        {
            try
            {
                SubjectCurriculum model = entity as SubjectCurriculum;

                model.Bibliography.ForEach(s => s.Book = null);
                model.Goals.ForEach(s => s.Goal = null);
                model.Skills.ForEach(s => s.Skill = null);
                model.Competences.ForEach(s => s.Competence = null);
                model.NDEMembers.ForEach(s => s.NDEMember = null);

                _service.Create(model);
                _service.Save();

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public override IActionResult Get(int id)
        {
            var model = _service.FirstOrDefault(new Query<SubjectCurriculum>().Track(false).Filter(s => s.Id == id)
                .Include(s => s.NDEMembers.Select(v => v.NDEMember))
                .Include(s => s.Skills.Select(v => v.Skill))
                .Include(s => s.Goals.Select(v => v.Goal))
                .Include(s => s.Competences.Select(v => v.Competence))
                .Include(s => s.Bibliography.Select(v => v.Book))
                .Include(s => s.Course)
                .Include(s => s.Subject)
                .Include(s => s.Professor)
            );

            return new JsonResult(new { Model = model }, new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
        }

        [HttpGet("GetCollections/{idCourse}/{idSubject}")]
        public virtual IActionResult ReadCollections(int idCourse, int idSubject) {

            var course = _service.FirstOrDefault(new Query<Course>().Filter(s => s.Id == idCourse)
                .Include(s => s.Goals)
                .Include(s => s.Competences)
                .Include(s => s.Skills)
                .Include(s => s.NDEMembers)
                .Include(s => s.Books)
                .Track(false));

            var subject = _service.FirstOrDefault(new Query<Subject>().Filter(s => s.Id == idSubject).Include(s => s.ProfessorTeachingPlan));

            return new JsonResult(new {
                CourseName = course.Name,
                SubjectName = subject.Name,
                subject.TheoryWorkload,
                subject.PracticalWorkload,
                TotalWorkload = subject.TheoryWorkload + subject.PracticalWorkload,
                IdProfessor = subject.IdTeacherTeachingPlan,
                ProfessorName = subject.ProfessorTeachingPlan.UserName,
                ProfessorEmail = subject.ProfessorTeachingPlan.Email,
                Goals = course.Goals.Select(t => new SubjectCurriculumGoal()
                {
                    IdGoal = t.Id,
                    Goal = t,
                }),
                Competences = course.Competences.Select(t => new SubjectCurriculumCompetence()
                {
                    IdCompetence = t.Id,
                    Competence = t,
                }),
                Skills = course.Skills.Select(t => new SubjectCurriculumSkill()
                {
                    IdSkill = t.Id,
                    Skill = t,
                }),
                NDEMembers = course.NDEMembers.Select(t => new SubjectCurriculumNDEMember() {
                    IdNDEMember = t.Id,
                    NDEMember = t,
                }),
                BBooks = course.Books.Select(t => new SubjectCurriculumBook() {
                    IdBook = t.Id,
                    Book = t,
                    Type = Enums.BibliographyType.Basic
                }),
                CBooks = course.Books.Select(t => new SubjectCurriculumBook()
                {
                    IdBook = t.Id,
                    Book = t,
                    Type = Enums.BibliographyType.Complementary
                }),
            }, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
        }

    }
}
