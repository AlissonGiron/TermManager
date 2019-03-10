class User extends Api {
    constructor() {
        super("User");
    }
}

let apiUser = new User();

apiUser.get();