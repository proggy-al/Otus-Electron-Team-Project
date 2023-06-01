function RegisterForm(props){

  return <div>
    <div className="flex-vcc" >
      <label>Логин:</label>
      <input className="min-w-300 font-20"  value={props.userLogin} onChange={props.onLoginChange}/><br/>
      <small className="validation-error">{props.userLoginValidationError}</small>
    </div>
    <div className="flex-vcc">
      <label>Пароль:</label>
      <input className="min-w-300 font-20"  value={props.password} onChange={props.onPasswordChange}/><br/>
      <small className="validation-error">{props.passwordValidationError}</small>
    </div><br/>
    <div className="validation-error">{props.commonLoginError}</div>
    <div className="flex-vcc">
      <label>Email:</label>
      <input  className="min-w-300 font-20" value={props.email} onChange={props.onEmailChange}/><br/>
    </div><br/>
    <div className="flex-vcc">
      <label>Имя в телеграм:</label>
      <input className="min-w-300 font-20"  value={props.telegramName} onChange={props.onTelegramNameChange}/><br/>
    </div><br/>
    <div className="flex-vcc">
      <label>Роль:</label>
      <select className="min-w-300 font-20"  value={props.role} onChange={props.onRoleChange}>
        <option value="User">User</option>
        <option value="GYMOwner">GYMOwner</option>
      </select>
        <br/>
    </div><br/>
    <div className="validation-error">{props.commonRegError}</div>

    <button className="btn btn-primary" onClick={props.onRegisterButtonClick}>Регистрация</button>
  </div>
}

export default RegisterForm;