import React from 'react';
import {
  CardText,
  CardBody,
  CardTitle
} from 'reactstrap';
import PropTypes from 'prop-types';

function MovieCard({
  imdbID,
  title,
  genre,
  runtime,
  year,
  poster,
  plot,
  setMovie,
  user
}) {

  return (
    <div>
      <MovieCard className="movie-card">
        <CardBody>
          <CardTitle tag="h3">Movie Title: {title}</CardTitle>
          <CardText>ImdbID: {imdbID}</CardText>
          <CardText>Genre: {genre}</CardText>
          <CardText>Runtime: {runtime}</CardText>
          <CardText>Year: {year}</CardText>
          <CardText>Poster : {poster}</CardText>
          <CardText>Plot: {plot}</CardText>
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
  user: PropTypes.any.isRequired
};

export default MovieCard;
