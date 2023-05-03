
import React, { useState, useEffect } from 'react';
import { useSelector } from 'react-redux';
import fitnessClubApi from '../Api/FitnessClub';
import FitnessClubListItem from '../Components/FitnessClub/FitnessClubListItem';
import { useParams, useNavigate } from 'react-router-dom';

function FitnessClubList(){
  const auth = useSelector(state => state.auth.value);
  const navigate = useNavigate();
  const [clubs, setClubs] = useState([]);

  const fitnessListMarkup = clubs.map((e) => <FitnessClubListItem id={e.id} name={e.name} description={e.description} address={e.address} />)

  useEffect(()=>{
    async function GetData(){
      var data = await fitnessClubApi.GetFitnessClubsAll(1, 6);
      setClubs(data);
    }
    GetData();
  }
  ,[]);

  function toCreateClub(){
    navigate('/fitness-club/create');
  }

  return <div class="p-16">
    {auth.Role === 'GYMOwner' ? 
      <button className="btn btn-primary mb-16" onClick={toCreateClub}>Добавить клуб</button> : ''}
    <div className="">
      {fitnessListMarkup}
    </div>
  </div>
}


export default FitnessClubList;
