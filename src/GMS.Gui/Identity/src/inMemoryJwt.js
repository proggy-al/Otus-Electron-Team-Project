// inMemoryJwt.js
import decodeJwt from 'jwt-decode';
//import console from 'console-browserify';

const inMemoryJWTManager = () => {
    let inMemoryJWT = null;
    let role=null;


    const getRole=()=>role;
    const getToken = () => inMemoryJWT;

    const setToken = (token) => {
        inMemoryJWT = token;
        return true;
    };

    const setRole=(token)=>{
        const decodedToken = decodeJwt(token);
        //role =decodedToken.toString().substring(decodedToken.toString().indexOf("role")+5);
        //const strToken=decodedToken.toString();
        //if (!strToken || strToken.split('.').length < 3) {
        //    return false
       // }
        //const data = JSON.parse(atob(strToken.split('.')[1]))

        role=decodedToken.Role;
        console.log('Token',token);
        console.log('decodedToken',decodedToken);
        //console.log('strToken',strToken);
        console.log('role',role);
        return true;
    };



    const ereaseToken = () => {
        inMemoryJWT = null;
        return true;
    }

    return {
        ereaseToken,
        getToken,
        setToken,
        setRole,
        getRole
    }
};

export default inMemoryJWTManager();