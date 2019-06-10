import {Api} from "./api.js"

class SubjectCurriculum extends Api {
    constructor() {
        super("SubjectCurriculum");
    }

    getCollections = function(IdCourse, IdSubject, onSuccess) {
        this.get({ action: "GetCollections", path_params: [IdCourse,IdSubject], success: onSuccess });
    }

    readCourses = function(id, onSuccess) {
        this.get({ action: "GetCourses", path_params: [id], success: onSuccess });
    }

    readSubjects = function(id, onSuccess) {
        this.get({ action: "GetSubjects", path_params: [id], success: onSuccess });
    }
}

export {SubjectCurriculum};