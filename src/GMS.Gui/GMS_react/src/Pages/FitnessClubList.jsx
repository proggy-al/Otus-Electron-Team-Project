import axios from '../Axios/core';
import React, { useState, useEffect } from 'react';
import { useSelector, useDispatch } from 'react-redux';

function FitnessClubList(){
  const auth = useSelector(state => state.auth.value);
  const [clubs, useClubs] = useState([]);


  useEffect(()=>{
    axios.get("api/FitnessClub/GetPage/1:6")
      .then(list=> {
        console.log('clubs', list);
      })
  }
  ,[]);

  return <div>
    <div>Fitness Club  List: ...</div>
  </div>
}


export default FitnessClubList;