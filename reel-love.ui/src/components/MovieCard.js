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
//console.warn(searchResult);
  return (
    <div>
      <div className="movie-card">
        <CardBody>
          <CardTitle tag="h3">Movie Title: {searchResults.title}</CardTitle>
          <CardText>ImdbID: {searchResults.imdbID}</CardText>
          <CardText>Genre: {searchResults.Genre}</CardText>
          <CardText>Runtime: {searchResults.Runtime}</CardText>
          <CardText>Year: {searchResults.Year}</CardText>
          <CardImg id="posterImg" height="auto" width="auto" src={searchResults.Poster}></CardImg>
          <CardText>Plot: {searchResults.Plot}</CardText>
        </CardBody>
      </div>  
    </div>
  );
}

MovieCard.propTypes = {
  //imdbID: PropTypes.any.isRequired,
  title: PropTypes.any.isRequired,
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
