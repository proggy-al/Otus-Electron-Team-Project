import axios from "../Axios/core";

async function GetFitnessClubsAll(page, pageSize){
  try{
    const instance = axios();
    var request = `/api/FitnessClub/GetPage/${page}:${pageSize}`;
    var response = await instance.get(request);
    if(response.status == 200){
      return response.data;
    }
    else{
      console.log('Error in GetFitnessClubsAll: ', response.statusText, response);
      return [];
    }
  }
  catch(ex){
    console.log('Error in GetFitnessClubsAll: ', ex);
    return [];
  }
}

async function CreateFitnessClub(name, description, address){
  try{
    const instance = axios();
    let data = {
      "name": name,
      "description": description,
      "address": address
    };
  
    let url = `/api/FitnessClub/Add`;
    let response = await instance.post(url, data);
    if(response.status == 200){
      return {success: true};
    }
    else{
      console.log('Error in GetFitnessClubsAll: ', response.statusText, response);
      return {success: false, error: 'Произошла ошибка при отправке запроса'};
    }
  }
  catch(ex){
    console.log(ex);
    return {success: false, error: 'Произошла ошибка при отправке запроса'}
  }
  
}

export default {
  GetFitnessClubsAll : GetFitnessClubsAll,
  CreateFitnessClub: CreateFitnessClub
}