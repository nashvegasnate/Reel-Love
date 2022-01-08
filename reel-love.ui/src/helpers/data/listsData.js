import axios from 'axios';
import 'firebase/auth';
import firebaseConfig from '../apiKeys';

const dbURL = firebaseConfig.databaseURL;

const getLists = () => new Promise((resolve, reject) => {
  axios.get(`${dbURL}/api/mylists`)
    .then((response) => resolve(response.data))
    .catch((error) => reject(error));
});

const createList = (listObj) => new Promise((resolve, reject) => {
  axios.post(`${dbURL}api/mylists`, listObj)
  .then((response) => resolve(response.data))
  .catch((error) => reject(error));
});

export { getLists, createList };