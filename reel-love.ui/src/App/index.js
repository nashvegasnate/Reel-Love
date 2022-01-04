import React, { useState, useEffect } from 'react';
import firebase from 'firebase/compat/app';
import { BrowserRouter as Router } from 'react-router-dom';
import 'firebase/compat/auth';
import Routes from '../helpers/Routes';
import NavBar from '../components/NavBar';
// import getMovieByTitle from '../helpers/data/moviesData';
// import {signInUser} from '../helpers/auth';
import './App.scss';

function App() {
  const [user, setUser] = useState({});
  
  useEffect(() => {
    firebase.auth().onAuthStateChanged((user) => {
      if (user) {             
        
        //store the token for later   
        user.getIdToken().then((token) => sessionStorage.setItem("token", token));
        
        setUser(user);
      } else {
        setUser(false);
      }
    });
  }, []);

  return (
    <div className="app">
      <Router>
        <NavBar user={user} setUser={setUser} />
        <Routes user={user} setUser={setUser} />
      </Router>  
    </div>
  );
}

export default App;
