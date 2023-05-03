import React, { useState, useEffect } from 'react';
import FitnessClubApi from '../Api/FitnessClub';
import {useNavigate} from 'react-router-dom';

function FitnessClubCreate(){
  const navigate = useNavigate();
  const [name, setName] = useState('');
  const [description, setDescription] = useState('');
  const [address, setAddress] = useState('');
  const [error, setError] = useState('');

  function onSetName(e){
    setName(e.target.value);
  }
  function onSetDescription(e){
    setDescription(e.target.value);
  }
  function onSerAddress(e){
    setAddress(e.target.value);
  }

  async function createFitnessClub(){
    let result = await FitnessClubApi.CreateFitnessClub(name, description, address);
    if(result.success){
      navigate('/fitness-club-list')
    } 
    else{
      setError(result.error);
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
    <button className="btn btn-primary" onClick={createFitnessClub}>Создать</button>
  </div>
}

export default FitnessClubCreate;