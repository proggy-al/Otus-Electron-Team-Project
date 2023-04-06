
function LoginForm(props){

  return <div>
    <h3>Войти</h3>
    <div className="flex-vcc" >
      <label>Логин:</label>
      <input value={props.userLogin} onChange={props.onLoginChange}/><br/>
      <small className="validation-error">{props.userLoginValidationError}</small>
    </div>
    <div className="flex-vcc">
      <label>Пароль:</label>
      <input value={props.password} onChange={props.onPasswordChange}/><br/>
      <small className="validation-error">{props.passwordValidationError}</small>
    </div><br/>
    <div className="validation-error">{props.commonLoginError}</div>
    <button className="btn btn-primary" onClick={props.onLoginButtonClick}>Войти</button>

  </div>
}

LoginForm.defaultProps = {userLogin :'', userLoginValidationError: ''}
export default LoginForm;