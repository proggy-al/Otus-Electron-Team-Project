import AreaCreateEditModal from "./AreaCreateEditModal";

function AreaModals(props){
  function type(){
    if(props.type == 'edit'){
      return <AreaCreateEditModal data={props.data}/>
    }
  }

  if(!props.show) return null;
  return <div className="_modal-background">
    <div className="_modal-container">
      <div className="_modal-header font-20 weight-600 flex-hsbc">{props.header}<span onClick={props.onCloseModal} className="ponter">закрыть</span></div>
      {type()}
    </div>
  </div>
}

export default AreaModals;