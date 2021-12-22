import axios from 'axios';
//import firebaseConfig from '../apiKeys';

//const dbURL = firebaseConfig.databaseURL;

const getMovieByTitle = (title) => new Promise((resolve, reject) => {
  axios.get(`http://www.omdbapi.com/?t=${title}&apikey=9345aaf8`)
    .then((response) => resolve(response.data))
    .catch((error) => reject(error));
});

export default getMovieByTitle;