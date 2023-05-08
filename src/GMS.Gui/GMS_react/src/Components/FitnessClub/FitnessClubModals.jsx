import FitnessClubCreate from '../../Pages/FitnessClubCreate';

function FitnessClubModals(props){
  function type(){
    if(props.props.type == 'edit'){
      return <FitnessClubCreate props={props.props.data}/>
    }
  }

  if(!props.props.show) return null;
  return <div className="_modal-background">
    <div className="_modal-container">
      <div className="_modal-header font-20 weight-600">{props.props.header}</div>
      {type()}
    </div>
  </div>
}

export default FitnessClubModals;