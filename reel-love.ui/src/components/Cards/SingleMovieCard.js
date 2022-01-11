import React, { useState } from 'react';
import {
  CardText,
  CardBody,
  CardTitle,
  Button,
  CardImg
} from 'reactstrap';
import PropTypes from 'prop-types';
import MovieForm from '../Forms/MovieForm';
import { deleteMovie } from '../../helpers/data/moviesData';

function SingleMovieCard({
  title,
  imdbID,
  genre,
  runtime,
  year,
  plot,
  poster,
  setMovies,
  lists,
  user,
  //listId,
  movie
}) {
  const [editing, setEditing] = useState(false);

  const handleClick = (type) => {
    switch (type) {
      case 'delete':
        deleteMovie(imdbID).then(setMovies);
        break;
      case 'edit':
        setEditing((prevState) => !prevState);
        break;
      default:
        console.warn('default');
        break;
    }
  };

  return (
    <div> 
      <div className='single-movie-cards'>
        <CardBody>
          <CardTitle tag="h3">Movie Title: {movie?.title}</CardTitle>
          <CardText>ImdbID: {movie?.imdbID}</CardText>
          <CardText>Genre: {movie?.genre}</CardText>
          <CardText>Runtime: {movie?.runtime}</CardText>
          <CardText>Year: {movie?.year}</CardText>
          <CardText>Plot: {movie?.plot}</CardText>
          {/* <CardText>ListId: {movie?.listId}</CardText> */}
          <CardImg id="posterImg" height="auto" width="auto" src={movie?.poster}></CardImg>
          <Button
            className="btn-md mr-2 ml-2 mt-2"
            color="info"
            onClick={() => handleClick('edit')}
            size="sm">
            {editing ? 'Close Form' : 'Edit Movie' }
          </Button>
          <Button
            className="btn-md mr-2 ml-2 mt-2"
            color="danger"
            onClick={() => handleClick('delete')}
            size="sm">Delete
          </Button>
            {editing && <MovieForm
                          imdbID={movie.imdbID}
                          title={movie.title}
                          genre={movie.genre}
                          runtime={movie.runtime}
                          year={movie.year}
                          plot={movie.plot}
                          setMovies={setMovies}
                          //listId={listId}
                          user={user}
                          formTitle='Edit Movie'
                        />
            }
        </CardBody>
      </div>
    </div>
  );
}

SingleMovieCard.propTypes = {
  imdbID: PropTypes.any.isRequired,
  title: PropTypes.any.isRequired,
  genre: PropTypes.any.isRequired,
  runtime: PropTypes.any.isRequired,
  year: PropTypes.any.isRequired,
  plot: PropTypes.any.isRequired,
  setMovies: PropTypes.func,
  listId: PropTypes.any,
  user: PropTypes.any,
  movie: PropTypes.object.isRequired
};

export default SingleMovieCard;
