import axios from "../Axios/identity";

async function Login(name, password){
  const instance = axios();
  var response = await instance.post("/authorize", { UserName: name, Password: password });
  if(response.status == 200){
    return { success: true, data: response.data};
  }
  else{
    return {success: false, error: response};
  }
}

async function Registration(name, password, role, telegramName, email){
  let url = `/user`;
  let body = {
    "userName": name,
    "telegramUserName": telegramName,
    "email": email,
    "password": password,
    "role": role
  };

  try{
    const instance = axios();
    var response = await instance.post(url, body);
    if(response.status == 200){
      return {success: true};
    }
    else{
      console.log('Error in Registration: ', response.statusText, response);
      return {success: false, error: `error ${response.data}` };
    }
  }
  catch(ex){
    console.log('Error in Registration: ', ex);
    return {success: false, error: `error ${ex.message} ${ex.response.data}` };
  }
}

export default {
  Login: Login,
  Registration : Registration,
}