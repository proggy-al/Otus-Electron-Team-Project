import axios from 'axios';


const instance = axios.create({
  baseURL: 'http://localhost:5001/',
});

let auth = localStorage.getItem('app_auth');
let authData = JSON.parse(auth);

console.log('axios Get auth', auth)

instance.interceptors.request.use(
  config => {
    if (authData && authData.token && authData.token.length > 0) {
      config.headers['Authorization'] = `Bearer ${auth.token}`;
    }
    return config;
  },
  error => Promise.reject(error),
);

export default instance;