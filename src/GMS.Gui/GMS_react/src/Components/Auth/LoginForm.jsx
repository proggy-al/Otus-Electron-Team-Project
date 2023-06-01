
function LoginForm(props){

  return <div className="flex-vcc">
    <div className="flex-vcc" >
      <label>Логин:</label>
      <input className="min-w-300 font-20" value={props.userLogin} onChange={props.onLoginChange}/>
      <small className="validation-error">{props.userLoginValidationError}</small>
      <br/>
    </div>
    <div className="flex-vcc">
      <label>Пароль:</label>
      <input className="min-w-300 font-20" value={props.password} onChange={props.onPasswordChange}/>
      <small className="validation-error">{props.passwordValidationError}</small>
    </div><br/>
    <div className="validation-error">{props.commonLoginError}</div>
    <button className=" min-w-300 btn btn-primary weight-600 font-20" onClick={props.onLoginButtonClick}>Войти</button>

  </div>
}

LoginForm.defaultProps = {userLogin :'', userLoginValidationError: ''}
export default LoginForm;