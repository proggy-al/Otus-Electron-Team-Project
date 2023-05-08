function PageBar(props){

  const getPages = [...Array(props.pagesCount).keys()].map((i) => <div className="_page-item" onClick={() => props.onPageClick(i+1)} key={i+1}>{i+1}</div>);
  return <div className="_page-box-container mb-16">

    {getPages} 
    <span className="mr-4">на странице</span>
    <select onChange={e => props.onPageSizeChange(e.target.value)}>
      <option value={4}>4</option>
      <option value={6}>6</option>
      <option value={8}>8</option>
    </select>
  </div>
}

export default PageBar;