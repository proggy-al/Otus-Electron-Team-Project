export default ()=>{
  if(process.env.NODE_ENV === 'production'){
    return{
      BASE_URL: 'http://localhost:4001/'
    }
  }
  else{
    return{
      BASE_URL: 'http://localhost:4001/'
    }
  }
}