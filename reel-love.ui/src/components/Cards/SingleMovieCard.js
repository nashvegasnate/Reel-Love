import React, { useState } from 'react';
import {
  CardText,
  CardBody,
  CardTitle,
  Button,
  CardImg
} from 'reactstrap';
import PropTypes from 'prop-types';
//import ItemsForm from './ItemsForm';
// import { deleteItem } from '../helpers/data/itemsData';
// import { addItemCart } from '../helpers/data/cartData';
import { deleteMovie } from '../../helpers/data/MoviesData';

function SingleMovieCard({
  searchResults,
  title,
  imdbID,
  genre,
  runtime,
  year,
  plot,
  poster,
  user,
  setMovies,
  listId
}) {
  const [editing, setEditing] = useState(false);

  const handleClick = (type) => {
    switch (type) {
      case 'delete':
        deleteMovie(imdbID).then((moviesArray) => setMovies(moviesArray));
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
          <CardTitle tag="h3">Movie Title: {title}</CardTitle>
          <CardText>ImdbID: {imdbID}</CardText>
          <CardText>Genre: {genre}</CardText>
          <CardText>Runtime: {runtime}</CardText>
          <CardText>Year: {year}</CardText>
          <CardText>Plot: {plot}</CardText>
          <CardImg id="posterImg" height="auto" width="auto" src={poster}></CardImg>
          <Button
            className="btn-md mr-2 ml-2 mt-2"
            color="info"
            onClick={() => handleClick('edit')}
            size="sm">
            {editing ? 'Close Form' : 'Edit Item' }
          </Button>
          <Button
            className="btn-md mr-2 ml-2 mt-2"
            color="danger"
            onClick={() => handleClick('delete')}
            size="sm">Delete
          </Button>
            {editing && <MovieForm
                          imdbID={imdbID}
                          title={title}
                          genre={genre}
                          runtime={runtime}
                          year={year}
                          plot={plot}
                          setMovies={setMovies}
                          listId={listId}
                          user={user}
                          formTitle='Edit Movie'
                        />
            }
        </CardBody>
      </div>
    </div>
  );
}

ItemCard.propTypes = {
  imdbID: PropTypes.any,
  title: PropTypes.any,
  genre: PropTypes.any,
  runtime: PropTypes.any,
  year: PropTypes.any,
  plot: PropTypes.any,
  setMovies: PropTypes.any,
  listId: PropTypes.any,
  user: PropTypes.any
};

export default SingleMovieCard;
