import React, {useState, useEffect} from 'react';
import { useParams } from 'react-router-dom'

function FitnessClub(){
  const query = useParams();
  const [fitnessId, setFitnessId] = useState(query.id);
  const [data, setData] = useState("");

  useEffect(()=>{
    console.log('get data for id ', fitnessId);
    setData('some newValue __'+fitnessId);
  }, []);

  function componentDidMount(){
    console.log('exec after mount '); 
  }
  return <div>
    <div>Fitness Club : id : {fitnessId} - {data}</div>
  </div>
}


export default FitnessClub;