import React, { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { useParams } from 'react-router-dom';
import MovieCard from '../components/Cards/MovieCard';
import { getMovieByImdbID } from '../helpers/data/MoviesData';

function SingleMovieView({ user, setMovies }) {
  const [movie, setMovie] = useState({});
  const { movieParam } = useParams();

  useEffect(() => {
    getMovieByImdbID(movieParam).then(setMovie);
    console.warn(movieParam);
  }, [movieParam]);

  return (
    <div>
      <h3>SINGLE MOVIE VIEW</h3>
      {
        movie.length > 0
        && <MovieCard
        title={movie[0].title}
        imdbID={movie[0].imdbID}
        genre={movie[0].genre}
        runtime={movie[0].runtime}
        year={movie[0].year}
        poster={movie[0].poster}
        plot={movie[0].plot}
        user={user}
        setMovies={setMovies}
      />
    }
    </div>
  );
}

SingleMovieView.propTypes = {
  user: PropTypes.any.isRequired,
  movie: PropTypes.array,
  setMovies: PropTypes.func
};

export default SingleMovieView;