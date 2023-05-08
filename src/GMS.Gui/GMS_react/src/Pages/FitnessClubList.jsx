
import React, { useState, useEffect } from 'react';
import { useSelector } from 'react-redux';
import fitnessClubApi from '../Api/FitnessClub';
import FitnessClubListItem from '../Components/FitnessClub/FitnessClubListItem';
import { useParams, useNavigate } from 'react-router-dom';

import PageBar from '../Components/UiElements/PageBar';

function FitnessClubList(){
  const auth = useSelector(state => state.auth.value);
  const navigate = useNavigate();
  const [clubs, setClubs] = useState([]);
  const [mode, setMode] = useState('all');
  const [page, setPage] = useState(1);
  const [pagesCount, setPagesCount] = useState(4);
  const [pageSize, setPageSize] = useState(4);

  const fitnessListMarkup = clubs.map((e) => <FitnessClubListItem id={e.id} name={e.name} description={e.description} address={e.address} key={e.id}/>)

  useEffect(()=>{
    GetData();
  }
  ,[]);

  useEffect(()=>{
    GetData();
  }, [page, pageSize, mode])

  async function GetData(){
    if(mode == 'all'){
      var data = await fitnessClubApi.GetFitnessClubsAll(page, pageSize);
      if(data && data.success && data.paging){
        setPagesCount(data.paging.totalPages)
      }
      setClubs(data.content);
    }
    else{
      var data = await fitnessClubApi.GetFitnessClubsByUserId(page, pageSize);
      if(data && data.success && data.paging){
        setPagesCount(data.paging.totalPages)
      }
      setClubs(data.content);
    }
  }

  function toCreateClub(){
    navigate('/fitness-club/create');
  }

  function onChangePage(x){
    setPage(x);
  }

  function onChangePageSize(e){
    setPageSize(e);
  }

  function showMyClubs(){
    setPage(1);
    setMode('my')
  }
  function showAllClubs(){
    setPage(1);
    setMode('all');
  }

  function info(){
    console.log('info', page, pageSize, pagesCount)
  }

  return <div className="p-16">
    { auth.Role === 'GYMOwner'?
      <button className="btn btn-primary mb-16 mr-16" onClick={toCreateClub}>Добавить клуб</button> : ''
    }
    {auth.Role === 'GYMOwner' && mode == 'all' ? 
      <button className="btn btn-primary mb-16 mr-16" onClick={showMyClubs}>Мои клубы</button> : ''
    }
    {auth.Role === 'GYMOwner' && mode == 'my' ? 
      <button className="btn btn-primary mb-16 mr-16" onClick={showAllClubs}>Все клубы</button> : ''
    }
    <PageBar page={page} pageSize={pageSize} pagesCount={pagesCount} onPageClick={onChangePage} onPageSizeChange={onChangePageSize} />
    <div className="">
      {fitnessListMarkup}
    </div>
    <button onClick={info}>INFO</button>
  </div>
}


export default FitnessClubList;
