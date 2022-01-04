import React from 'react';
import {
  CardText,
  CardBody,
  CardTitle
} from 'reactstrap';
import PropTypes from 'prop-types';

function MovieCard({
  user,
  movie,
  searchResult
}) {
//console.warn(searchResult);
  return (
    <div>
      <MovieCard className="movie-card">
        <CardBody>
          <CardTitle tag="h3">Movie Title: {searchResult.Title}</CardTitle>
          <CardText>ImdbID: {searchResult.imdbID}</CardText>
          <CardText>Genre: {movie.Genre}</CardText>
          <CardText>Runtime: {movie.Runtime}</CardText>
          <CardText>Year: {movie.Year}</CardText>
          <CardText>Poster : {movie.Poster}</CardText>
          <CardText>Plot: {movie.Plot}</CardText>
          <CardText>User: {user.userName}</CardText>
        </CardBody>
      </MovieCard>  
    </div>
  );
}

MovieCard.propTypes = {
  imdbID: PropTypes.any.isRequired,
  title: PropTypes.any.isRequired,
  genre: PropTypes.any.isRequired,
  runtime: PropTypes.any.isRequired,
  year: PropTypes.any.isRequired,
  poster: PropTypes.any.isRequired,
  plot: PropTypes.any.isRequired,
  setMovie: PropTypes.any.isRequired,
  user: PropTypes.any,
  searchResult: PropTypes.any
};

export default MovieCard;
