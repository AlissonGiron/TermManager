import {Api} from "./api.js"

class Subject extends Api {
    constructor() {
        super("Subject");
    }

    checkCodeExists = (id, code, onSuccess) => this.get({ path_params: [id, code], action: "CheckCodeExists", success: onSuccess })

    readProfessors = function(id, onSuccess) {
        this.get({ action: "SubjectProfessors", path_params: [id], success: onSuccess });
    }
}
export {Subject};