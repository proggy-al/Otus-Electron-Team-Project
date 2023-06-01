// in authProvider.js
import inMemoryJWT from './inMemoryJwt';
//import console from 'console-browserify';


const authProvider = {
    login: ({ username, password }) => {
        const request = new Request('http://localhost:6001/authorize', {
            method: 'POST',
            body: JSON.stringify({ username, password }),
            headers: new Headers({ 'Content-Type': 'application/json' })
        });
        return fetch(request)
            .then((response) => {
                if (response.status < 200 || response.status >= 300) {
                    throw new Error(response.statusText);
                }
                return response.json();
            })
            .then(({ token }) => {inMemoryJWT.setToken(token);
                                  //console.log('zzzzz');
                                  inMemoryJWT.setRole(token);} );
    },
    logout: () => {
        inMemoryJWT.ereaseToken();
        return Promise.resolve();
    },

    checkAuth: () => {
        return inMemoryJWT.getToken() ? Promise.resolve() : Promise.reject();
    },

    checkError: (error) => {
        const status = error.status;
        if (status === 401 || status === 403) {
            inMemoryJWT.ereaseToken();
            return Promise.reject();
        }
        return Promise.resolve();
    },

    getPermissions: () => {
        //const role = localStorage.getItem('permissions');
        //console.log("role",inMemoryJWT.getRole() );
        //return inMemoryJWT.getRole() ? Promise.resolve(inMemoryJWT.getRole() ) : Promise.reject();
        return inMemoryJWT.getToken() ? Promise.resolve() : Promise.reject();
    },
};

export default authProvider;