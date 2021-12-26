import React, { useState, useEffect } from 'react';
import firebase from 'firebase/compat/app';
import 'firebase/compat/auth';
import { BrowserRouter as Router } from 'react-router-dom';
import Routes from '../helpers/Routes';
import NavBar from '../components/NavBar';
// import getMovieByTitle from '../helpers/data/moviesData';
// import {signInUser} from '../helpers/auth';
import './App.scss';

function App() {
  const [user, setUser] = useState(null);
  //const [movies, setMovies] = useState([]);
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
      {/* <button className="signin-button google-logo" onClick={signInUser}>
        <i className="fas fa-sign-out-alt"></i> Sign In
      </button> */}
    </div>


  );
}

export default App;
