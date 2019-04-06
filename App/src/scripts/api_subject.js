import {Api} from "./api.js"

class Subject extends Api {
    constructor() {
        super("Subject");
    }

    readProfessors = function(id, onSuccess) {
        this.get({ action: "SubjectProfessors", path_params: [id], success: onSuccess });
    }
}
export {Subject};