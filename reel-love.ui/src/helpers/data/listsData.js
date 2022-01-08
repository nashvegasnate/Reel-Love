import axios from 'axios';
import 'firebase/auth';
import firebaseConfig from '../apiKeys';

const dbUrl = firebaseConfig.databaseURL;

const getLists = () => new Promise((resolve, reject) => {
  axios.get(`${dbUrl}/api/mylists`)
    .then((response) => resolve(response.data))
    .catch((error) => reject(error));
});


export default getLists;