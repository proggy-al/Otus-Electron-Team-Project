import React, { useState, useEffect } from 'react';
import FitnessClubApi from '../Api/FitnessClub';
import {useNavigate} from 'react-router-dom';

function FitnessClubCreate(props){

  const navigate = useNavigate();
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [address, setAddress] = useState('');
  const [error, setError] = useState('');
  const [fkId, setFkId] = useState(0);

  useEffect(() => {
    setName(props?.props?.name);
    setDescription(props?.props?.description);
    setAddress(props?.props?.address);
    setFkId(props?.props?.kfId);
  }, []);

  function onSetName(e){
    setName(e.target.value);
  }
  function onSetDescription(e){
    setDescription(e.target.value);
  }
  function onSerAddress(e){
    setAddress(e.target.value);
  }

  function editMode(){
    if(fkId && fkId.length > 0) return true;
    return false;
  }

  async function createFitnessClub(){
    let result = await FitnessClubApi.CreateFitnessClub(name, description, address);
    if(result.success){
      navigate('/fitness-club/'+ result.id)
    } 
    else{
      setError(result.error);
    }
  }

  async function editFitnessClub(){
    let result = await FitnessClubApi.UpdateFitnessClub(fkId, name, description, address);
    if(result.success){
      alert('Успешно сохранено');
      props?.props?.onEditSuccess();
    }
  }

  return <div className="p-16">
    <label>Название:</label>
    <input className="min-w-300 font-20 mb-16" value={name} onChange={onSetName}/>
    <label>Описание:</label>
    <input className="min-w-300 font-20 mb-16" value={description} onChange={onSetDescription}/>
    <label>Адрес:</label>
    <input className="min-w-300 font-20 mb-16" value={address} onChange={onSerAddress}/>
    <br/>
    <div className="validation-error">{error}</div>
    {
      editMode() ? <button className="btn btn-primary" onClick={editFitnessClub}>Изменить</button>
      : <button className="btn btn-primary" onClick={createFitnessClub}>Создать</button>
    }
    {
      // editMode() ? <button className="btn btn-primary" onClick={props?.props?.onEditSuccess()}>Отмена</button> : null
    }
  </div>
}

FitnessClubCreate.defaultProps = {};
export default FitnessClubCreate;