function RegisterForm(props){

  return <div class="frame">
    <h3>Войти</h3>
    <div>
      <label>Логин</label>
      <input value={props.userLogin} onChange={props.onLoginChange}/>
      <small class="validation-error">{props.userLoginValidationError}</small>
    </div>
    <div>
      <label>Пароль</label>
      <input value={props.password}/>
      <small class="validation-error">{props.userPasswordValidationError}</small>
    </div>


  </div>
}

RegisterForm.defaultProps = {userLogin :'', userLoginValidationError: ''}
export default RegisterForm;