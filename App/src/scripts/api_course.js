import {Api} from "./api.js"

class Course extends Api {
    constructor() {
        super("Course");
    }

    checkCodeExists = (id, code, onSuccess) => this.get({ path_params: [id, code], action: "CheckCodeExists", success: onSuccess })

    // Subjects
    readSubjects = (idCourse, onSuccess) => this.get({ path_params: [idCourse], action: "CourseSubject", success: onSuccess});
    saveSubjects = (idCourse, idSubjects, onSuccess) => { 
        var subjects = [];

        idSubjects.forEach(function(e) {
            subjects.push(e);            
        })

        this.put({ action: "CourseSubject", path_params: [idCourse], data: subjects, success: onSuccess});
    }

    // Coordinators
    readCoordinator = (idCourse, onSuccess) => this.get({ path_params: [idCourse], action: "CourseCoordinator", success: onSuccess});
    saveCoordinator = (idCourse, idCoordinators, onSuccess) => { 
        var coordinators = [];

        idCoordinators.forEach(function(e) {
            coordinators.push(e);            
        })

        this.put({ action: "CourseCoordinator", path_params: [idCourse], data: coordinators, success: onSuccess});
    }

    // NDE
    readNDE = (idCourse, onSuccess) => this.get({ path_params: [idCourse], action: "CourseNDE", success: onSuccess});
    saveNDE = (idCourse, idNDE, onSuccess) => { 
        var NDE = [];

        idNDE.forEach(function(e) {
            NDE.push(e);            
        })

        this.put({ action: "CourseNDE", path_params: [idCourse], data: NDE, success: onSuccess});
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

    // nde_members
    readNDEMembers = (idMember, onSuccess) => this.get({ action: "CourseNDEMember", path_params: [idMember], success: onSuccess});
    createNDEMember = (idMember, member, onSuccess) => this.post({ action: "CourseNDEMember", path_params: [idMember], data: member, success: onSuccess});
    editNDEMember = (idMember, member, onSuccess) => this.put({ action: "CourseNDEMember", path_params: [idMember], data: member, success: onSuccess});
    deleteNDEMember = (idMember, onSuccess) => this.delete({ action: "CourseNDEMember", path_params: [idMember], success: onSuccess});

    // Books
    readBooks = (idBook, onSuccess) => this.get({ action: "CourseBook", path_params: [idBook], success: onSuccess});
    createBook = (idBook, book, onSuccess) => this.post({ action: "CourseBook", path_params: [idBook], data: book, success: onSuccess});
    editBook = (idBook, book, onSuccess) => this.put({ action: "CourseBook", path_params: [idBook], data: book, success: onSuccess});
    deleteBook = (idBook, onSuccess) => this.delete({ action: "CourseBook", path_params: [idBook], success: onSuccess});
}

export {Course};