import axios from 'axios';
import firebaseConfig from '../apiKeys';

const dbURL = firebaseConfig.databaseURL;
const corsProxy = 'https://salty-wildwood-25813.herokuapp.com/';

const getMovieTitle = (searchTitle) => new Promise((resolve, reject) => {
  axios.get(`${corsProxy}http://www.omdbapi.com/?t=${searchTitle}&apikey=9345aaf8`)
    .then((response) => resolve(response.data))
    .catch((error) => reject(error));
});

//TO TEST API AND GET A MOVIE BY HARD CODING A REQUEST
// const getMovieTitle = () => new Promise((resolve, reject) => {
//   axios.get(`${corsProxy}http://www.omdbapi.com/?t=whatever&apikey=9345aaf8`)
//     .then((response) => resolve(response.data))
//     .catch((error) => reject(error));
// });

// const getMovieTitle = (searchTitle) => new Promise((resolve, reject) => {
//   axios.get(`http://www.omdbapi.com/?t=${searchTitle}&apikey=9345aaf8`)
//     .then((response) => resolve(response.data))
//     .catch((error) => reject(error));
// });

// const getMovieTitle = (searchTitle) => new Promise((resolve, reject) => {
//   axios.get(`${apiurl} + &s=`)
//     .then((response) => resolve(response.data))
//     .catch((error) => reject(error));
// });

// const getMovieTitle = (searchText) => new Promise((resolve, reject) => {
//   axios.get(`http://www.omdbapi.com/?apikey=9345aaf8&s=` + searchText)
//     .then((response) => resolve(response.data))
//     .catch((error) => reject(error));
// });
const getAllMovies = () => new Promise((resolve, reject) => {
  axios.get(`${dbURL}/api/movies`)
    .then((response) => resolve(response.data))
    .catch((error) => reject(error));
});

const addMovie = (movieObject) => new Promise((resolve, reject) => {
  axios.post(`${dbURL}/api/movies`, movieObject)
    .then(() => {
      getAllMovies().then((resolve));
    }).catch((error) => reject(error));
});

const getMovieByImdbID = (ImdbID) => new Promise((resolve, reject) => {
  axios.get(`${dbURL}/api/movies/GetMovieByImdbID/${ImdbID}`)
    .then((response) => resolve(response.data))
    .catch((error) => reject(error));
});

  const editMovie = (ImdbID, movieObject) => new Promise((resolve, reject) => {
    console.warn(`${dbURL}/api/movies/${ImdbID}`);
    axios.put(`${dbURL}/api/movies/${ImdbID}`, movieObject).then(() => {
      getMovieByImdbID(ImdbID).then(resolve).catch(reject);
    });
  });

// const editMovie = (movieObject) => new Promise((resolve, reject) => {
//   debugger;
//   axios.put(`${dbURL}/api/movies/${movieObject.ImdbID}`, movieObject).then(() => {
//     getMovieByImdbID(movieObject.ImdbID).then(resolve).catch(reject);
//   });
// });

const deleteMovie = (ImdbID) => new Promise((resolve, reject) => {
  axios.delete(`${dbURL}/api/movies/${ImdbID}`)
    .then(() => {
      getAllMovies().then((resolve));
    }).catch((error) => reject(error));
});

export { getMovieTitle, getAllMovies, addMovie, getMovieByImdbID, editMovie, deleteMovie };

