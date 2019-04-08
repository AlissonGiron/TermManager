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
                if (response.status === 401) {
                    alert('Usuário ou senha incorretos');
                    return;
                }

                if (response.status === 200){
                    root.jwt_token = responseJSON.token;
                    root.isLoggedIn = true;
                }
            }
        });
    }

}
export {Login};