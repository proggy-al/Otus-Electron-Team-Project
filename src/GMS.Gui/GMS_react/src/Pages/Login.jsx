import React, { useState, useEffect } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';
import { login, logout } from '../Store/Auth/AuthStore';
import LoginForm from '../Components/Auth/LoginForm';
import RegisterForm from '../Components/Auth/RegisterForm';
import IdentityApi from '../Api/Identity';

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
  const [telegramName, setTelegramName] = useState('');
  const [email, setEmail] = useState('');
  const [role, setRole] = useState('User');
  const [commonRegError, setCommonRegError] = useState('');

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

function onTelegramNameChange(e){
  setTelegramName(e.target.value);
}

  function onEmailChange(e){
    setEmail(e.target.value);
  }

  function onRoleChangeHandler(e){
    setRole(e.target.value);
  }
  /**Кнопка залогиниться */
  async function loginUser(){
    let loginResponse = await IdentityApi.Login(userLogin, password);

    if(loginResponse.success){
      let creditianals = JSON.parse(atob(loginResponse.data.token.split('.')[1]));
      var creds = {...loginResponse.data, ...creditianals};
      localStorage.setItem("app_auth", JSON.stringify({...loginResponse.data, ...creditianals}));
      dispatch(login(creds))
      if(returnUrl && returnUrl.length > 0){
        navigate(returnUrl);
      }
      else{
        navigate("/");
      }
    }
    else{
      console.log('exeption login: ', loginResponse.error);
      setCommonLoginError("Ошибка : " + loginResponse.error)
    }
  }
  
  async function RegisterUser(){
    console.log(userLogin, password, telegramName, email, role);
    let regResult = await IdentityApi.Registration(userLogin, password, role, telegramName, email);
    if(regResult.success){
      await loginUser();
    }
    else{
      setCommonRegError(regResult.error);
    }
  
  }

  function info(){
    console.log('info', userLogin, password);
  }

  function changeMode(mode){
    setActionType(mode);
  }

  return <div>
    <div className='flex-hcc'>

      <div className="frame max-width500 mt-16">
        <div className="_login_header flex-hss mb-16 ponter">
          <div onClick={()=>changeMode('login')} className={actionType === 'login' ? "_login_left_header _login_selected": "_login_left_header"}>Войти</div>
          <div onClick={()=>changeMode('register')} className={actionType === 'register' ? "_login_right_header _login_selected": "_login_right_header"}>Регистрация</div>
        </div>
        {
          actionType === 'login' ?
          <LoginForm userLogin={userLogin} 
          onLoginChange={onLoginChange} 
          userLoginValidationError={userLoginValidationError}  
          password={password} 
          onPasswordChange={onPasswordChange} 
          passwordValidationError={passwordValidationError}  
          onLoginButtonClick={loginUser} 
          commonLoginError={commonLoginError}/> :
          <RegisterForm 
            userLogin={userLogin}
            onLoginChange={onLoginChange}
            userLoginValidationError={userLoginValidationError} 
            password={password} 
            onPasswordChange={onPasswordChange} 
            passwordValidationError={passwordValidationError} 
            telegramName={telegramName}
            onTelegramNameChange={onTelegramNameChange}
            email={email}
            onEmailChange={onEmailChange}
            role={role}
            onRoleChange={onRoleChangeHandler}
            commonRegError={commonRegError}

            onRegisterButtonClick={RegisterUser}
            commonLoginError={commonLoginError}
            />
        }
      </div>
    </div>
    <button onClick={info}> info</button>
  </div>
}

export default Login;