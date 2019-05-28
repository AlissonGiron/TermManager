import {Api} from "./api.js"

class Class extends Api {
    constructor() {
        super("Class");
    }

    checkCodeExists = (id, code, onSuccess) => this.get({ path_params: [id, code], action: "CheckCodeExists", success: onSuccess })

    readProfessors = function(id, onSuccess) {
        this.get({ action: "ClassProfessors", path_params: [id], success: onSuccess });
    }

    readCourses = function(id, onSuccess) {
        this.get({ action: "ClassCourses", path_params: [id], success: onSuccess });
    }

    readSubjects = function(id, courseId, onSuccess) {
        this.get({ action: "ClassSubjects", path_params: [courseId, id], success: onSuccess });
    }
}

export {Class};