import React, {useState, useEffect} from 'react';
import { useSelector } from 'react-redux';
import areaApi from '../../Api/Area';
import AreaModals from './AreaModals';

function AreaListItem(props){
  const auth = useSelector(state => state.auth.value);
  const [showAddArea, setShowAddArea] = useState(false);

  async function onDeleteRaw(){
    var resp = await areaApi.DeleteArea(props.id)
    if(resp.success){
      props.onRefresh();
    }
    else{
      alert('Что то пошло не так (');
    }
  }

  function onRefresh(){
    props.onRefresh();
    setShowAddArea(!showAddArea);
  }

  function onEditRawCkick(){
    setShowAddArea(!showAddArea);
    props.onRefresh();
  }

  function closeEditArea(){
    setShowAddArea(!showAddArea);
  }

  return <div className="_underlined flex-hsbc mb-16 pb-4">
    <div>{props.name}</div>
    <div>
    {
      props.isOwner ? 
      <div>
        <button className="btn btn-primary mr-16" onClick={onEditRawCkick}>Редактировать</button>
        <button className="btn btn-empty" onClick={onDeleteRaw}>Удалить</button>
        <AreaModals show={showAddArea} type="edit" header="Зона клуба" data={{fkId:props.fitnessId,  name: props.name, areaId: props.id, onRefreshEvent: onRefresh}} onCloseModal={closeEditArea} />
      </div> : null
    }
    </div>
  </div>
}

AreaListItem.defaultProps = {}

export default AreaListItem;