using System;
using System.Collections.Generic;

namespace Api.Models
{
    public class SubjectCurriculum: ModelBase
    {
        public int IdCourse { get; set; }
        public Course Course { get; set; }

        public int IdSubject { get; set; }
        public Subject Subject { get; set; }

        public int IdProfessor { get; set; }
        public User Professor { get; set; }

        public int IdCoordinator { get; set; }
        public User Coordinator { get; set; }

        public DateTime DateAvaliacao { get; set; }

        public DateTime DateValidacaoNDE { get; set; }

        public string Ementa { get; set; } // Ementa

        public string ProgramContentM1 { get; set; } // Conteudo programatico M1
        public string ProgramContentM2 { get; set; } // Conteudo programatico M2

        public string TeachingMethod { get; set; } // Metodologia de Ensino
        public string Avaliacao { get; set; }

        public List<SubjectCurriculumGoal> Goals { get; set; }
        public List<SubjectCurriculumSkill> Skills { get; set; }
        public List<SubjectCurriculumCompetence> Competences { get; set; }
        public List<SubjectCurriculumBook> Bibliography { get; set; }
        public List<SubjectCurriculumNDEMember> NDEMembers { get; set; }

        public SubjectCurriculum()
        {
            Goals = new List<SubjectCurriculumGoal>();
            Skills = new List<SubjectCurriculumSkill>();
            Competences = new List<SubjectCurriculumCompetence>();
            Bibliography = new List<SubjectCurriculumBook>();
            NDEMembers = new List<SubjectCurriculumNDEMember>();
        }
    }
}