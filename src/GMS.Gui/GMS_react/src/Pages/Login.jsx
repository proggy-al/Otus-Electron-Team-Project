import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';
import { login, logout } from '../Store/Auth/AuthStore';
import LoginForm from '../Components/Auth/LoginForm';
import RegisterForm from '../Components/Auth/RegisterForm';
import Axios from '../Axios/identity';

function Login(){
  const query = useParams();
  const auth = useSelector(state => state.auth.value);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  const [returnUrl, setReturnUrl] = useState(query.returnUrl);
  const [actionType, setActionType] = useState('login');
  const [userLogin, setUserLogin] = useState('');
  const [userLoginValidationError, setUserLoginValidationError] = useState('');
  const [password, setPassword] = useState('');
  const [passwordValidationError, setPasswordValidationError] = useState('');
  const [commonLoginError, setCommonLoginError] = useState('');

  const [email, setEmail] = useState('');

  useEffect(()=>{
    
  }, []);

  function onLoginChange(e){
    if(e.target.value.length < 4 ){
      setUserLoginValidationError(' Длинна логина не может быть меньше 4 символов;')
    }
    else{
      setUserLoginValidationError('')
    }
    setUserLogin(e.target.value)
  }

  function onPasswordChange(e){
    if(e.target.value.length < 4 ){
      setPasswordValidationError(' Длинна пароля не может быть меньше 4 символов;')
    }
    else{
      setPasswordValidationError('')
    }
    setPassword(e.target.value)
  }

  /**Кнопка залогиниться */
  async function loginUser(){
    console.log('login clicked');
    
    Axios.post("/authorize", {UserName: userLogin, Password: password})
      .then((resp)=>{
        let creditianals = JSON.parse(atob(resp.data.token.split('.')[1]));
        localStorage.setItem("app_auth", JSON.stringify({...resp.data, ...creditianals}));
        if(returnUrl && returnUrl.length > 0){
          navigate(returnUrl);
        }
        else{
          navigate("/");
        }
      })
      .catch((ex)=>{
        console.log('exeption login: ', ex);
        setCommonLoginError("Ошибка : " + ex)
      })
  }

  function logoutUser(){
    dispatch(logout())
  }

  function info(){
    console.log('info', userLogin, password);
  }

  return <div>
    <div className='flex-hcc'>
      <div className="frame max-width500">
        {
          actionType === 'login' ?
          <LoginForm userLogin={userLogin} onLoginChange={onLoginChange} userLoginValidationError={userLoginValidationError}  
          password={password} onPasswordChange={onPasswordChange} passwordValidationError={passwordValidationError}  
          onLoginButtonClick={loginUser} commonLoginError={commonLoginError}/> :
          <RegisterForm />
        }
      </div>
    </div>
    <button onClick={info}> info</button>
  </div>
}

export default Login;