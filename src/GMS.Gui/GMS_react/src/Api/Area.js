import axios from "../Axios/core";

async function GetFitnessClubAreas(fkId){
  try{
    const instance = axios();
    var request = `/api/Area/GetPage/1:100000?fitnessClubId=${fkId}`;
    var response = await instance.get(request);

    if(response.status == 200){
      return response.data;
    }
    else{
      console.log('Error in GetFitnessClubAreas: ', response.statusText, response);
      return [];
    }
  }
  catch(ex){
    console.log('Error in GetFitnessClubAreas: ', ex);
    return [];
  }
}

async function CreateArea(fkId, name){
  try{
    const instance = axios();
    var request = `/api/Area/Add/`;
    let body = {
      Name: name,
      FitnessClubId: fkId
    }

    var response = await instance.post(request, body);
    if(response.status == 200){
      return {
        success: true
      };
    }
    else{
      console.log('Error in CreateArea: ', response.statusText, response);
      return {
        success: false
      };
    }
  }
  catch(ex){
    console.log('Error in CreateArea: ', ex);
    return {
      success: false
    };
  }
}

async function EditArea(areaId, name){
  try{
    const instance = axios();
    var request = `/api/Area/Edit/${areaId}`;
    let body = {
      Name: name
    }

    var response = await instance.put(request, body);
    if(response.status == 204){
      return {
        success: true
      };
    }
    else{
      console.log('Error in EditArea: ', response.statusText, response);
      return {
        success: false
      };
    }
  }
  catch(ex){
    console.log('Error in EditArea: ', ex);
    return {
      success: false
    };
  }
}

async function DeleteArea(areaId){
  try{
    const instance = axios();
    var request = `/api/Area/AddToArchive/${areaId}`;

    var response = await instance.delete(request);
    if(response.status == 204){
      return {
        success: true
      };
    }
    else{
      console.log('Error in DeleteArea: ', response.statusText, response);
      return {
        success: false
      };
    }
  }
  catch(ex){
    console.log('Error in DeleteArea: ', ex);
    return {
      success: false
    };
  }
}

export default {
  GetFitnessClubAreas: GetFitnessClubAreas,
  CreateArea: CreateArea,
  EditArea: EditArea,
  DeleteArea: DeleteArea

}