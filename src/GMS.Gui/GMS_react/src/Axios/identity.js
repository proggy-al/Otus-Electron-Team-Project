import axios from 'axios';

function Getinstance(){

  const instance = axios.create({
    baseURL: 'http://localhost:6001/',
  });

  let auth = localStorage.getItem('app_auth');
  let authData = JSON.parse(auth);

  instance.interceptors.request.use(
    config => {
      if (authData && authData.token && authData.token.length > 0) {
        config.headers['Authorization'] = `Bearer ${auth.token}`;
      }
      return config;
    },
    error => Promise.reject(error),
    );

  return instance;
}

export default Getinstance;