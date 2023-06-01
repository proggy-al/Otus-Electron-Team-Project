import { useEffect, useState } from "react";
import areaApi from '../../Api/Area';
 
function AreaCreateEditModal(props){
  const [name, setName] = useState('');
  const [fkId, setFkId] = useState('');
  const [areaId, setAreaId] = useState(0)

  useEffect(()=>{
    setName(props.data.name);
    setFkId(props.data.fkId);
    setAreaId(props.data.areaId);
  }, []);

  async function onSaveClick(){
    if(name.length == 0){
      alert("Наименование не может быть пустым");
      return;
    }

    if(areaId && areaId.length > 0){

      var resp = await areaApi.EditArea(areaId, name);
      if(!resp.success)
      {
        alert('Что то пошло не так (');
      }
      else{
        props.data.onRefreshEvent();
      }
    }
    else{
      let resp = await areaApi.CreateArea(fkId, name)
      if(!resp.success)
      {
        alert('Что то пошло не так (');
      }
      else{
        props.data.onRefreshEvent();
      }
    }
  }

  function onChangeName(e){
    setName(e.target.value);
  }

  return  <div className="p-16">
    <label>Введите наименование</label>
    <input className="mb-16 min-w-300" value={name} onChange={onChangeName}/>
    <br/>
    <button className="btn btn-primary" onClick={onSaveClick}>Сохранить</button>
  </div>
}

export default AreaCreateEditModal;