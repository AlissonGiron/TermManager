import {Api} from "./api.js"

class Login extends Api {
    constructor() {
        super("Login");
    }

    login = function(root, username, password) {
        this.post({ 
            data: {
                userName: username,
                password: password
            },
            success: (responseJSON, response) => {
                root.jwt_token = responseJSON.token;
                root.userName = username;
                root.isLoggedIn = true;
            },
            error: () => {
                alert('Usuário ou senha incorretos');
            }
        });
    }

}
export {Login};