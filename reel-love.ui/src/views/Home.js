import React from 'react';
import PropTypes from 'prop-types';
import {
  CardText,
  Button
} from 'reactstrap';
import { signInUser, signOutUser } from '../helpers/auth';
import TitleSearchBar from '../components/TitleSearchBar';
// import UserInfoCard from '../components/UserInfo';

function Home({ user, setMovie }) {
  const authenticated = () => (
    <>
    <CardText>Get started by browsing our items.</CardText>
    <Button color='danger' onClick={signOutUser}> Sign Out </Button>
    </>
  );

  const notAuthenticated = () => (
    <>
    <CardText>Sign in to start using the app</CardText>
    <Button color='info' onClick={signInUser}> Sign In </Button>
    </>
  );

  return (
    <div>
        <div className='user-welcome'>
          <h1>Welcome</h1>
        <hr></hr>
         {/* {user ? <h2>Come On In</h2> : <h2>Please Log In</h2>} */}
        </div>
      <div className='col-lg-12'>
          <h1>Search A Movie Title</h1>
        <TitleSearchBar
          user={user}
          setMovie={setMovie}
        />
      </div>
    </div>  
  );
}

Home.propTypes = {
  user: PropTypes.any,
  setMovie: PropTypes.func
};

export default Home;
