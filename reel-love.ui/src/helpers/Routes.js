import React from 'react';
import { Route, Switch, Redirect } from 'react-router-dom';
import PropTypes from 'prop-types';
import Home from '../views/Home';
import SingleMovieView from '../views/SingleMovieView';
import TitleSearchBar from '../components/TitleSearchBar';
import MyListsView from '../views/MyListsView';
import AllMoviesView from '../views/AllMoviesView';

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

function Routes({ user, lists, setLists, movies, setMovies }) {
  return (
    <div>
      <Switch>
        <Route exact path='/' component={() => <Home
          user={user}
          />} />
        <PrivateRoute
          user={user}
          exact path='/moviesSingleView/:movieParam'
          component={() => <SingleMovieView
            user={user}
            movies={movies}
            setMovies={setMovies}
          />} />
        <PrivateRoute
          user={user}
          exact path='/titleSearch'
          component={() => <TitleSearchBar
            user={user}
            movies={movies}
            setMovies={setMovies}
          />} />
          <PrivateRoute
          user={user}
          exact path='/myListsView'
          component={() => <MyListsView
            user={user}
            lists={lists}
            setLists={setLists}
          />} />
           <PrivateRoute
          user={user}
          exact path='/allMoviesView'
          component={() => <AllMoviesView
            user={user}
            movies={movies}
            setMovies={setMovies}
          />} />
        <Route path='*' component={Home} />
      </Switch>
    </div>
  );
}

Routes.propTypes = {
  user: PropTypes.any,
  setMovie: PropTypes.func,
  setMovies: PropTypes.func,
  movies: PropTypes.array,
};

export default Routes;
