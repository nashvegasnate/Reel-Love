import axios from 'axios';
//import firebaseConfig from '../apiKeys';

//const dbURL = firebaseConfig.databaseURL;
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

export default getMovieTitle;