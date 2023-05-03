import axios from 'axios';

function GetInstance(){

  const instance = axios.create({
    baseURL: 'http://localhost:5001/',
  });
  
  let auth = localStorage.getItem('app_auth');
  
  let obj = JSON.parse(auth);
  
  instance.interceptors.request.use(
    config => {
      if (obj && obj.token && obj.token.length > 0) {
        config.headers['Authorization'] = `Bearer ${obj.token}`;
      }
      return config;
    },
    error => Promise.reject(error),
    );
    return instance;
  }
    
export default GetInstance;