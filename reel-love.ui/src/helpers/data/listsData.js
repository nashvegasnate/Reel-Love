import axios from 'axios';
import 'firebase/auth';
import firebaseConfig from '../apiKeys';

const dbUrl = firebaseConfig.databaseURL;

const getLists = () => new Promise((resolve, reject) => {
  axios.get(`${dbUrl}/myists`)
    .then((response) => resolve(Object.values(response.data)))
    .catch((error) => reject(error));
});

// const getLists = () => new Promise((resolve, reject) => {
//   axios.get(`${dbUrl}/mylists`)
//     .then((response) => resolve(response.data)).catch(reject);
// });

export default getLists;