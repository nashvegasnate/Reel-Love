import React from 'react';
import {
  CardText,
  CardBody,
  CardTitle,
  CardImg
} from 'reactstrap';
import PropTypes from 'prop-types';

function MovieCard({
  user,
  movie,
  searchResults
}) {

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
