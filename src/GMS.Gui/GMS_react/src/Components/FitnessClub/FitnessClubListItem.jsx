
function FitnessClubListItem(props){

  return <div className="frame p-16 mb-16 " key={props.id}>
    <div className="font-20 weight-600">{props.name}</div>
    <div >{props.description}</div>
    <div><i>{props.address}</i></div>
    <div className="font-14 flex-hes special-color"> {props.id}</div>
  </div>
}

FitnessClubListItem.defaultProps = {id: "0", name: "default name", description: "default description", address: "default address"};
export default FitnessClubListItem;