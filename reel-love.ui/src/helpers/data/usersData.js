import axios from 'axios';
import firebaseConfig from '../apiKeys';

const dbUrl = firebaseConfig.databaseURL

const getUserByFirebaseId = (id) => new Promise((resolve, reject) => {
  axios.get(`${dbUrl}/users/user/${id}`)
    .then((response) => resolve(response.data))
    .catch((error) => reject(error));
});

const createUser = (userInfo) => new Promise((resolve, reject) => {
  axios.post(`${dbUrl}/users`, userInfo)
    .then(() => getUserByFirebaseId(userInfo.firebaseId)).then((resp) => resolve(resp))
    .catch((error) => reject(error));
});

export { createUser, getUserByFirebaseId };
