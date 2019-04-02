import {Api} from "./api.js"

class Course extends Api {
    constructor() {
        super("Course");
    }

    // Subjects
    readSubjects = (idCourse, onSuccess) => this.get({ path_params: [idCourse], action: "CourseSubject", success: onSuccess});
    saveSubjects = (idCourse, idSubjects, onSuccess) => { 
        var subjects = [];

        idSubjects.forEach(function(e) {
            subjects.push(e);            
        })

        this.put({ action: "CourseSubject", path_params: [idCourse], data: subjects, success: onSuccess});
    }
    // Skill
    readSkills = (idCourse, onSuccess) => this.get({ action: "CourseSkill", path_params: [idCourse], success: onSuccess});
    createSkill = (idCourse, skill, onSuccess) => this.post({ action: "CourseSkill", path_params: [idCourse], data: skill, success: onSuccess});
    editSkill = (idSkill, skill, onSuccess) => this.put({ action: "CourseSkill", path_params: [idSkill], data: skill, success: onSuccess});
    deleteSkill = (idSkill, onSuccess) => this.delete({ action: "CourseSkill", path_params: [idSkill], success: onSuccess});

    // Competence
    readCompetences = (idCourse, onSuccess) => this.get({ action: "CourseCompetence", path_params: [idCourse], success: onSuccess});
    createCompetence = (idCourse, competence, onSuccess) => this.post({ action: "CourseCompetence", path_params: [idCourse], data: competence, success: onSuccess});
    editCompetence = (idCompetence, competence, onSuccess) => this.put({ action: "CourseCompetence", path_params: [idCompetence], data: competence, success: onSuccess});
    deleteCompetence = (idCompetence, onSuccess) => this.delete({ action: "CourseCompetence", path_params: [idCompetence], success: onSuccess});

    // Goal
    readGoals = (idCourse, onSuccess) => this.get({ action: "CourseGoal", path_params: [idCourse], success: onSuccess});
    createGoal = (idCourse, goal, onSuccess) => this.post({ action: "CourseGoal", path_params: [idCourse], data: goal, success: onSuccess});
    editGoal = (idGoal, goal, onSuccess) => this.put({ action: "CourseGoal", path_params: [idGoal], data: goal, success: onSuccess});
    deleteGoal = (idGoal, onSuccess) => this.delete({ action: "CourseGoal", path_params: [idGoal], success: onSuccess});
}

export {Course};