import React, { useState, useEffect } from 'react';
import firebase from 'firebase/compat/app';
import { BrowserRouter as Router } from 'react-router-dom';
import 'firebase/compat/auth';
import Routes from '../helpers/Routes';
import NavBar from '../components/NavBar';
// import getMovieByTitle from '../helpers/data/moviesData';
// import {signInUser} from '../helpers/auth';
import './App.scss';
//import { getUserByFirebaseId } from '../helpers/data/usersData';
import { getLists } from '../helpers/data/ListsData';
import { getAllMovies } from '../helpers/data/MoviesData';

function App() {
  const [user, setUser] = useState(null);
  const [lists, setLists] = useState([]);
  const [movies, setMovies] = useState([]);
  
  // useEffect(() => {
  //   getLists().then(setLists);
  // }, []);
  
  useEffect(() => {
    firebase.auth().onAuthStateChanged((authed) => {
      if (authed) {
        const userInfoObj = {
          fullName: authed.displayName,
          profileImage: authed.photoURL,
          uid: authed.uid,
          user: authed.email.split('@')[0],
        };
        getLists().then((listsArray) => setLists(listsArray));
        getAllMovies().then((moviesArray) => setMovies(moviesArray));
        setUser(userInfoObj);
        //getLists(authed.uid).then(setLists);
      } else if (user || user === null) {
        setUser(false);
      }
    });
  }, []);

  return (
    <div className="app">
      <Router>
        <NavBar user={user} />
        <Routes
        user={user}
        lists={lists}
        movies={movies}
        setMovies={setMovies} 
        />
      </Router>  
    </div>
  );
}

export default App;
