import React, { useState } from 'react';
import { useHistory } from 'react-router-dom';
import PropTypes from 'prop-types';
import {
  Button,
  FormGroup,
  Form,
  Input,
  Label
} from 'reactstrap';
import { addMovie, editMovie } from '../../helpers/data/moviesData';
//import { propTypes } from 'react-bootstrap/esm/Image';

const MovieForm = ({
  title,
  imdbID,
  genre,
  runtime,
  year,
  plot,
  poster,
  //listId,
  formTitle,
  setMovies

}) => {
  const [movie, setMovie ] = useState({
    title: title || '',
    imdbID: imdbID || '',
    genre: genre || '',
    runtime: runtime || '',
    year: year || '',
    plot: plot || '',
    poster: poster || '',
    //listId: listId || null
  
  });

  const history = useHistory();

  const handleInputChange = (e) => {
    setMovie((prevState) => ({
      ...prevState,
      [e.target.name]: e.target.value
    }));
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    if (movie.imdbID) {
      // editMovie(movie).then((moviesArray) => setMovies(moviesArray));
      editMovie(movie.imdbID, movie).then((moviesArray) => setMovies(moviesArray));
      history.push('/allMoviesView');
    } else {
      addMovie(movie).then((moviesArray) => setMovies(moviesArray));
      history.push('/allMoviesView');
    }
  };

  return (
    <>
      <div className='movie-form'>
        <Form id='MovieForm' autoComplete='off'>
          <h3>{formTitle}</h3>
          <FormGroup>
            <Label for='title'>Title: </Label>
            <Input
              name='title'
              id='title'
              placeholder='Movie Title'
              value={movie.title}
              type='text'
              onChange={handleInputChange}
              />
          </FormGroup>
          <FormGroup>
          <Label for='imdbID'>ImdbID: </Label>
            <Input
              name='imdbID'
              id='imdbID'
              placeholder='ImdbID'
              value={movie.imdbID}
              type='text'
              onChange={handleInputChange}
              />
          </FormGroup>
          <FormGroup>
            <Label for='genre'>Genre: </Label>
            <Input
              name='genre'
              id='genre'
              placeholder='genre'
              value={movie.genre}
              type='text'
              onChange={handleInputChange}
              />
          </FormGroup>
          <FormGroup>
            <Label for='runtime'>Runtime: </Label>
            <Input
              name='runtime'
              id='runtime'
              placeholder='Runtime'
              value={movie.runtime}
              type='text'
              onChange={handleInputChange}
              />
          </FormGroup>
          <FormGroup>
            <Label for='year'>Year: </Label>
            <Input
              name='year'
              id='year'
              placeholder='Release Year'
              value={movie.year}
              type='text'
              onChange={handleInputChange}
              />
          </FormGroup>
          <FormGroup>
            <Label for='plot'>Plot: </Label>
            <Input
              name='plot'
              id='plot'
              placeholder='Plot Description'
              value={movie.plot}
              type='text'
              onChange={handleInputChange}
              />
          </FormGroup>
          <FormGroup>
            <Label for='poster'>Poster: </Label>
            <Input
              name='poster'
              id='poster'
              placeholder='Poster Link'
              value={movie.poster}
              type='string'
              onChange={handleInputChange}
              />
          </FormGroup>
          {/* <FormGroup>
            <Label for='listId'>ListId: </Label>
            <Input
              name='listId'
              id='listId'
              value={movie.listId}
              type='string'
              onChange={handleInputChange}
              />
          </FormGroup> */}
          <Button type='submit' size="sm" className="btn-md mr-2 ml-2 mt-2" onClick={handleSubmit}>SUBMIT</Button>   
        </Form>
      </div>
    </>
  );
};

MovieForm.propTypes = {
  title: PropTypes.string,
  imdbID: PropTypes.string,
  genre: PropTypes.string,
  runtime: PropTypes.string,
  year: PropTypes.string,
  plot: PropTypes.string,
  poster: PropTypes.string,
  listId: PropTypes.string,
  formTitle: PropTypes.any,
  setMovies: PropTypes.func.isRequired

};

export default MovieForm;
