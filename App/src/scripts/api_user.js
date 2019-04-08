import {Api} from "./api.js"

class User extends Api {
    constructor() {
        super("User");
    }

    checkUsernameExists = (id, username, onSuccess) => this.get({ path_params: [id, username], action: "CheckUsernameExists", success: onSuccess })
}
export {User};