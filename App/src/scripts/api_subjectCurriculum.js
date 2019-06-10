import {Api} from "./api.js"

class SubjectCurriculum extends Api {
    constructor() {
        super("SubjectCurriculum");
    }

    getCollections = function(IdCourse, IdSubject, onSuccess) {
        this.get({ action: "GetCollections", path_params: [IdCourse,IdSubject], success: onSuccess });
    }
}

export {SubjectCurriculum};