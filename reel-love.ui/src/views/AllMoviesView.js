import React, { useEffect, useState } from 'react';
import { Button } from 'reactstrap';
import { getAllMovies } from '../helpers/data/MoviesData';
import { useHistory } from 'react-router-dom';
//import ListsCard from '../components/Cards/ListsCard';
//import MovieCard from '../components/Cards/MovieCard';
import PropTypes from 'prop-types';
//import AddListForm from '../components/Forms/AddListForm';

function AllMoviesView({ user }) {
  const [movies, setMovies ] = useState([]);
  const history = useHistory();

  useEffect(() => {
    getAllMovies().then(setMovies);
  }, []);

  const handlePush = (imdbID) => {
    history.push(`/moviesSingleView/${imdbID}`);
    console.warn(imdbID);
  };

  return (
    <div className='allMoviesView'><h3>ALL MOVIES</h3>
      <div>
        {movies.length === 0
        && <h3 className="text-center mt-2">No Movies Yet</h3>
        }
        <div className='"movie-container'>
          {movies.map((movie, imdbID) => (
            <h3 key={imdbID}>
              <Button className='mt-3' onClick={() => handlePush(movie.imdbID)}>{movie.title}</Button>
            </h3>
          ))}
        </div>  
      </div>
    </div> 
  );
}

AllMoviesView.propTypes = {
  user: PropTypes.any,
  setMovies: PropTypes.func,
  movies: PropTypes.array
};

export default AllMoviesView;