import React, { useEffect, useState } from 'react';
import PropTypes from 'prop-types';
import { useParams } from 'react-router-dom';
import SingleMovieCard from '../components/Cards/SingleMovieCard';
import { getMovieByImdbID } from '../helpers/data/MoviesData';

function SingleMovieView({ user, setMovies }) {
  const { movieParam } = useParams();
  const [movie, setMovie] = useState({});

  useEffect(() => {
    getMovieByImdbID(movieParam).then(setMovie);
    //console.warn(movieParam);
  }, [movieParam]);

  return (
    <div>
      <h3>SINGLE MOVIE VIEW</h3>
      {
        movie.length > 0
        && <SingleMovieCard
        title={movie[0].title}
        imdbID={movie[0].imdbID}
        genre={movie[0].genre}
        runtime={movie[0].runtime}
        year={movie[0].year}
        poster={movie[0].poster}
        plot={movie[0].plot}
        listId={movie[0].listId}
        user={user}
        setMovies={setMovies}
      />
    }
    </div>
  );
}

SingleMovieView.propTypes = {
  user: PropTypes.any.isRequired,
  movie: PropTypes.any,
  setMovies: PropTypes.any
};

export default SingleMovieView;