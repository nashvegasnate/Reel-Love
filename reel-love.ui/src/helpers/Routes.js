import React from 'react';
import { Route, Switch, Redirect } from 'react-router-dom';
import PropTypes from 'prop-types';
import Home from '../views/Home';
import SingleMovieView from '../views/SingleMovieView';
import TitleSearchBar from '../components/TitleSearchBar';

const PrivateRoute = ({
  component: Component,
  user,
  ...rest
}) => {
  const routeChecker = (taco) =>
    user ? (
      <Component {...taco} user={user} />
    ) : (
      <Redirect to={{ pathname: '/', state: { from: taco.location } }} />
    );
  return <Route {...rest} render={(props) => routeChecker(props)} />;
};

PrivateRoute.propTypes = {
  component: PropTypes.func,
  user: PropTypes.any,
};

function Routes({ user, movies, setMovies, list, setList }) {
  return (
    <div>
      <Switch>
        <Route exact path='/' component={() => <Home
          user={user}
          setMovies={setMovies}
          />} />
        <PrivateRoute
          user={user}
          exact path="/moviesSingleView/:movieParam"
          component={() => <SingleMovieView
            user={user}
            movies={movies}
            setMovies={setMovies}
          />} />
        <PrivateRoute
          user={user}
          exact path="/titleSearch"
          component={() => <TitleSearchBar
            user={user}
            movies={movies}
            setMovies={setMovies}
          />} />
        <Route path="*" component={Home} />
      </Switch>
    </div>
  );
}

Routes.propTypes = {
  user: PropTypes.any,
  setMovie: PropTypes.func
};

export default Routes;
