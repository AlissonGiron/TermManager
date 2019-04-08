import {Api} from "./api.js"

class Class extends Api {
    constructor() {
        super("Class");
    }

    checkCodeExists = (id, code, onSuccess) => this.get({ path_params: [id, code], action: "CheckCodeExists", success: onSuccess })

    readProfessors = function(id, onSuccess) {
        this.get({ action: "ClassProfessors", path_params: [id], success: onSuccess });
    }
}

export {Class};