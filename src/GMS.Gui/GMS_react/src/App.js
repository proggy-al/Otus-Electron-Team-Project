import React, { useState, useEffect } from 'react';

// router
import { BrowserRouter as Router,
  Route,
  Link,
  Routes,
  useNavigate
} from 'react-router-dom';

import './App.css';
import Main from './Pages/Main';
import FitnessClubList from './Pages/FitnessClubList';
import FitnessClub from './Pages/FitnessClub';
import Login from './Pages/Login';

//store 
import { useSelector, useDispatch } from 'react-redux';
import { login, logout } from './Store/Auth/AuthStore';

function App() {
  const auth = useSelector(state => state.auth.value);
  const dispatch = useDispatch();
  const navigate = useNavigate();

  useEffect(() => {
    var auth = localStorage.getItem("app_auth");
    if(auth && auth.length > 0){
      let authData = JSON.parse(auth);
      if(!authData.token || authData.token.length == 0){
        navigate("/login");  
      }
      dispatch(login(authData));
    }
    else{
      console.log('href', window.location.location);
      navigate("/login");
    }
  }, 
  []);

  return ( 
    <div>
      <header>
        <nav>
          <ul>
            <li>
              <Link to="/">Главная</Link>
            </li>
            <li>
              <Link to="/fitness-club-list">Клубы</Link>
            </li>
          </ul>
        </nav>
      </header>
      <main>
        <Routes>
          <Route path="login" element={<Login />}></Route>
          <Route path="/" element={< Main />}/>
          <Route path="/fitness-club-list" element={< FitnessClubList />}/>
          <Route path="/fitness-club/:id" element={< FitnessClub />}/>
        </Routes>
      </main>
    </div>
  );
}

export default App;
