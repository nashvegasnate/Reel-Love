import React from 'react';
import {
  CardText,
  CardBody,
  CardTitle,
  CardImg,
  Button
} from 'reactstrap';
import PropTypes from 'prop-types';
import { addMovie } from '../../helpers/data/moviesData';

const MovieCard = ({
  searchResults
}) => {

  // const [editing, setEditing] = useState(false);

  // const handleclick = (type) => {
  //   switch (type) {
  //     case 'edit':
  //       setEditing((prevState) => !prevState);
  //       break;
  //     default:
  //       console.warn('No action taken');
  //   }
  // };
  const handleClick = () => {
    addMovie();
  };

  return (
    <div>
      <div className="movie-card">
        <CardBody>
          <CardTitle tag="h3">Movie Title: {searchResults.Title}</CardTitle>
          <CardText>ImdbID: {searchResults.imdbID}</CardText>
          <CardText>Genre: {searchResults.Genre}</CardText>
          <CardText>Runtime: {searchResults.Runtime}</CardText>
          <CardText>Year: {searchResults.Year}</CardText>
          <CardText>Plot: {searchResults.Plot}</CardText>
          <CardImg id="posterImg" height="auto" width="auto" src={searchResults.Poster}></CardImg>
          <Button onClick={() => handleClick('edit') }>Add Movie</Button>
        </CardBody>
      </div>  
    </div>
  );
}

MovieCard.propTypes = {
  //imdbID: PropTypes.any.isRequired,
  //title: PropTypes.any,
  // genre: PropTypes.any.isRequired,
  // runtime: PropTypes.any.isRequired,
  // year: PropTypes.any.isRequired,
  // poster: PropTypes.any.isRequired,
  // plot: PropTypes.any.isRequired,
  // setMovie: PropTypes.any.isRequired,
  user: PropTypes.any,
  searchResults: PropTypes.any
};

export default MovieCard;
