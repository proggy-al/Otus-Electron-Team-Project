import React, {useState, useEffect} from 'react';
import { useParams } from 'react-router-dom'
import { useSelector } from 'react-redux';

import fitnessClubApi from '../Api/FitnessClub';
import areasApi from '../Api/Area';

import FitnessClubModals from '../Components/FitnessClub/FitnessClubModals';
import AreaListItem from '../Components/Area/AreaListItem';
import AreaModals from '../Components/Area/AreaModals';

function FitnessClub(){
  const auth = useSelector(state => state.auth.value);
  const query = useParams();
  const [fitnessId, setFitnessId] = useState(query.id);
  const [fk, setFk] = useState({});
  const [modal, setModal] = useState({});
  const [areas, setAreas] = useState([]);
  const [showAddArea, setShowAddArea] = useState(false);

  useEffect(()=>{
    getClub();
    getAreas();
  }, []);

  function onRefresh(){
    getClub();
    getAreas();
    setShowAddArea(false);
  }

  async function getClub(){
    const fk = await fitnessClubApi.GetFitnessClubById(fitnessId);
    setFk(fk);
  }

  async function getAreas(){
    const areas = await areasApi.GetFitnessClubAreas(fitnessId);
    setAreas(areas);
  }

  function closeEditModal(){
    setModal({
      show: false
    });
    onRefresh();
  }

  const renderAreas = areas.length === 0 ?
    <div>Зон пока нет</div> :
    areas.map(e => <AreaListItem key={e.id} id={e.id} fitnessId={fitnessId} name={e.name} isOwner={isOwner()} onRefresh={onRefresh} />);

  function editFitnessClub(){
    setModal({
      show: true,
      type: 'edit',
      header: 'Редактировать',
      data: {
        kfId: fitnessId,
        name: fk.name,
        description: fk.description,
        address: fk.address,
        onEditSuccess: closeEditModal
      }
    });
  }

  function isOwner(){
    return auth.ID == fk.ownerId ? true : false;
  }

  function onCreateArea(){
    setShowAddArea(true);
  }

  function closeCreateArea(){
    setShowAddArea(false);
  }

  return <div className="p-16">
    <FitnessClubModals props={modal}/>
    <div className="font-12 main-color">Название</div>
    <div className="flex-hsbc">
      <div className="font-24 weight-600">{fk.name}</div>
      { isOwner() ? <div className="btn btn-primary" onClick={editFitnessClub}> Редактировать</div> : ''}
    </div>

    <div className="flex-hsc mb-16">
      <span className="font-14">id:</span>
      <div className="font-14 special-color">{fk.id}</div>
    </div>

    <div className="font-12 main-color">Описание</div>
    <div className="flex-hsbc mb-16">
      <div className="">{fk.description}</div>
    </div>

    <div className="font-12 main-color">Адрес</div>
    <div className="flex-hsbc ">
      <div className="">{fk.address}</div>
    </div>

    <br/>
    <br/>

    <h3>Зоны:</h3>
    {
      isOwner() ? <button className="btn btn-primary" onClick={onCreateArea}>Добавить</button> : null
    }
    {
      isOwner() ? <AreaModals show={showAddArea} type="edit" header="Зона клуба" data={{fkId:fitnessId, name:'', onRefreshEvent: onRefresh}} onCloseModal={closeCreateArea} /> : null
    }
    {renderAreas}

    <h3>Услуги клуба:</h3>
    {/* <div >Fitness Club : id : {fitnessId}</div> */}
  </div>
}


export default FitnessClub;