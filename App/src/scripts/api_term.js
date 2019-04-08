import {Api} from "./api.js"

class Term extends Api {
    constructor() {
        super("Term");
    }

    checkTermExists = (id, number, year, onSuccess) => this.get({ path_params: [id, year, number], action: "CheckTermExists", success: onSuccess })
}

export {Term};