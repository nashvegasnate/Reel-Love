import React, { useState } from 'react';
import { Button } from 'reactstrap';
//import { getAllMovies } from '../helpers/data/MoviesData';
//import { useHistory } from 'react-router-dom';
//import ListsCard from '../components/Cards/ListsCard';
//import MovieCard from '../components/Cards/MovieCard';
import PropTypes from 'prop-types';
import MovieForm from '../components/Forms/MovieForm';
import SingleMovieCard from '../components/Cards/SingleMovieCard';
//import ListForm from '../components/Forms/ListForm';

function AllMoviesView({ user, movies, setMovies }) {
  const [showAddMovie, setAddMovie ] = useState(false);
  //const history = useHistory();

  const handleClick = () => {
    setAddMovie((prevState) => !prevState);
  };

  // useEffect(() => {
  //   getAllMovies(user).then(setMovies);
  // }, []);
  
  // useEffect(() => {
  //   getAllMovies(user).then((moviesArray) => {
  //     setMovies(moviesArray);
  // });
  // }, []);

  // const handlePush = (imdbID) => {
  //   history.push(`/moviesSingleView/${imdbID}`);
  //   console.warn(imdbID);
  // };

  return (
    <div className='allMoviesView'>
      <h3>ALL MOVIES</h3>
      <div className='add-movie-container'>
        {!showAddMovie
          ? <Button className="addMovieBtn"  onClick={handleClick}>Add A Movie</Button>
          : <div>
              <Button className="closeForm" onClick={handleClick}>Close Form</Button>
                <MovieForm
                  setAddMovie={setAddMovie}
                  setMovies={setMovies}
                  user={user}
                  />
            </div>
        }
      </div>
        {movies.length === 0
        && <h3 className="text-center mt-2">No Movies Yet</h3>
        }
        <div className="movie-container">
          {/* {movies.map((movie, imdbID) => (
            <h3 key={imdbID}>
              <Button className='mt-3' onClick={() => handlePush(movie.imdbID)}>{movie.title}</Button>
            </h3>
          ))} */}
          {movies.map((movieInfo) => (
            <SingleMovieCard
             key={movieInfo.imdbID}
             movie={movieInfo}
             user={user}
             setMovies={setMovies}
             />
          ))}
        </div>  
    </div> 
  );
}

AllMoviesView.propTypes = {
  user: PropTypes.any,
  setMovies: PropTypes.func.isRequired,
  movies: PropTypes.array.isRequired
};

export default AllMoviesView;